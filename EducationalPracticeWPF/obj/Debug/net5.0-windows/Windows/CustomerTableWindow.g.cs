﻿#pragma checksum "..\..\..\..\Windows\CustomerTableWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A79BB04D08D598CDEA904B1097E131B953C82CA4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
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
using System.Windows.Controls.Ribbon;
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


namespace EducationalPracticeWPF.Windows {
    
    
    /// <summary>
    /// CustomerTableWindow
    /// </summary>
    public partial class CustomerTableWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 54 "..\..\..\..\Windows\CustomerTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTB;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\Windows\CustomerTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastNameTB;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\Windows\CustomerTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstNameTB;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\Windows\CustomerTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneTB;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\Windows\CustomerTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CustomerDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EducationalPracticeWPF;component/windows/customertablewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\CustomerTableWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\Windows\CustomerTableWindow.xaml"
            ((EducationalPracticeWPF.Windows.CustomerTableWindow)(target)).Closed += new System.EventHandler(this.CustomerTableWindow_OnClosed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SearchTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 61 "..\..\..\..\Windows\CustomerTableWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonSearch_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 66 "..\..\..\..\Windows\CustomerTableWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClear_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LastNameTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.FirstNameTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.PhoneTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.CustomerDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 120 "..\..\..\..\Windows\CustomerTableWindow.xaml"
            this.CustomerDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CustomerDataGrid_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 133 "..\..\..\..\Windows\CustomerTableWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 139 "..\..\..\..\Windows\CustomerTableWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonEditCustomer_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 145 "..\..\..\..\Windows\CustomerTableWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonDeleteCustomer_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

