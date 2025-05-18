using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

// Alias to resolve ambiguity between System.Windows.Documents.Section and your Section model
using MySection = ExamManagementSystem.Models.Section;

namespace ExamManagementSystem.views.AdmnViews
{
    /// <summary>
    /// Interaction logic for EditSectionWindow.xaml
    /// </summary>
    public partial class EditSectionWindow : Window
    {
        private MySection? _Section;
        private readonly SectionController _SectionController;

        public EditSectionWindow(MySection Section)
        {
            InitializeComponent();
            _Section = Section;
            _SectionController = new SectionController();
            LoadSectionData();
        }

        private void LoadSectionData()
        {
            if (_Section != null)
            {
                SectionTextBox.Text = _Section.SectionName;
            }
        }

        private void UpdateSection_Click(object sender, RoutedEventArgs e)
        {
            string newSectionName = SectionTextBox.Text.Trim();
            if (!ValidationHelper.IsRequired(newSectionName))
            {
                MessageBox.Show("Section name cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ValidationHelper.IsAlphabetic(newSectionName))
            {
                MessageBox.Show("Please enter valid Section.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (newSectionName != _Section!.SectionName)
            {
                _Section.SectionName = newSectionName;
                _SectionController.UpdateSection(_Section.SectionId, newSectionName);
                MessageBox.Show($"Section updated to: {newSectionName}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No changes made. Section name is the same.", "No Change", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
