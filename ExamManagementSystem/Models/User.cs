using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamManagementSystem.Models
{
    public partial class User : INotifyPropertyChanged
    {
        private int _userId;
        private string _username = string.Empty;
        private string _passwordHash = string.Empty;
        private string _role = string.Empty;
        private int? _roleId;
        private Role? _roleNavigation;

        public int UserId
        {
            get => _userId;
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged(nameof(UserId));
                }
            }
        }

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string PasswordHash
        {
            get => _passwordHash;
            set
            {
                if (_passwordHash != value)
                {
                    _passwordHash = value;
                    OnPropertyChanged(nameof(PasswordHash));
                }
            }
        }

        public string Role
        {
            get => _role;
            set
            {
                if (_role != value)
                {
                    _role = value;
                    OnPropertyChanged(nameof(Role));
                }
            }
        }

        public int? RoleId
        {
            get => _roleId;
            set
            {
                if (_roleId != value)
                {
                    _roleId = value;
                    OnPropertyChanged(nameof(RoleId));
                }
            }
        }

        public Role? RoleNavigation
        {
            get => _roleNavigation;
            set
            {
                if (_roleNavigation != value)
                {
                    _roleNavigation = value;
                    OnPropertyChanged(nameof(RoleNavigation));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
