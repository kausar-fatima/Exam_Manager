﻿#pragma checksum "..\..\..\..\..\views\ClerkViews\ScheduleManager.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A5C2EC1105BCE8AE02C903311DE67CF7974A18F5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ExamManagementSystem.views.ClerkViews;
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


namespace ExamManagementSystem.views.ClerkViews {
    
    
    /// <summary>
    /// ScheduleManager
    /// </summary>
    public partial class ScheduleManager : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 145 "..\..\..\..\..\views\ClerkViews\ScheduleManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CourseComboBox;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\..\..\views\ClerkViews\ScheduleManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SessionComboBox;
        
        #line default
        #line hidden
        
        
        #line 163 "..\..\..\..\..\views\ClerkViews\ScheduleManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox SectionComboBox;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\..\..\views\ClerkViews\ScheduleManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox RoomComboBox;
        
        #line default
        #line hidden
        
        
        #line 181 "..\..\..\..\..\views\ClerkViews\ScheduleManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ExamDatePicker;
        
        #line default
        #line hidden
        
        
        #line 186 "..\..\..\..\..\views\ClerkViews\ScheduleManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ExamTimeTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ExamManagementSystem;component/views/clerkviews/schedulemanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\views\ClerkViews\ScheduleManager.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CourseComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 145 "..\..\..\..\..\views\ClerkViews\ScheduleManager.xaml"
            this.CourseComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CourseComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SessionComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 150 "..\..\..\..\..\views\ClerkViews\ScheduleManager.xaml"
            this.SessionComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SessionComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SectionComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.RoomComboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.ExamDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.ExamTimeTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 190 "..\..\..\..\..\views\ClerkViews\ScheduleManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GenerateAttendanceSheet_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 191 "..\..\..\..\..\views\ClerkViews\ScheduleManager.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GenerateSeatingPlan_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

