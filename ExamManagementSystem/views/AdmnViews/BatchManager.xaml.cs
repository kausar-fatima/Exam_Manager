using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamManagementSystem.views.AdmnViews
{
    /// <summary>
    /// Interaction logic for BatchManager.xaml
    /// </summary>
    public partial class BatchManager : Page
    {
        public BatchManager()
        {
            InitializeComponent();
            ContentFrame.Navigate(new CoursesManager());

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContentFrame == null) return;

            switch (((TabControl)sender).SelectedIndex)
            {
                case 0:
                    ContentFrame.Navigate(new CoursesManager());
                    break;
                case 1:
                    ContentFrame.Navigate(new SectionsManager());
                    break;
                case 2:
                    ContentFrame.Navigate(new SessionsManager());
                    break;
                case 3:
                    ContentFrame.Navigate(new StudentsManager());
                    break;
            }
        }

    }
}
