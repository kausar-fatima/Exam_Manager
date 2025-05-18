using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;
using ExamManagementSystem.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ExamManagementSystem.views.AdmnViews
{
    public partial class CoursesManager : Page
    {
        private readonly CourseController _courseController;

        public ObservableCollection<Course> Courses = new ObservableCollection<Course>();


        public CoursesManager()
        {
            InitializeComponent();
            _courseController = new CourseController();
            LoadCourses();
        }

        private void LoadCourses()
        {
            var courses = _courseController.GetAllCourses();
            Courses = new ObservableCollection<Course>(courses);
            CoursesDataGrid.ItemsSource = Courses;
        }

        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            string courseName = CourseNameTextBox.Text.Trim();

            if (!ValidationHelper.IsRequired(courseName))
            {
                MessageBox.Show("Course name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ValidationHelper.IsAlphabetic(courseName)) {
                MessageBox.Show("You must enter a valid course name.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newCourse = _courseController.AddCourse(courseName);
            Courses.Add(newCourse);
            CourseNameTextBox.Clear();
        }

        private void EditCourse_Click(object sender, RoutedEventArgs e)
        {
            if (CoursesDataGrid.SelectedItem is Course selectedCourse)
            {
                var editWindow = new EditCourseWindow(selectedCourse);
                editWindow.ShowDialog();
            }
        }

        private void DeleteCourse_Click(object sender, RoutedEventArgs e)
        {
            if (CoursesDataGrid.SelectedItem is Course selectedCourse)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete course '{selectedCourse.CourseName}'?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _courseController.DeleteCourse(selectedCourse.CourseId);
                        Courses.Remove(selectedCourse);
                        MessageBox.Show("Course deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to delete course: " + (ex.InnerException?.Message ?? ex.Message),
                            "Delete Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
            }
        }

    }
}
