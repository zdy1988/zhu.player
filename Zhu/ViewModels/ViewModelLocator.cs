/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Player"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Zhu.Models.ApplicationState;
using Zhu.Services;
using Zhu.ViewModels.FileExplorer;
using Zhu.ViewModels.Main;
using Zhu.ViewModels.Player;
using Zhu.ViewModels.Pages;

namespace Zhu.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region DataServices
            SimpleIoc.Default.Register<ITagService, TagService>();
            SimpleIoc.Default.Register<IMediaService, MediaService>();
            SimpleIoc.Default.Register<ISeenService, SeenService>();
            #endregion

            SimpleIoc.Default.Register<IApplicationState, ApplicationState>();

            #region ViewModels
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<FileExplorerViewModel>();
            SimpleIoc.Default.Register<MediaPlayerViewModel>();
            SimpleIoc.Default.Register<MovieListViewModel>();
            SimpleIoc.Default.Register<NetTVListViewModel>();
            SimpleIoc.Default.Register<SeenListViewModel>();
            #endregion
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public FileExplorerViewModel FileExplorer => ServiceLocator.Current.GetInstance<FileExplorerViewModel>();
        public MediaPlayerViewModel MediaPlayer => ServiceLocator.Current.GetInstance<MediaPlayerViewModel>();
        public MovieListViewModel MovieList => ServiceLocator.Current.GetInstance<MovieListViewModel>();
        public NetTVListViewModel NetTVList => ServiceLocator.Current.GetInstance<NetTVListViewModel>();
        public SeenListViewModel SeenList => ServiceLocator.Current.GetInstance<SeenListViewModel>();
    }
}