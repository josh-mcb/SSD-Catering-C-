﻿#pragma checksum "..\..\NewOrder.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A3527FEBCA7E591D132BB4F7A2AFD764"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SolutionCW;
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


namespace SolutionCW {
    
    
    /// <summary>
    /// NewOrder
    /// </summary>
    public partial class NewOrder : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\NewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox number;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\NewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker orderdate;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\NewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox venue;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\NewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker functiondate;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\NewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox starterCB;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\NewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox mainCB;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\NewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox dessertCB;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\NewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox customerCB;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\NewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addcardbutton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\NewOrder.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox deliverycheckbox;
        
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
            System.Uri resourceLocater = new System.Uri("/SolutionCW;component/neworder.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewOrder.xaml"
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
            this.number = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\NewOrder.xaml"
            this.number.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.number_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.orderdate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.venue = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\NewOrder.xaml"
            this.venue.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.venue_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.functiondate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.starterCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.mainCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.dessertCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            
            #line 28 "..\..\NewOrder.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.customerCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.addcardbutton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\NewOrder.xaml"
            this.addcardbutton.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 11:
            this.deliverycheckbox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 31 "..\..\NewOrder.xaml"
            this.deliverycheckbox.Checked += new System.Windows.RoutedEventHandler(this.deliverycheckbox_Checked);
            
            #line default
            #line hidden
            
            #line 31 "..\..\NewOrder.xaml"
            this.deliverycheckbox.Click += new System.Windows.RoutedEventHandler(this.deliverycheckbox_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

