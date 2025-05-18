using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamManagementSystem.Models
{
    public partial class Room : INotifyPropertyChanged
    {
        private int _roomId;
        private string? _roomNumber;
        private int? _capacity;

        public int RoomId
        {
            get => _roomId;
            set
            {
                if (_roomId != value)
                {
                    _roomId = value;
                    OnPropertyChanged(nameof(RoomId));
                }
            }
        }

        public string? RoomNumber
        {
            get => _roomNumber;
            set
            {
                if (_roomNumber != value)
                {
                    _roomNumber = value;
                    OnPropertyChanged(nameof(RoomNumber));
                }
            }
        }

        public int? Capacity
        {
            get => _capacity;
            set
            {
                if (_capacity != value)
                {
                    _capacity = value;
                    OnPropertyChanged(nameof(Capacity));
                }
            }
        }

        public override string ToString() => RoomNumber ?? string.Empty;


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
