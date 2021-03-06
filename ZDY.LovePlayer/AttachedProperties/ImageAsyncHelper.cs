﻿using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using GalaSoft.MvvmLight.Threading;
using NLog;
using ZDY.LovePlayer.Untils;

namespace ZDY.LovePlayer.AttachedProperties
{
    public enum ImageType
    {
        Thumbnail,
        Poster,
        Backdrop
    }

    public enum ImageSubType
    {
        Movie,
        Video,
        NetTV,
        Actor
    }

    public class ImageAsyncHelper : DependencyObject
    {
        private static Logger Logger { get; } = LogManager.GetCurrentClassLogger();

        #region Resource

        private static ResourceDictionary imageStateResourceDictionary = new ResourceDictionary
        {
            Source = new Uri("Resources/Theme/Styles/ImageStates.xaml", UriKind.Relative)
        };

        public static ImageSource GetLoadingImageResource()
        {
            var thumbnail = imageStateResourceDictionary["ImageLoading"] as DrawingImage;
            thumbnail.Freeze();
            return thumbnail;
        }

        public static ImageSource GetErrorImageResource()
        {
            var thumbnail = imageStateResourceDictionary["ImageError"] as DrawingImage;
            thumbnail.Freeze();
            return thumbnail;
        }

        public static ImageSource GetDefaultNetTVImageResource()
        {
            var thumbnail = imageStateResourceDictionary["DefaultNetTVImage"] as DrawingImage;
            thumbnail.Freeze();
            return thumbnail;
        }

        public static ImageSource GetDefaultVideoImageResource()
        {
            var thumbnail = imageStateResourceDictionary["DefaultVideoImage"] as DrawingImage;
            thumbnail.Freeze();
            return thumbnail;
        }

        #endregion

        #region Methods

        public static ImageType GetImageType(DependencyObject obj)
        {
            return (ImageType)obj.GetValue(ImageTypeProperty);
        }

        public static void SetImageType(DependencyObject obj, ImageType value)
        {
            obj.SetValue(ImageTypeProperty, value);
        }

        #endregion

        #region Properties 

        public static readonly DependencyProperty ImageTypeProperty =
            DependencyProperty.RegisterAttached("ImageType",
                typeof(ImageType),
                typeof(ImageAsyncHelper),
                new PropertyMetadata(ImageType.Backdrop));

        public static ImageSubType GetImageSubType(DependencyObject obj)
        {
            return (ImageSubType)obj.GetValue(ImageSubTypeProperty);
        }

        public static void SetImageSubType(DependencyObject obj, ImageSubType value)
        {
            obj.SetValue(ImageSubTypeProperty, value);
        }

        public static readonly DependencyProperty ImageSubTypeProperty =
            DependencyProperty.RegisterAttached("ImageSubType",
                typeof(ImageSubType),
                typeof(ImageAsyncHelper),
                new PropertyMetadata(ImageSubType.Movie));

        public static string GetMediaSource(DependencyObject obj)
        {
            return (string)obj.GetValue(MediaSourceProperty);
        }

        public static void SetMediaSource(DependencyObject obj, Uri value)
        {
            obj.SetValue(MediaSourceProperty, value);
        }

        public static readonly DependencyProperty MediaSourceProperty =
            DependencyProperty.RegisterAttached("MediaSource",
                typeof(string),
                typeof(ImageAsyncHelper),
                new PropertyMetadata(""));

        public static string GetImagePath(DependencyObject obj)
        {
            return (string)obj.GetValue(ImagePathProperty);
        }

        public static void SetImagePath(DependencyObject obj, Uri value)
        {
            obj.SetValue(ImagePathProperty, value);
        }

        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.RegisterAttached("ImagePath",
                typeof(string),
                typeof(ImageAsyncHelper),
                new PropertyMetadata(new PropertyChangedCallback(OnImagePathPropertyChangedCallback)));

        #endregion

        private static void OnImagePathPropertyChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var image = (Image)obj;
            var imageType = GetImageType(obj);
            var imageSubType = GetImageSubType(obj);

            var imageSize = image.GetImageSize(imageType, imageSubType);
            var mediaSource = GetMediaSource(obj);

            image.SetImageLoading();

            var path = e.NewValue as string;
            if (string.IsNullOrEmpty(path))
            {
                image.SetImageError(imageType, imageSubType);
                return;
            }

            ThreadPool.QueueUserWorkItem(new WaitCallback(async (state) =>
            {
                Thread.Sleep(10000);

                //创建临时目录
                var imageTempDirectory = $"{Constants.ImageTempDirectory}{imageType}\\{imageSubType}\\";
                if (!Directory.Exists(imageTempDirectory))
                {
                    Directory.CreateDirectory(imageTempDirectory);
                }

                //创建临时图片地址
                var hash = Convert.ToBase64String(Encoding.UTF8.GetBytes(path));
                var imageTempPath = imageTempDirectory + hash;

                var isNeedCreate = File.Exists(imageTempPath) ? false : true;
                try
                {
                    if (isNeedCreate)
                    {
                        if (!path.IsLocalPath())
                        {
                            using (var client = new HttpClient())
                            {
                                using (var ms = await client.GetStreamAsync(path).ConfigureAwait(false))
                                {
                                    using (var stream = new MemoryStream())
                                    {
                                        await ms.CopyToAsync(stream).ConfigureAwait(false);
                                        if (!File.Exists(imageTempPath))
                                        {
                                            using (var fs = new FileStream(imageTempPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite, 4096, true))
                                            {
                                                var writeAsync = stream.ToArray();
                                                await fs.WriteAsync(writeAsync, 0, writeAsync.Length).ConfigureAwait(false);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (File.Exists(path))
                            {
                                using (var fs = new FileStream(imageTempPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite, 4096, true))
                                {
                                    var writeAsync = File.ReadAllBytes(path);
                                    await fs.WriteAsync(writeAsync, 0, writeAsync.Length).ConfigureAwait(false);
                                }
                            }
                            else
                            {
                                if (imageSubType == ImageSubType.Video || imageSubType == ImageSubType.Movie)
                                {
                                    if (!string.IsNullOrEmpty(mediaSource))
                                    {
                                        if (File.Exists(mediaSource))
                                        {
                                            //FFmpeg.FFmpegHelper.GetSnapshot(mediaSource, imageTempPath, imageSize.Width, imageSize.Height);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    using (var fs = new FileStream(imageTempPath, FileMode.Open, FileAccess.Read))
                    {
                        var bitmapImage = new BitmapImage();
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.DecodePixelWidth = (int)imageSize.Width;
                        bitmapImage.DecodePixelHeight = (int)imageSize.Height;
                        bitmapImage.StreamSource = fs;
                        bitmapImage.EndInit();
                        bitmapImage.Freeze();
                        DispatcherHelper.CheckBeginInvokeOnUI(() =>
                        {
                            image.RenderTransformOrigin = new Point(0, 0);
                            if (imageType != ImageType.Poster)
                            {
                                image.Stretch = Stretch.UniformToFill;
                            }

                            image.RenderTransform = new TransformGroup();
                            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.Unspecified);
                            image.Source = bitmapImage;
                        });
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    image.SetImageError(imageType, imageSubType);
                }

            }));
        }
    }

    public static class Extension
    {
        public static void SetImageLoading(this Image image)
        {
            var loadingImage = ImageAsyncHelper.GetLoadingImageResource();

            #region Create Loading Animation

            var scaleTransform = new ScaleTransform(0.5, 0.5);
            var rotateTransform = new RotateTransform(0);

            var group = new TransformGroup();
            group.Children.Add(scaleTransform);
            group.Children.Add(rotateTransform);

            var doubleAnimation = new DoubleAnimation(0, 359, new TimeSpan(0, 0, 0, 1))
            {
                RepeatBehavior = RepeatBehavior.Forever
            };

            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, doubleAnimation);

            var loadingAnimationTransform = group;

            #endregion

            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                image.Source = loadingImage;
                image.Stretch = Stretch.Uniform;
                image.RenderTransformOrigin = new Point(0.5, 0.5);
                image.RenderTransform = loadingAnimationTransform;
            });
        }

        public static void SetImageError(this Image image, ImageType imageType,ImageSubType imageSubType)
        {
            image.RenderTransform = new TransformGroup();

            DispatcherHelper.CheckBeginInvokeOnUI(() =>
            {
                if (imageType == ImageType.Thumbnail)
                {
                    image.RenderTransformOrigin = new Point(0.5d, 0.5d);
                    image.Stretch = Stretch.None;

                    switch (imageSubType)
                    {
                        case ImageSubType.NetTV:
                            image.Source = ImageAsyncHelper.GetDefaultNetTVImageResource();
                            break;
                        case ImageSubType.Video:
                            image.Source = ImageAsyncHelper.GetDefaultVideoImageResource();
                            break;
                        default:
                            image.Source = ImageAsyncHelper.GetErrorImageResource();
                            break;
                    }
                }
                else
                {
                    image.Source = new BitmapImage();
                }
            });
        }

        public static bool IsLocalPath(this string path)
        {
            return !(path.StartsWith("http") || path.StartsWith("https"));
        }

        public static System.Drawing.Size GetImageSize(this Image image, ImageType imageType, ImageSubType imageSubType)
        {
            if (imageType == ImageType.Thumbnail)
            {
                switch (imageSubType)
                {
                    case ImageSubType.Movie:
                        return new System.Drawing.Size(200, 300);
                    case ImageSubType.Video:
                        return new System.Drawing.Size(300, 169);
                    case ImageSubType.NetTV:
                        return new System.Drawing.Size(200, 200);
                }
            }
            else if (imageType == ImageType.Poster)
            {
                return new System.Drawing.Size(800, 1200);
            }
            else
            {
                return new System.Drawing.Size(1920, 1080);
            }

            return new System.Drawing.Size();
        }
    }
}
