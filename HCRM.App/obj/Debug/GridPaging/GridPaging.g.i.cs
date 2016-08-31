﻿#pragma checksum "..\..\..\GridPaging\GridPaging.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D36847984C28542B202749C236342BFC"
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


namespace HCRM.App.GridPaging {
    
    
    /// <summary>
    /// GridPaging
    /// </summary>
    public partial class GridPaging : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\GridPaging\GridPaging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HCRM.App.GridPaging.GridPaging GPaging;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\GridPaging\GridPaging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lTotal;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\GridPaging\GridPaging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ButtonGrid;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\GridPaging\GridPaging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lPagina;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\GridPaging\GridPaging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lTotalPagina;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\GridPaging\GridPaging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLast;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\GridPaging\GridPaging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNext;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\GridPaging\GridPaging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrevious;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\GridPaging\GridPaging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFirst;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\GridPaging\GridPaging.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPageSize;
        
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
            System.Uri resourceLocater = new System.Uri("/HCRM.App;component/gridpaging/gridpaging.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GridPaging\GridPaging.xaml"
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
            this.GPaging = ((HCRM.App.GridPaging.GridPaging)(target));
            return;
            case 2:
            this.lTotal = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.ButtonGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.lPagina = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lTotalPagina = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.btnLast = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\GridPaging\GridPaging.xaml"
            this.btnLast.Click += new System.Windows.RoutedEventHandler(this.BtnLastClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnNext = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\GridPaging\GridPaging.xaml"
            this.btnNext.Click += new System.Windows.RoutedEventHandler(this.BtnNextClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnPrevious = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\GridPaging\GridPaging.xaml"
            this.btnPrevious.Click += new System.Windows.RoutedEventHandler(this.BtnPreviousClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnFirst = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\GridPaging\GridPaging.xaml"
            this.btnFirst.Click += new System.Windows.RoutedEventHandler(this.BtnFirstClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.cbPageSize = ((System.Windows.Controls.ComboBox)(target));
            
            #line 59 "..\..\..\GridPaging\GridPaging.xaml"
            this.cbPageSize.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBoxSelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
