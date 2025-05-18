using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;
using ExamManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExamManagementSystem.views.AdmnViews
{
    /// <summary>
    /// Interaction logic for EditCourseWindow.xaml
    /// </summary>
    public partial class EditCourseWindow : Window
    {
        private Course? _course;
        private readonly CourseController _courseController;

        public EditCourseWindow(Course course)
        {
            InitializeComponent();
            _course = course;
            _courseController = new CourseController();
            LoadCourseData();
        }

        private void LoadCourseData()
        {
            if (_course != null)
            {
                CourseTextBox.Text = _course.CourseName;
            }
        }

        private void UpdateCourse_Click(object sender, RoutedEventArgs e)
        {
            string newCourseName = CourseTextBox.Text.Trim();
            if (!ValidationHelper.IsRequired(newCourseName))
            {
                MessageBox.Show("Course name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (ValidationHelper.IsAlphabetic(newCourseName))
            {
                newCourseName = newCourseName.Trim();

                if (newCourseName != _course!.CourseName)
                {
                    _course.CourseName = newCourseName;

                    _courseController.UpdateCourse(_course.CourseId, newCourseName);
                    MessageBox.Show($"Course updated to: {newCourseName}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No changes made. Course name is the same.", "No Change", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("You must enter a valid course name.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
