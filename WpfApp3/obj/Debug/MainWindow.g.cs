﻿#pragma checksum "..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B73473A225FF7A752184058AB5707B6FBE6F5BCE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp3;


namespace WpfApp3 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel ResourcePanel;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid WorldGrid;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas AfricaGrid;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas EuropeGrid;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas NAmericaGrid;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas SAmericaGrid;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas AsiaGrid;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas OceaniaGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp3;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            
            #line 2 "..\..\MainWindow.xaml"
            ((WpfApp3.MainWindow)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.OnKeyDownHandler);
            
            #line default
            #line hidden
            
            #line 14 "..\..\MainWindow.xaml"
            ((WpfApp3.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 14 "..\..\MainWindow.xaml"
            ((WpfApp3.MainWindow)(target)).Initialized += new System.EventHandler(this.Window_Initialized);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 62 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Meni);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 64 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.ScrollViewer)(target)).PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Resource_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 64 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.ScrollViewer)(target)).PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.Resource_PreviewMouseMove);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ResourcePanel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 5:
            this.WorldGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            
            #line 73 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Africa);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 74 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Europe);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 75 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_N_America);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 76 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_S_America);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 77 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Oceania);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 78 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Asia);
            
            #line default
            #line hidden
            return;
            case 12:
            this.AfricaGrid = ((System.Windows.Controls.Canvas)(target));
            
            #line 81 "..\..\MainWindow.xaml"
            this.AfricaGrid.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 81 "..\..\MainWindow.xaml"
            this.AfricaGrid.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.Canvas_PreviewMouseMove);
            
            #line default
            #line hidden
            
            #line 81 "..\..\MainWindow.xaml"
            this.AfricaGrid.Drop += new System.Windows.DragEventHandler(this.Image_Drop);
            
            #line default
            #line hidden
            
            #line 81 "..\..\MainWindow.xaml"
            this.AfricaGrid.DragEnter += new System.Windows.DragEventHandler(this.Image_DragEnter);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 83 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Back);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 84 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Clear);
            
            #line default
            #line hidden
            return;
            case 15:
            this.EuropeGrid = ((System.Windows.Controls.Canvas)(target));
            
            #line 87 "..\..\MainWindow.xaml"
            this.EuropeGrid.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 87 "..\..\MainWindow.xaml"
            this.EuropeGrid.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.Canvas_PreviewMouseMove);
            
            #line default
            #line hidden
            
            #line 87 "..\..\MainWindow.xaml"
            this.EuropeGrid.Drop += new System.Windows.DragEventHandler(this.Image_Drop);
            
            #line default
            #line hidden
            
            #line 87 "..\..\MainWindow.xaml"
            this.EuropeGrid.DragEnter += new System.Windows.DragEventHandler(this.Image_DragEnter);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 89 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Back);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 90 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Clear);
            
            #line default
            #line hidden
            return;
            case 18:
            this.NAmericaGrid = ((System.Windows.Controls.Canvas)(target));
            
            #line 93 "..\..\MainWindow.xaml"
            this.NAmericaGrid.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 93 "..\..\MainWindow.xaml"
            this.NAmericaGrid.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.Canvas_PreviewMouseMove);
            
            #line default
            #line hidden
            
            #line 93 "..\..\MainWindow.xaml"
            this.NAmericaGrid.Drop += new System.Windows.DragEventHandler(this.Image_Drop);
            
            #line default
            #line hidden
            
            #line 93 "..\..\MainWindow.xaml"
            this.NAmericaGrid.DragEnter += new System.Windows.DragEventHandler(this.Image_DragEnter);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 95 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Back);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 96 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Clear);
            
            #line default
            #line hidden
            return;
            case 21:
            this.SAmericaGrid = ((System.Windows.Controls.Canvas)(target));
            
            #line 100 "..\..\MainWindow.xaml"
            this.SAmericaGrid.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 100 "..\..\MainWindow.xaml"
            this.SAmericaGrid.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.Canvas_PreviewMouseMove);
            
            #line default
            #line hidden
            
            #line 100 "..\..\MainWindow.xaml"
            this.SAmericaGrid.Drop += new System.Windows.DragEventHandler(this.Image_Drop);
            
            #line default
            #line hidden
            
            #line 100 "..\..\MainWindow.xaml"
            this.SAmericaGrid.DragEnter += new System.Windows.DragEventHandler(this.Image_DragEnter);
            
            #line default
            #line hidden
            return;
            case 22:
            
            #line 102 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Back);
            
            #line default
            #line hidden
            return;
            case 23:
            
            #line 103 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Clear);
            
            #line default
            #line hidden
            return;
            case 24:
            this.AsiaGrid = ((System.Windows.Controls.Canvas)(target));
            
            #line 106 "..\..\MainWindow.xaml"
            this.AsiaGrid.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 106 "..\..\MainWindow.xaml"
            this.AsiaGrid.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.Canvas_PreviewMouseMove);
            
            #line default
            #line hidden
            
            #line 106 "..\..\MainWindow.xaml"
            this.AsiaGrid.Drop += new System.Windows.DragEventHandler(this.Image_Drop);
            
            #line default
            #line hidden
            
            #line 106 "..\..\MainWindow.xaml"
            this.AsiaGrid.DragEnter += new System.Windows.DragEventHandler(this.Image_DragEnter);
            
            #line default
            #line hidden
            return;
            case 25:
            
            #line 108 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Back);
            
            #line default
            #line hidden
            return;
            case 26:
            
            #line 109 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Clear);
            
            #line default
            #line hidden
            return;
            case 27:
            this.OceaniaGrid = ((System.Windows.Controls.Canvas)(target));
            
            #line 112 "..\..\MainWindow.xaml"
            this.OceaniaGrid.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.Canvas_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 112 "..\..\MainWindow.xaml"
            this.OceaniaGrid.PreviewMouseMove += new System.Windows.Input.MouseEventHandler(this.Canvas_PreviewMouseMove);
            
            #line default
            #line hidden
            
            #line 112 "..\..\MainWindow.xaml"
            this.OceaniaGrid.Drop += new System.Windows.DragEventHandler(this.Image_Drop);
            
            #line default
            #line hidden
            
            #line 112 "..\..\MainWindow.xaml"
            this.OceaniaGrid.DragEnter += new System.Windows.DragEventHandler(this.Image_DragEnter);
            
            #line default
            #line hidden
            return;
            case 28:
            
            #line 114 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Back);
            
            #line default
            #line hidden
            return;
            case 29:
            
            #line 115 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Clear);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

