﻿#pragma checksum "..\..\meetings.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A0D178A81674CCAAD0FEFB581D6F6CB6"
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
    /// meetings
    /// </summary>
    public partial class meetings : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\meetings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView TenatsMeetings;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\meetings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datepicker_meetings;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\meetings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox notes_meetings_box;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\meetings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button save_button;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\meetings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cancel_button;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\meetings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock meetings_Address;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\meetings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button delete_metting;
        
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
            System.Uri resourceLocater = new System.Uri("/Management_System;component/meetings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\meetings.xaml"
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
            this.TenatsMeetings = ((System.Windows.Controls.ListView)(target));
            
            #line 6 "..\..\meetings.xaml"
            this.TenatsMeetings.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ListView_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.datepicker_meetings = ((System.Windows.Controls.DatePicker)(target));
            
            #line 21 "..\..\meetings.xaml"
            this.datepicker_meetings.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DatePicker_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.notes_meetings_box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.save_button = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\meetings.xaml"
            this.save_button.Click += new System.Windows.RoutedEventHandler(this.save_button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cancel_button = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\meetings.xaml"
            this.cancel_button.Click += new System.Windows.RoutedEventHandler(this.cancel_button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.meetings_Address = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.delete_metting = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\meetings.xaml"
            this.delete_metting.Click += new System.Windows.RoutedEventHandler(this.delete_metting_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

