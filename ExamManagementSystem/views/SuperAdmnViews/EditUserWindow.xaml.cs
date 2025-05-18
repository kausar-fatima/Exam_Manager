using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;
using ExamManagementSystem.Models;

namespace ExamManagementSystem.views
{
    public partial class EditUserWindow : Window
    {
        private readonly UserController _userController;
        private readonly RoleController _roleController;
        private User? _user;

        public EditUserWindow(User user)
        {
            InitializeComponent();
            _user = user;
            _userController = new UserController();
            LoadUserData();
            _roleController = new RoleController();
            LoadRoles();
        }

        private void LoadUserData()
        {
            if (_user != null)
            {
                UsernameTextBox.Text = _user.Username;
                PasswordBox.Password = "";
                RoleComboBox.SelectedItem = RoleComboBox.Items
                    .Cast<ComboBoxItem>()
                    .FirstOrDefault(i => i.Content.ToString() == _user.Role);
            }
        }

        private void LoadRoles()
        {
            var roles = _roleController.GetSpecificRolesOnly();
            RoleComboBox.ItemsSource = roles;
        }


        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password;
            string? role = (RoleComboBox.SelectedItem as Role)?.RoleName;

            if (!ValidationHelper.IsRequired(username) || !ValidationHelper.IsRequired(password) || !ValidationHelper.IsRequired(role!))
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ValidationHelper.IsValidUsername(username))
            {
                MessageBox.Show("Please enter valid username", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ValidationHelper.IsValidPassword(password))
            {
                MessageBox.Show("Please enter valid password", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Hash the password before storing it in the database
            string hashedPassword = Utils.PasswordHasher.HashPassword(password);


            _userController.UpdateUser(_user!.UserId, username, hashedPassword, role);
            _user.Username = username;
            _user.PasswordHash = hashedPassword;
            _user.Role = role;

            MessageBox.Show("User Updated Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }

        private bool isPasswordVisible = false;

        private void TogglePasswordVisibility_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                PasswordTextBox.Text = PasswordBox.Password;
                PasswordTextBox.Visibility = Visibility.Visible;
                PasswordBox.Visibility = Visibility.Collapsed;
                TogglePasswordVisibility.Source = new BitmapImage(new Uri("pack://application:,,,/Images/eye-off.png"));
            }
            else
            {
                PasswordBox.Password = PasswordTextBox.Text;
                PasswordTextBox.Visibility = Visibility.Collapsed;
                PasswordBox.Visibility = Visibility.Visible;
                TogglePasswordVisibility.Source = new BitmapImage(new Uri("pack://application:,,,/Images/eye.png"));
            }
        }
    }
}
