using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamManagementSystem.Models
{
    public partial class Role : INotifyPropertyChanged
    {
        private int _roleId;
        private string _roleName = string.Empty;
        private ICollection<User> _users = new List<User>();

        public int RoleId
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

        public string RoleName
        {
            get => _roleName;
            set
            {
                if (_roleName != value)
                {
                    _roleName = value;
                    OnPropertyChanged(nameof(RoleName));
                    OnPropertyChanged(nameof(ToString)); // Optional: helps update UI if ToString() is used in binding
                }
            }
        }

        public virtual ICollection<User> Users
        {
            get => _users;
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }

        public override string ToString() => RoleName;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
