﻿#pragma checksum "..\..\..\..\..\..\UserControls\Home\Media\Moive\MovieListView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6DB00BCE74087E7A0F04AC223AEA6BD1"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Expression.Interactivity.Input;
using Microsoft.Expression.Interactivity.Layout;
using Microsoft.Expression.Interactivity.Media;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Zhu.AttachedProperties;
using Zhu.Controls;
using Zhu.Converters;
using Zhu.UserControls.Layout;
using Zhu.UserControls.Reused;


namespace Zhu.UserControls.Home.Media.Moive {
    
    
    /// <summary>
    /// MovieListView
    /// </summary>
    public partial class MovieListView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 41 "..\..\..\..\..\..\UserControls\Home\Media\Moive\MovieListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBox_SelectCountry;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\..\UserControls\Home\Media\Moive\MovieListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBox_SelectMediaLength;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\..\UserControls\Home\Media\Moive\MovieListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBox_SelectImageQuality;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\..\..\UserControls\Home\Media\Moive\MovieListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBox_MediaSort;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\..\..\UserControls\Home\Media\Moive\MovieListView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Zhu.Controls.AnimatedScrollViewer ScrollView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Zhu;component/usercontrols/home/media/moive/movielistview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\UserControls\Home\Media\Moive\MovieListView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ListBox_SelectCountry = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.ListBox_SelectMediaLength = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.ListBox_SelectImageQuality = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            
            #line 72 "..\..\..\..\..\..\UserControls\Home\Media\Moive\MovieListView.xaml"
            ((System.Windows.Controls.TextBox)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.SearchTextBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ComboBox_MediaSort = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.ScrollView = ((Zhu.Controls.AnimatedScrollViewer)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 7:
            
            #line 171 "..\..\..\..\..\..\UserControls\Home\Media\Moive\MovieListView.xaml"
            ((MaterialDesignThemes.Wpf.RatingBar)(target)).ValueChanged += new System.EventHandler<System.EventArgs>(this.RatingBar_ValueChanged);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

