﻿#pragma checksum "..\..\new_malfunction.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "78E0275FE2992A577F99755F278A1DAE"
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
    /// new_malfunction
    /// </summary>
    public partial class new_malfunction : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\new_malfunction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button save_malfunctions_button;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\new_malfunction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock description_malfunction_block;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\new_malfunction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock type_of_malfunction_block;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\new_malfunction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock building_malfunction_block;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\new_malfunction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combobox_type_mal;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\new_malfunction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combobox_building_mal;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\new_malfunction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox description_mal_box;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\new_malfunction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePicker_date;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\new_malfunction.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock date_block;
        
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
            System.Uri resourceLocater = new System.Uri("/Management_System;component/new_malfunction.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\new_malfunction.xaml"
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
            this.save_malfunctions_button = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\new_malfunction.xaml"
            this.save_malfunctions_button.Click += new System.Windows.RoutedEventHandler(this.save_malfunctions_button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.description_malfunction_block = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.type_of_malfunction_block = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.building_malfunction_block = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.combobox_type_mal = ((System.Windows.Controls.ComboBox)(target));
            
            #line 11 "..\..\new_malfunction.xaml"
            this.combobox_type_mal.Loaded += new System.Windows.RoutedEventHandler(this.ComboBox_Type_Loaded);
            
            #line default
            #line hidden
            return;
            case 6:
            this.combobox_building_mal = ((System.Windows.Controls.ComboBox)(target));
            
            #line 12 "..\..\new_malfunction.xaml"
            this.combobox_building_mal.Loaded += new System.Windows.RoutedEventHandler(this.ComboBox_Building_Loaded);
            
            #line default
            #line hidden
            return;
            case 7:
            this.description_mal_box = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.datePicker_date = ((System.Windows.Controls.DatePicker)(target));
            
            #line 14 "..\..\new_malfunction.xaml"
            this.datePicker_date.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DatePicker_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.date_block = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

