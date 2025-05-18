using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;

namespace ExamManagementSystem.views
{
    public partial class SignupWindow : Window
    {
        private readonly UserController _userController;

        public SignupWindow()
        {
            InitializeComponent();
            _userController = new UserController();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;
            string? role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (!ValidationHelper.IsRequired(username) || !ValidationHelper.IsRequired(password) || !ValidationHelper.IsRequired(confirmPassword) || !ValidationHelper.IsRequired(role!))
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ValidationHelper.IsValidUsername(username))
            {
                MessageBox.Show("Please enter valid username", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ValidationHelper.IsValidPassword(password)) {
                MessageBox.Show("Please enter valid password", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Hash the password before storing it in the database
            string hashedPassword = Utils.PasswordHasher.HashPassword(password);

            // Call UserController to add the user with the hashed password
            _userController.AddUser(username, hashedPassword, role);
            MessageBox.Show("Account Created Successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            // Move to Login Page
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();

        }

        private bool isPasswordVisible = false;
        private bool isConfirmVisible = false;

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

        private void ToggleConfirmVisibility_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isConfirmVisible = !isConfirmVisible;

            if (isConfirmVisible)
            {
                ConfirmTextBox.Text = ConfirmPasswordBox.Password;
                ConfirmTextBox.Visibility = Visibility.Visible;
                ConfirmPasswordBox.Visibility = Visibility.Collapsed;
                ToggleConfirmVisibility.Source = new BitmapImage(new Uri("pack://application:,,,/Images/eye-off.png"));
            }
            else
            {
                ConfirmPasswordBox.Password = ConfirmTextBox.Text;
                ConfirmTextBox.Visibility = Visibility.Collapsed;
                ConfirmPasswordBox.Visibility = Visibility.Visible;
                ToggleConfirmVisibility.Source = new BitmapImage(new Uri("pack://application:,,,/Images/eye.png"));
            }
        }


        private void LoginHyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Handle login redirection
            // Move to Login Page
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

            this.Close();
        }
    }
}
