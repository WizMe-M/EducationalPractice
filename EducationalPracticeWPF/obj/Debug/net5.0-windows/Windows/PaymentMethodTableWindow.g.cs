#pragma checksum "..\..\..\..\Windows\PaymentMethodTableWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1EBDAB49D802CA3AA5A2AFD9446D4AFF4104E947"
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
    /// PaymentMethodTableWindow
    /// </summary>
    public partial class PaymentMethodTableWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 55 "..\..\..\..\Windows\PaymentMethodTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchTB;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Windows\PaymentMethodTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NamingTB;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Windows\PaymentMethodTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid PaymentMethodDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/EducationalPracticeWPF;component/windows/paymentmethodtablewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Windows\PaymentMethodTableWindow.xaml"
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
            
            #line 10 "..\..\..\..\Windows\PaymentMethodTableWindow.xaml"
            ((EducationalPracticeWPF.Windows.PaymentMethodTableWindow)(target)).Closed += new System.EventHandler(this.PaymentMethodTableWindow_OnClosed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SearchTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 62 "..\..\..\..\Windows\PaymentMethodTableWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonSearch_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 67 "..\..\..\..\Windows\PaymentMethodTableWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClear_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NamingTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.PaymentMethodDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 90 "..\..\..\..\Windows\PaymentMethodTableWindow.xaml"
            this.PaymentMethodDataGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PaymentMethodDataGrid_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 101 "..\..\..\..\Windows\PaymentMethodTableWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonAddPaymentMethod_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 107 "..\..\..\..\Windows\PaymentMethodTableWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonEditPaymentMethod_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 113 "..\..\..\..\Windows\PaymentMethodTableWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonDeletePaymentMethod_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

