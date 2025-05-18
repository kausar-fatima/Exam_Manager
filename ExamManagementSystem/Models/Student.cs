using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamManagementSystem.Models
{
    public partial class Student : INotifyPropertyChanged
    {
        private int _studentId;
        private string? _name;
        private string? _rollNumber;
        private string? _cnic;
        private string? _address;
        private int? _age;
        private int? _sectionId;
        private int? _sessionId;
        private int? _courseId;

        public int StudentId
        {
            get => _studentId;
            set
            {
                if (_studentId != value)
                {
                    _studentId = value;
                    OnPropertyChanged(nameof(StudentId));
                }
            }
        }

        public string? Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string? RollNumber
        {
            get => _rollNumber;
            set
            {
                if (_rollNumber != value)
                {
                    _rollNumber = value;
                    OnPropertyChanged(nameof(RollNumber));
                }
            }
        }

        public string? Cnic
        {
            get => _cnic;
            set
            {
                if (_cnic != value)
                {
                    _cnic = value;
                    OnPropertyChanged(nameof(Cnic));
                }
            }
        }

        public string? Address
        {
            get => _address;
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged(nameof(Address));
                }
            }
        }

        public int? Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged(nameof(Age));
                }
            }
        }

        public int? SectionId
        {
            get => _sectionId;
            set
            {
                if (_sectionId != value)
                {
                    _sectionId = value;
                    OnPropertyChanged(nameof(SectionId));
                }
            }
        }

        public int? SessionId
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

        public int? CourseId
        {
            get => _courseId;
            set
            {
                if (_courseId != value)
                {
                    _courseId = value;
                    OnPropertyChanged(nameof(CourseId));
                }
            }
        }

        public virtual Course? Course { get; set; }
        public virtual Section? Section { get; set; }
        public virtual Session? Session { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
