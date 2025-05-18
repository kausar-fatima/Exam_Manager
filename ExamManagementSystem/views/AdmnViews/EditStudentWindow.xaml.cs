using System.Windows;
using ExamManagementSystem.Controllers;
using ExamManagementSystem.Models;
using System.Linq;
using ExamManagementSystem.Helpers;

namespace ExamManagementSystem.views.AdmnViews
{
    public partial class EditStudentWindow : Window
    {
        private readonly StudentController _controller;
        private readonly Student _student;

        public EditStudentWindow(Student student)
        {
            InitializeComponent();
            _controller = new StudentController();
            _student = student;
            LoadCombos();
            LoadStudentData();
        }

        private void LoadCombos()
        {
            using var context = new AppDbContext();

            CourseComboBox.ItemsSource = context.Courses.ToList();
            SectionComboBox.ItemsSource = context.Sections.ToList();
            SessionComboBox.ItemsSource = context.Sessions.ToList();
        }

        private void LoadStudentData()
        {
            if (_student != null)
            {
                NameTextBox.Text = _student.Name;
                RollTextBox.Text = _student.RollNumber;
                CnicTextBox.Text = _student.Cnic;
                AddressTextBox.Text = _student.Address;
                AgeTextBox.Text = _student.Age?.ToString();

                CourseComboBox.SelectedValue = _student.CourseId;
                SectionComboBox.SelectedValue = _student.SectionId;
                SessionComboBox.SelectedValue = _student.SessionId;
            }
            else
            {
                MessageBox.Show("Student not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        private void UpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string roll = RollTextBox.Text;
            string cnic = CnicTextBox.Text;
            string address = AddressTextBox.Text;
            int.TryParse(AgeTextBox.Text, out int age);
            int? courseId = CourseComboBox.SelectedValue as int?;
            int? sectionId = SectionComboBox.SelectedValue as int?;
            int? sessionId = SessionComboBox.SelectedValue as int?;

            if (!ValidationHelper.IsRequired(name) || !ValidationHelper.IsRequired(roll) || !ValidationHelper.IsRequired(cnic) || !ValidationHelper.IsRequired(address) || !ValidationHelper.IsRequired(age.ToString()!) || !ValidationHelper.IsRequired(courseId.ToString()!) || !ValidationHelper.IsRequired(sectionId.ToString()!) || !ValidationHelper.IsRequired(sessionId.ToString()!))
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

            _student.Name = name;
            _student.RollNumber = roll;
            _student.Cnic = CnicTextBox.Text;
            _student.Address = address;
            _student.Age = age;
            _student.CourseId = courseId;
            _student.SectionId = sectionId;
            _student.SessionId = sessionId;

            _controller.UpdateStudent(_student.StudentId, name, roll, cnic, address, age, sectionId, sessionId, courseId);
            MessageBox.Show("Student updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();

        }
    }
}
