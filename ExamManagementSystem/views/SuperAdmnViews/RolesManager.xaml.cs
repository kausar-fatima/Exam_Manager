using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;
using ExamManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace ExamManagementSystem.views.SuperAdmnViews
{
    /// <summary>
    /// Interaction logic for RoleManager.xaml
    /// </summary>
    public partial class RoleManager : Page
    {
        private readonly RoleController _roleController;
        public ObservableCollection<Role> Roles = new ObservableCollection<Role>();


        public RoleManager()
        {
            InitializeComponent();
            _roleController = new RoleController();
            LoadRoles();
        }

        private void LoadRoles()
        {
            var roles = _roleController.GetAllRoles();
            Roles = new ObservableCollection<Role>(roles);
            RolesDataGrid.ItemsSource = Roles;
        }

        private void AddRole_Click(object sender, RoutedEventArgs e)
        {
            string name = RoleNameTextBox.Text.Trim();
            if (!ValidationHelper.IsRequired(name))
            {
                MessageBox.Show("Please fill the field", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!ValidationHelper.IsAlphabetic(name)) {
                MessageBox.Show("Please enter valid role", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newrole = _roleController.AddRole(name);
            Roles.Add(newrole);
            RoleNameTextBox.Clear();
        }

        private void UpdateRole_Click(object sender, RoutedEventArgs e)
        {
            if (RolesDataGrid.SelectedItem is Role selectedRole)
            {
                EditRoleWindow editWindow = new EditRoleWindow(selectedRole);
                editWindow.ShowDialog();
            }
        }

        private void DeleteRole_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null && button.Tag is Role role)
            {
                var result = MessageBox.Show(
                    $"Are you sure you want to delete role '{role.RoleName}'?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _roleController.DeleteRole(role.RoleId);
                        Roles.Remove(role);
                        MessageBox.Show("Role deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to delete role: " + (ex.InnerException?.Message ?? ex.Message),
                            "Delete Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
            }
        }

    }
}
