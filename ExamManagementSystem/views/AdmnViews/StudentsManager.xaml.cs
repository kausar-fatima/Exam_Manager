using System.Windows;
using System.Windows.Controls;
using ExamManagementSystem.Controllers;
using ExamManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;
using ExamManagementSystem.views.SuperAdmnViews;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace ExamManagementSystem.views.AdmnViews
{
    public partial class StudentsManager : Page
    {
        private readonly StudentController _studentController;
        private readonly CourseController _courseController;
        private readonly SectionController _sectionController;
        private readonly SessionController _sessionController;

        public ObservableCollection<Student> Students = new ObservableCollection<Student>();

        public StudentsManager()
        {
            InitializeComponent();

            _studentController = new StudentController();
            _courseController = new CourseController();
            _sectionController = new SectionController();
            _sessionController = new SessionController();

            LoadFilters();
            LoadStudents();
        }

        private void LoadFilters()
        {
            FilterCourseComboBox.ItemsSource = _courseController.GetAllCourses();
            FilterCourseComboBox.DisplayMemberPath = "CourseName";
            FilterCourseComboBox.SelectedValuePath = "CourseId";

            FilterSectionComboBox.ItemsSource = _sectionController.GetAllSections();
            FilterSectionComboBox.DisplayMemberPath = "SectionName";
            FilterSectionComboBox.SelectedValuePath = "SectionId";

            FilterSessionComboBox.ItemsSource = _sessionController.GetAllSessions();
            FilterSessionComboBox.DisplayMemberPath = "SessionName";
            FilterSessionComboBox.SelectedValuePath = "SessionId";
        }

        private void LoadStudents()
        {
            var selectedCourseId = FilterCourseComboBox.SelectedValue as int?;
            var selectedSectionId = FilterSectionComboBox.SelectedValue as int?;
            var selectedSessionId = FilterSessionComboBox.SelectedValue as int?;

            var students = _studentController.GetFilteredStudents(selectedCourseId, selectedSectionId, selectedSessionId);
            Students = new ObservableCollection<Student>(students);

            StudentsDataGrid.ItemsSource = Students;
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadStudents();
        }

        private void ResetFilters_Click(object sender, RoutedEventArgs e)
        {
            FilterCourseComboBox.SelectedIndex = -1;
            FilterSectionComboBox.SelectedIndex = -1;
            FilterSessionComboBox.SelectedIndex = -1;
            LoadStudents();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {

            AddStudentWindow addWindow = new AddStudentWindow(Students);
            addWindow.ShowDialog();
        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {
            var student = (sender as Button)?.DataContext as Student;
            if (student != null)
            {
                EditStudentWindow editWindow = new EditStudentWindow(student);
                editWindow.ShowDialog(); 
            }
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            var student = (sender as Button)?.DataContext as Student;
            if (student != null)
            {
                var result = MessageBox.Show($"Are you sure you want to delete {student.Name}?", "Confirm Delete", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _studentController.DeleteStudent(student.StudentId);
                    Students.Remove(student);
                }
            }
        }
    }
}
