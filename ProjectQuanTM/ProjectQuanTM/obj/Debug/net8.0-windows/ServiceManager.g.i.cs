﻿#pragma checksum "..\..\..\ServiceManager.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F16849CB6624AA097073DB71132DF71C7596F3E2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectQuanTM;
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


namespace ProjectQuanTM {
    
    
    /// <summary>
    /// ServiceManager
    /// </summary>
    public partial class ServiceManager : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\ServiceManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listServices;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\ServiceManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbCID;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\ServiceManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNewNumber;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\ServiceManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPrice;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\ServiceManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox tbStatus;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\ServiceManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\ServiceManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox listRooms;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\ServiceManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpEndDate;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\ServiceManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpStartDate;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\ServiceManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbOldNumber;
        
        #line default
        #line hidden
        
        
        #line 119 "..\..\..\ServiceManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbTotalAmount;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjectQuanTM;component/servicemanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ServiceManager.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.listServices = ((System.Windows.Controls.ListView)(target));
            
            #line 12 "..\..\..\ServiceManager.xaml"
            this.listServices.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listServices_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbCID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tbNewNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbPrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 76 "..\..\..\ServiceManager.xaml"
            this.tbPrice.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbPrice_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tbStatus = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\ServiceManager.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.listRooms = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.dpEndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.dpStartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 10:
            this.tbOldNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.tbTotalAmount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            
            #line 128 "..\..\..\ServiceManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 129 "..\..\..\ServiceManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

