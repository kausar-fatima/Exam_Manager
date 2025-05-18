using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ExamManagementSystem.Controllers;
using ExamManagementSystem.Models;
using ExamManagementSystem.Helpers;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace ExamManagementSystem.views
{
    public partial class LoginWindow : Window
    {
        private readonly AppDbContext _context;

        public LoginWindow()
        {
            InitializeComponent();
            _context = new AppDbContext();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password;

            if (!ValidationHelper.IsRequired(username) || !ValidationHelper.IsRequired(password))
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

            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user != null && Utils.PasswordHasher.VerifyPassword(password, user.PasswordHash))
            {
                // Set Session
                SessionManager.UserId = user.UserId;
                SessionManager.Username = user.Username;
                SessionManager.Role = user.Role;

                MessageBox.Show($"Welcome, {user.Role}!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                var dashboard = new DashboardWindow(); // Open Dashboard next
                dashboard.Show();

                this.Close();

            }
            else
            {
                MessageBox.Show("Invalid credentials. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

        private void SignupHyperlink_Click(object sender, RoutedEventArgs e) {
            var signUp = new SignupWindow(); // Open Dashboard next
            signUp.Show();
            this.Close();
        }
    }
}
