using System.Threading.Tasks;
using System.Windows;
using ExamManagementSystem.views;

namespace ExamManagementSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(2000); // 2-second delay for splash effect

            SignupWindow signupWindow = new SignupWindow();
            signupWindow.Show();

            this.Close(); // Close splash screen
        }
    }
}
