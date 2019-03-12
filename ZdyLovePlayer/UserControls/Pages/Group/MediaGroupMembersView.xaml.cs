﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZdyLovePlayer.ViewModels.Pages;

namespace ZdyLovePlayer.UserControls.Pages.Group
{
    /// <summary>
    /// MediaGroupMembersView.xaml 的交互逻辑
    /// </summary>
    public partial class MediaGroupMembersView : UserControl
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public MediaGroupMembersView()
        {
            InitializeComponent();

            this.Loaded += MediaGroupMembersView_Loaded;
        }

        private void MediaGroupMembersView_Loaded(object sender, RoutedEventArgs e)
        {
            this.CheckBox_SelectAll.IsChecked = false;

            var vm = DataContext as MediaGroupMembersViewModel;
            vm.OrderField = "ID";
            //await vm.LoadMediasAsync(true).ConfigureAwait(false);
        }

        private async void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var totalHeight = e.VerticalOffset + e.ViewportHeight;
            if (e.VerticalChange <= 0 || totalHeight < 2d / 3d * e.ExtentHeight)
            {
                return;
            }

            if (_semaphore.CurrentCount == 0)
            {
                return;
            }

            await _semaphore.WaitAsync();
            var vm = DataContext as MediaGroupMembersViewModel;
            if (vm == null)
            {
                _semaphore.Release();
                return;
            }

            if (!vm.IsDataLoading)
            {
                vm.LoadMedias();
            }

            _semaphore.Release();

        }
    }
}