using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;
using ExamManagementSystem.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ExamManagementSystem.views.AdmnViews
{
    public partial class SectionsManager : Page
    {
        private readonly SectionController _sectionController;

        public ObservableCollection<Section> Sections = new ObservableCollection<Section>();


        public SectionsManager()
        {
            InitializeComponent();
            _sectionController = new SectionController();
            LoadSections();
        }

        private void LoadSections()
        {
            var sections = _sectionController.GetAllSections();
            Sections = new ObservableCollection<Section>(sections);

            SectionsDataGrid.ItemsSource = Sections;
        }

        private void AddSection_Click(object sender, RoutedEventArgs e)
        {
            string sectionName = SectionNameTextBox.Text.Trim();

            if (!ValidationHelper.IsRequired(sectionName))
            {
                MessageBox.Show("Section name cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ValidationHelper.IsAlphabetic(sectionName))
            {
                MessageBox.Show("Please enter valid Section.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newsection = _sectionController.AddSection(sectionName);
            Sections.Add(newsection);
            SectionNameTextBox.Clear();
        }

        private void EditSection_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Section selectedSection)
            {
                var editWindow = new EditSectionWindow(selectedSection);
                editWindow.ShowDialog();
            }
        }

        private void DeleteSection_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Section selectedSection)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete section '{selectedSection.SectionName}'?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _sectionController.DeleteSection(selectedSection.SectionId);
                        Sections.Remove(selectedSection);
                        MessageBox.Show("Section deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to delete section: " + (ex.InnerException?.Message ?? ex.Message),
                            "Delete Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
            }
        }

    }
}
