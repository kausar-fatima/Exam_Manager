using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamManagementSystem.Models
{
    public partial class Session : INotifyPropertyChanged
    {
        private int _sessionId;
        private string _sessionName = string.Empty;
        private DateOnly _startDate;
        private DateOnly _endDate;

        public int SessionId
        {
            get => _sessionId;
            set
            {
                if (_sessionId != value)
                {
                    _sessionId = value;
                    OnPropertyChanged(nameof(SessionId));
                }
            }
        }

        public string SessionName
        {
            get => _sessionName;
            set
            {
                if (_sessionName != value)
                {
                    _sessionName = value;
                    OnPropertyChanged(nameof(SessionName));
                }
            }
        }

        public DateOnly StartDate
        {
            get => _startDate;
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        public DateOnly EndDate
        {
            get => _endDate;
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        public override string ToString() => SessionName;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
