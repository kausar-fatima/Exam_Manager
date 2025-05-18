using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;
using ExamManagementSystem.Models;
using System.Windows;

namespace ExamManagementSystem.views.AdmnViews
{
    public partial class EditRoomWindow : Window
    {
        private Room _room;
        private readonly RoomController _roomController;

        public EditRoomWindow(Room room)
        {
            InitializeComponent();
            _room = room;
            _roomController = new RoomController();
            LoadRoomData();
        }

        private void LoadRoomData()
        {
            RoomNumberTextBox.Text = _room.RoomNumber;
            CapacityTextBox.Text = _room.Capacity.ToString();
        }

        private void UpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            string newRoomNumber = RoomNumberTextBox.Text.Trim();
            bool newCapacity = int.TryParse(CapacityTextBox.Text.Trim(), out int capacity);
            if (!ValidationHelper.IsRequired(newRoomNumber) || !ValidationHelper.IsRequired(capacity.ToString()))
            {
                MessageBox.Show("Room number and capacity can not be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ValidationHelper.IsPositiveNumber(capacity.ToString()))
            {
                MessageBox.Show("Please enter a valid capacity.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool isChanged = newRoomNumber != _room.RoomNumber || capacity != _room.Capacity;

            if (isChanged)
            {
                _room.RoomNumber = newRoomNumber;
                _room.Capacity = capacity;
                _roomController.UpdateRoom(_room.RoomId, newRoomNumber, capacity);

                MessageBox.Show($"Room updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("No changes detected.", "No Change", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
