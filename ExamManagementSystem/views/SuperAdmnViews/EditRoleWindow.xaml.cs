using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;
using ExamManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for EditRoleWindow.xaml
    /// </summary>
    public partial class EditRoleWindow : Window
    {
        private Role? _role;
        private readonly RoleController _roleController;

        public EditRoleWindow(Role role)
        {
            InitializeComponent();
            _role = role;
            _roleController = new RoleController();
            LoadRoleData();
        }

        private void LoadRoleData()
        {
            if(_role != null)
            {
                RoleTextBox.Text = _role.RoleName;
            }
        }

        private void UpdateRole_Click(object sender, RoutedEventArgs e) {
            string newRoleName = RoleTextBox.Text.Trim();
            if (!ValidationHelper.IsRequired(newRoleName))
            {
                MessageBox.Show("Role can not be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!ValidationHelper.IsAlphabetic(newRoleName))
            {
                MessageBox.Show("You must enter a valid role name", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            newRoleName = newRoleName.Trim();

            if (newRoleName != _role!.RoleName)
            {
                _role.RoleName = newRoleName;
                _roleController.UpdateRole(_role.RoleId, newRoleName);
                MessageBox.Show($"Role updated to: {newRoleName}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No changes made. Role name is the same.", "No Change", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
