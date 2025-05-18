using ClosedXML.Excel;
using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;
using ExamManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ExamManagementSystem.views.ClerkViews
{
    public partial class ScheduleManager : Page
    {
        private readonly StudentFilterController _studentFilterController;

        public ScheduleManager()
        {
            InitializeComponent();
            _studentFilterController = new StudentFilterController();
            LoadCourses();
            LoadRooms();
        }

        private void LoadCourses()
        {
            try
            {
                var courses = _studentFilterController.GetAvailableCourses();
                CourseComboBox.ItemsSource = courses;
                CourseComboBox.DisplayMemberPath = "CourseName";
                CourseComboBox.SelectedValuePath = "CourseId";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses: " + ex.Message);
            }
        }

        private void CourseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CourseComboBox.SelectedValue is int courseId)
            {
                SessionComboBox.ItemsSource = null;
                SectionComboBox.ItemsSource = null;

                var sessions = _studentFilterController.GetAvailableSessions(courseId);
                SessionComboBox.ItemsSource = sessions;
                SessionComboBox.DisplayMemberPath = "SessionName";
                SessionComboBox.SelectedValuePath = "SessionId";
            }
        }

        private void SessionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CourseComboBox.SelectedValue is int courseId &&
                SessionComboBox.SelectedValue is int sessionId)
            {
                SectionComboBox.ItemsSource = null;

                var sections = _studentFilterController.GetAvailableSections(courseId, sessionId);
                SectionComboBox.ItemsSource = sections;
                SectionComboBox.DisplayMemberPath = "SectionName";
                SectionComboBox.SelectedValuePath = "SectionId";
            }
        }
        private void LoadRooms()
        {
            var rooms = _studentFilterController.GetAllRooms();
            RoomComboBox.ItemsSource = rooms;
            RoomComboBox.DisplayMemberPath = "RoomNumber";
            RoomComboBox.SelectedValuePath = "RoomId";
        }

        private List<Student> ShuffleStudents(List<Student> students)
        {
            var rng = new Random();
            for (int i = students.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (students[i], students[j]) = (students[j], students[i]);
            }
            return students;
        }


        private void GenerateAttendanceSheet_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateSelections(out int courseId, out int sessionId, out int sectionId, out Room selectedRoom, out DateTime dateTime))
                return;

            var students = ShuffleStudents(_studentFilterController.GetFilteredStudents(courseId, sessionId, sectionId));
            int totalStudents = students.Count;
            int maxColumns = 3; // You can change based on layout preferences
            int columnsToUse = Math.Min(maxColumns, totalStudents);
            int rowsPerColumn = (int)Math.Ceiling((double)totalStudents / columnsToUse);

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Attendance Sheet");

            for (int colBlock = 0; colBlock < columnsToUse; colBlock++)
            {
                int col = colBlock * 3 + 1;
                string timeSlot = $"{dateTime:hh:mm tt}    {selectedRoom.RoomNumber}    Line {colBlock + 1}";

                worksheet.Cell(1, col).Value = timeSlot;
                worksheet.Range(1, col, 1, col + 2).Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                worksheet.Cell(2, col).Value = "Student ID";
                worksheet.Cell(2, col + 1).Value = "Name";
                worksheet.Cell(2, col + 2).Value = "Signature";

                for (int i = 0; i < rowsPerColumn; i++)
                {
                    int studentIndex = colBlock * rowsPerColumn + i;
                    if (studentIndex >= totalStudents)
                        break;

                    var student = students[studentIndex];
                    int row = i + 3;

                    worksheet.Cell(row, col).Value = student.RollNumber;
                    worksheet.Cell(row, col + 1).Value = student.Name;
                }

                worksheet.Columns(col, col + 2).AdjustToContents();
            }

            string fileName = $"AttendanceSheet_{dateTime:yyyyMMdd_HHmm}.xlsx";
            string fullPath = System.IO.Path.GetFullPath(fileName);
            workbook.SaveAs(fullPath);
            MessageBox.Show($"Attendance sheet generated: {fileName}");

            try
            {
                var preview = new PreviewWindow(fullPath, false);
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open preview window: " + ex.Message);
            }
        }

        private void GenerateSeatingPlan_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateSelections(out int courseId, out int sessionId, out int sectionId, out Room selectedRoom, out DateTime dateTime))
                return;

            var students = ShuffleStudents(_studentFilterController.GetFilteredStudents(courseId, sessionId, sectionId));
            int totalStudents = students.Count;
            int maxColumns = 3;
            int columnsToUse = Math.Min(maxColumns, totalStudents);
            int rowsPerColumn = (int)Math.Ceiling((double)totalStudents / columnsToUse);

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Seating Plan");

            for (int colBlock = 0; colBlock < columnsToUse; colBlock++)
            {
                int col = colBlock * 3 + 1;
                string timeSlot = $"{dateTime:hh:mm tt}    {selectedRoom.RoomNumber}    Line {colBlock + 1}";

                worksheet.Cell(1, col).Value = timeSlot;
                worksheet.Range(1, col, 1, col + 2).Merge().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                worksheet.Cell(2, col).Value = "Student ID";
                worksheet.Cell(2, col + 1).Value = "Name";

                for (int i = 0; i < rowsPerColumn; i++)
                {
                    int studentIndex = colBlock * rowsPerColumn + i;
                    if (studentIndex >= totalStudents)
                        break;

                    var student = students[studentIndex];
                    int row = i + 3;

                    worksheet.Cell(row, col).Value = student.RollNumber;
                    worksheet.Cell(row, col + 1).Value = student.Name;
                }

                worksheet.Columns(col, col + 2).AdjustToContents();
            }

            string fileName = $"SeatingPlan_{dateTime:yyyyMMdd_HHmm}.xlsx";
            string fullPath = System.IO.Path.GetFullPath(fileName);
            workbook.SaveAs(fullPath);
            MessageBox.Show($"Seating plan generated: {fileName}");

            try
            {
                var preview = new PreviewWindow(fullPath, true);
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open preview window: " + ex.Message);
            }
        }

        private bool ValidateSelections(out int courseId, out int sessionId, out int sectionId, out Room room, out DateTime dateTime)
        {
            courseId = sessionId = sectionId = 0;
            room = null;
            dateTime = DateTime.MinValue;

            if (CourseComboBox.SelectedValue == null || SessionComboBox.SelectedValue == null ||
                SectionComboBox.SelectedValue == null || RoomComboBox.SelectedItem == null ||
                ExamDatePicker.SelectedDate == null || ExamTimeTextBox.Text == null)
            {
                MessageBox.Show("Please select all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Get time input and validate
            string timeInput = ExamTimeTextBox.Text.Trim();
            if (!ValidationHelper.IsValidTime12Hour(timeInput))
            {
                MessageBox.Show("Please enter a valid time in hh:mm AM/PM format.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            // Get selected values
            courseId = (int)CourseComboBox.SelectedValue;
            sessionId = (int)SessionComboBox.SelectedValue;
            sectionId = (int)SectionComboBox.SelectedValue;
            room = (Room)RoomComboBox.SelectedItem;
            dateTime = ExamDatePicker.SelectedDate.Value;

            // Validate that date is today or in the future
            if (dateTime.Date < DateTime.Today)
            {
                MessageBox.Show("The selected date must not be in the past.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }


    }
}
