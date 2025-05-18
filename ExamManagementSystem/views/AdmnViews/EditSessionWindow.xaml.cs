using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;
using ExamManagementSystem.Models;
using System;
using System.Windows;

namespace ExamManagementSystem.views.AdmnViews
{
    /// <summary>
    /// Interaction logic for EditSessionWindow.xaml
    /// </summary>
    public partial class EditSessionWindow : Window
    {
        private Session? _Session;
        private readonly SessionController _SessionController;

        public EditSessionWindow(Session session)
        {
            InitializeComponent();
            _Session = session;
            _SessionController = new SessionController();
            LoadSessionData();
        }

        private void LoadSessionData()
        {
            if (_Session != null)
            {
                SessionTextBox.Text = _Session.SessionName;

                // Convert DateOnly to DateTime for DatePicker
                StartDatePicker.SelectedDate = _Session.StartDate.ToDateTime(TimeOnly.MinValue);
                EndDatePicker.SelectedDate = _Session.EndDate.ToDateTime(TimeOnly.MinValue);
            }
        }

        private void UpdateSession_Click(object sender, RoutedEventArgs e)
        {
            string newSessionName = SessionTextBox.Text.Trim();
            DateTime? startDateTime = StartDatePicker.SelectedDate;
            DateTime? endDateTime = EndDatePicker.SelectedDate;

            if (!ValidationHelper.IsRequired(newSessionName))
            {
                MessageBox.Show("Session can not be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!ValidationHelper.IsDigitsOnly(newSessionName))
            {
                MessageBox.Show("Please enter a valid session name.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (startDateTime == null || endDateTime == null)
            {
                MessageBox.Show("Please select both start and end dates.", "Missing Dates", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (startDateTime > endDateTime)
            {
                MessageBox.Show("Start date must be before or equal to end date.", "Invalid Date Range", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Convert to DateOnly for comparison/update
            DateOnly newStartDate = DateOnly.FromDateTime(startDateTime.Value);
            DateOnly newEndDate = DateOnly.FromDateTime(endDateTime.Value);

            // Check if any changes were made
            if (newSessionName == _Session!.SessionName &&
                newStartDate == _Session.StartDate &&
                newEndDate == _Session.EndDate)
            {
                MessageBox.Show("No changes made. All values are the same.", "No Change", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Update session
            _Session!.SessionName = newSessionName;
            _Session.StartDate = newStartDate;
            _Session.EndDate = newEndDate;
            _SessionController.UpdateSession(_Session.SessionId, newSessionName, newStartDate, newEndDate);

            MessageBox.Show("Session updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            
            this.Close();
        }
    }
}
