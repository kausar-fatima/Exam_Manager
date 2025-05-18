using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;
using ExamManagementSystem.Models;

namespace ExamManagementSystem.views.AdmnViews
{
    public partial class SessionsManager : Page
    {
        private readonly SessionController sessionController;

        public ObservableCollection<Session> Sessions = new ObservableCollection<Session>();

        public SessionsManager()
        {
            InitializeComponent();
            sessionController = new SessionController();
            LoadSessions();
        }

        private void LoadSessions()
        {
            try
            {
                var sessionList = sessionController.GetAllSessions();
                Sessions = new ObservableCollection<Session>(sessionList);
                SessionsDataGrid.ItemsSource = Sessions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sessions: " + ex.Message);
            }
        }

        private void AddSession_Click(object sender, RoutedEventArgs e)
        {
            string sessionName = SessionNameTextBox.Text.Trim();
            DateTime? startDate = StartDatePicker.SelectedDate;
            DateTime? endDate = EndDatePicker.SelectedDate;

            if (!ValidationHelper.IsRequired(sessionName) || !startDate.HasValue || !endDate.HasValue)
            {
                MessageBox.Show("Please enter all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ValidationHelper.IsDigitsOnly(sessionName)) {
                MessageBox.Show("Please enter valid session", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateOnly start = DateOnly.FromDateTime(startDate.Value);
            DateOnly end = DateOnly.FromDateTime(endDate.Value);

            try
            {
                var newSession = sessionController.AddSession(sessionName, start, end);
                Sessions.Add(newSession); // Ensure AddSession returns the created object with ID
                SessionNameTextBox.Clear();
                StartDatePicker.SelectedDate = null;
                EndDatePicker.SelectedDate = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Operation failed: " + ex.Message);
            }
        }

        private void EditSession_Click(object sender, RoutedEventArgs e)
        {
            if (SessionsDataGrid.SelectedItem is Session session)
            {
                var editWindow = new EditSessionWindow(session);
                editWindow.ShowDialog();
            }
        }

        private void DeleteSession_Click(object sender, RoutedEventArgs e)
        {
            if (SessionsDataGrid.SelectedItem is Session session)
            {
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        sessionController.DeleteSession(session.SessionId);
                        Sessions.Remove(session);
                        MessageBox.Show("Session deleted.", "Success", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to delete session: " + ex.Message, "Delete Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
