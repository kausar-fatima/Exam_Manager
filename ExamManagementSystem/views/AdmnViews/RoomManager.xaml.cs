using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ExamManagementSystem.Controllers;
using ExamManagementSystem.Helpers;
using ExamManagementSystem.Models;

namespace ExamManagementSystem.views.AdmnViews
{
    public partial class RoomManager : Page
    {
        private readonly RoomController roomController = new RoomController();
        public ObservableCollection<Room> Rooms { get; set; } = new ObservableCollection<Room>();

        public RoomManager()
        {
            InitializeComponent();
            LoadRooms();
        }

        private void LoadRooms()
        {
            try
            {
                var roomList = roomController.GetAllRooms();
                Rooms = new ObservableCollection<Room>(roomList);
                RoomDataGrid.ItemsSource = Rooms;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rooms: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            string roomNumber = RoomNumberTextBox.Text.Trim();
            bool capacityValid = int.TryParse(CapacityTextBox.Text.Trim(), out int capacity);

            if (!ValidationHelper.IsRequired(roomNumber) || !ValidationHelper.IsRequired(capacity.ToString()))
            {
                MessageBox.Show("Room number and capacity can not be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!ValidationHelper.IsPositiveNumber(capacity.ToString()))
            {
                MessageBox.Show("Please enter a valid capacity.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var addedRoom = roomController.AddRoom(roomNumber, capacity);
                Rooms.Add(addedRoom); // Assumes AddRoom returns Room object
                RoomNumberTextBox.Clear();
                CapacityTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add room: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is Room room)
            {
                if (MessageBox.Show($"Are you sure you want to delete Room {room.RoomNumber}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        roomController.DeleteRoom(room.RoomId);
                        Rooms.Remove(room);
                        MessageBox.Show("Room deleted successfully.", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to delete room: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void UpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (RoomDataGrid.SelectedItem is Room selectedRoom)
            {
                var editWindow = new EditRoomWindow(selectedRoom);
                editWindow.ShowDialog();
            }
        }
    }
}
