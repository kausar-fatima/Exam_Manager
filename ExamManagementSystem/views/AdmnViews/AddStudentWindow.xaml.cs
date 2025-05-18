using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;
using ExamManagementSystem.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ExamManagementSystem.views.AdmnViews
{
    /// <summary>
    /// Interaction logic for AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        private readonly StudentController _studentController;
        private readonly AppDbContext _context;
        public ObservableCollection<Student> Students = new ObservableCollection<Student>();


        public AddStudentWindow(ObservableCollection<Student> students)
        {
            InitializeComponent();
            _studentController = new StudentController();
            _context = new AppDbContext();
            LoadDropdowns();
            Students = students;
        }

        private void LoadDropdowns()
        {
            // Load Courses
            var courses = _context.Courses.ToList();
            CourseComboBox.ItemsSource = courses;
            CourseComboBox.DisplayMemberPath = "CourseName";
            CourseComboBox.SelectedValuePath = "CourseId";

            // Load Sections
            var sections = _context.Sections.ToList();
            SectionComboBox.ItemsSource = sections;
            SectionComboBox.DisplayMemberPath = "SectionName";
            SectionComboBox.SelectedValuePath = "SectionId";

            // Load Sessions
            var sessions = _context.Sessions.ToList();
            SessionComboBox.ItemsSource = sessions;
            SessionComboBox.DisplayMemberPath = "SessionName";
            SessionComboBox.SelectedValuePath = "SessionId";
        }

        private void SaveStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NameTextBox.Text;
                string rollNumber = RollTextBox.Text;
                string cnic = CnicTextBox.Text;
                string address = AddressTextBox.Text;
                int? age = int.TryParse(AgeTextBox.Text, out int parsedAge) ? parsedAge : (int?)null;

                int? courseId = CourseComboBox.SelectedValue as int?;
                int? sectionId = SectionComboBox.SelectedValue as int?;
                int? sessionId = SessionComboBox.SelectedValue as int?;

                if ( !ValidationHelper.IsRequired(name) || !ValidationHelper.IsRequired(rollNumber) || !ValidationHelper.IsRequired(cnic) || !ValidationHelper.IsRequired(address) || !ValidationHelper.IsRequired(age.ToString()!) || !ValidationHelper.IsRequired(courseId.ToString()!) || !ValidationHelper.IsRequired(sectionId.ToString()!) || !ValidationHelper.IsRequired(sessionId.ToString()!))   
                {
                    MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!ValidationHelper.IsAlphabetic(name))
                {
                    MessageBox.Show("Please enter valid name", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!ValidationHelper.IsPositiveNumber(age.ToString()!))
                {
                    MessageBox.Show("Please enter valid age", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!ValidationHelper.IsValidCNIC(cnic))
                {
                    MessageBox.Show("Please enter valid cnic", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var newstudent = _studentController.AddStudent(name, rollNumber, cnic, address, age, sectionId, sessionId, courseId);
                Students.Add(newstudent);

                MessageBox.Show("Student added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close(); // Or clear fields instead of closing
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
