﻿#pragma checksum "..\..\..\NewResource\NewResource.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F0FA15753226E2F349674CA8619BEC429263A056"
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
using WpfApp3.NewResource;


namespace WpfApp3.NewResource {
    
    
    /// <summary>
    /// NewResource
    /// </summary>
    public partial class NewResource : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\NewResource\NewResource.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tboznaka;
        
        #line default
        #line hidden
        
        /// <summary>
        /// oznakaError Name Field
        /// </summary>
        
        #line 50 "..\..\..\NewResource\NewResource.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Label oznakaError;
        
        #line default
        #line hidden
        
        /// <summary>
        /// imeErr Name Field
        /// </summary>
        
        #line 51 "..\..\..\NewResource\NewResource.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Label imeErr;
        
        #line default
        #line hidden
        
        /// <summary>
        /// opisErr Name Field
        /// </summary>
        
        #line 52 "..\..\..\NewResource\NewResource.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Label opisErr;
        
        #line default
        #line hidden
        
        /// <summary>
        /// cenaErr Name Field
        /// </summary>
        
        #line 129 "..\..\..\NewResource\NewResource.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Label cenaErr;
        
        #line default
        #line hidden
        
        /// <summary>
        /// b_potvrdi Name Field
        /// </summary>
        
        #line 150 "..\..\..\NewResource\NewResource.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Button b_potvrdi;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp3;component/newresource/newresource.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\NewResource\NewResource.xaml"
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
            this.tboznaka = ((System.Windows.Controls.TextBox)(target));
            
            #line 42 "..\..\..\NewResource\NewResource.xaml"
            this.tboznaka.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.LetterValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 45 "..\..\..\NewResource\NewResource.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.LetterValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 3:
            this.oznakaError = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.imeErr = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.opisErr = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            
            #line 61 "..\..\..\NewResource\NewResource.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IzborIkoniceClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 105 "..\..\..\NewResource\NewResource.xaml"
            ((System.Windows.Controls.TextBox)(target)).PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 8:
            this.cenaErr = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.b_potvrdi = ((System.Windows.Controls.Button)(target));
            
            #line 150 "..\..\..\NewResource\NewResource.xaml"
            this.b_potvrdi.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

