using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;
using ExamManagementSystem.Models;

namespace ExamManagementSystem.views.SuperAdmnViews

{
    public partial class UserManager : Page
    {
        private readonly UserController _userController;
        public ObservableCollection<User> Users = new ObservableCollection<User>();

        public UserManager()
        {
            InitializeComponent();
            _userController = new UserController();
            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = _userController.GetAllUsersExcept(SessionManager.UserId);
            Users = new ObservableCollection<User>(users);
            UsersDataGrid.ItemsSource = Users;
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {   
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                EditUserWindow editWindow = new EditUserWindow(selectedUser);
                editWindow.ShowDialog();
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete user '{selectedUser.Username}'?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _userController.DeleteUser(selectedUser.UserId);
                        Users.Remove(selectedUser);
                        MessageBox.Show("User deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to delete user: " + (ex.InnerException?.Message ?? ex.Message),
                            "Delete Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
            }
        }

    }
}
