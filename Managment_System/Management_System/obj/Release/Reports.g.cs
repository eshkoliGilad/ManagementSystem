﻿#pragma checksum "..\..\Reports.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "127CA8D4C89BE6C1F475613922893759"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
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


namespace Management_System {
    
    
    /// <summary>
    /// Reports
    /// </summary>
    public partial class Reports : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button back_button;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ReportsList;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button quit_button;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button open_button;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image stateOfDB;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Reports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image report_img;
        
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
            System.Uri resourceLocater = new System.Uri("/Management_System;component/reports.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Reports.xaml"
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
            this.back_button = ((System.Windows.Controls.Button)(target));
            
            #line 9 "..\..\Reports.xaml"
            this.back_button.Click += new System.Windows.RoutedEventHandler(this.back_button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ReportsList = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.quit_button = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\Reports.xaml"
            this.quit_button.Click += new System.Windows.RoutedEventHandler(this.quit_button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.open_button = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Reports.xaml"
            this.open_button.Click += new System.Windows.RoutedEventHandler(this.open_button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.stateOfDB = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.report_img = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

