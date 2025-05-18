using System.Windows;
using System.Windows.Controls;
using ExamManagementSystem.Helpers;
using ExamManagementSystem.views.SuperAdmnViews;
using ExamManagementSystem.views.AdmnViews;
using ExamManagementSystem.views.ClerkViews;

namespace ExamManagementSystem.views
{
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
            SetupDashboard();
            MainContentFrame.Navigate(new WelcomePage());
        }

        private void SetupDashboard()
        {
            WelcomeTextBlock.Text = "Exam Management System";

            switch (SessionManager.Role)
            {
                case "SuperAdmin":
                    SuperAdminPanel.Visibility = Visibility.Visible;
                    break;
                case "Admin":
                    AdminPanel.Visibility = Visibility.Visible;
                    break;
                case "Clerk":
                    ClerkPanel.Visibility = Visibility.Visible;
                    break;
                default:
                    MessageBox.Show("Unknown Role Detected!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string pageName)
            {
                switch (pageName)
                {
                    case "UsersPage":
                        MainContentFrame.Navigate(new UserManager());
                        break;
                    case "RolesPage":
                        MainContentFrame.Navigate(new RoleManager());
                        break;
                    case "BatchsPage":
                        MainContentFrame.Navigate(new BatchManager());
                        break;
                    case "RoomsPage":
                        MainContentFrame.Navigate(new RoomManager());
                        break;
                    case "SchedulePlansPage":
                        MainContentFrame.Navigate(new ScheduleManager());
                        break;
                    //case "StudentsPage":
                    //    MainContentFrame.Navigate(new StudentsPage());
                    //    break;
                    //case "SeatingPlansPage":
                    //    MainContentFrame.Navigate(new SeatingPlansPage());
                    //    break;
                    //case "AttendanceSheetsPage":
                    //    MainContentFrame.Navigate(new AttendanceSheetsPage());
                    //    break;
                    default:
                        MessageBox.Show("Unknown page.", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                }
            }
        }


        //private void ManageRoles_Click(object sender, RoutedEventArgs e)
        //{
        //    RoleManager rolesWindow = new RoleManager();
        //    rolesWindow.Show();
        //}

        //private void ManageUsers_Click(object sender, RoutedEventArgs e)
        //{
        //    SuperAdminDashboardWindow usersWindow = new SuperAdminDashboardWindow();
        //    usersWindow.Show();
        //}

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Clear Session
            SessionManager.Clear();
            MessageBox.Show("Logged out successfully.", "Logout", MessageBoxButton.OK, MessageBoxImage.Information);

            // Return to Login
            var loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
