﻿#pragma checksum "..\..\..\NewType\NewType.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "058CDCEB5EB03AF171828721F0039482A1057F64"
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
using WpfApp3.NewType;


namespace WpfApp3.NewType {
    
    
    /// <summary>
    /// NewType
    /// </summary>
    public partial class NewType : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\NewType\NewType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbozn;
        
        #line default
        #line hidden
        
        /// <summary>
        /// oznakaError Name Field
        /// </summary>
        
        #line 49 "..\..\..\NewType\NewType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Label oznakaError;
        
        #line default
        #line hidden
        
        /// <summary>
        /// imeErr Name Field
        /// </summary>
        
        #line 50 "..\..\..\NewType\NewType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Label imeErr;
        
        #line default
        #line hidden
        
        /// <summary>
        /// opisErr Name Field
        /// </summary>
        
        #line 51 "..\..\..\NewType\NewType.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.Label opisErr;
        
        #line default
        #line hidden
        
        /// <summary>
        /// b_potvrdi Name Field
        /// </summary>
        
        #line 60 "..\..\..\NewType\NewType.xaml"
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
            System.Uri resourceLocater = new System.Uri("/WpfApp3;component/newtype/newtype.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\NewType\NewType.xaml"
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
            this.tbozn = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\..\NewType\NewType.xaml"
            this.tbozn.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.LetterValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 44 "..\..\..\NewType\NewType.xaml"
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
            
            #line 56 "..\..\..\NewType\NewType.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IzborIkoniceClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.b_potvrdi = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\NewType\NewType.xaml"
            this.b_potvrdi.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

