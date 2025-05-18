using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamManagementSystem.Models
{
    public partial class Course : INotifyPropertyChanged
    {
        private int _courseId;
        private string? _courseName;
        private ICollection<Student> _students = new List<Student>();

        public int CourseId
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

        public string? CourseName
        {
            get => _courseName;
            set
            {
                if (_courseName != value)
                {
                    _courseName = value;
                    OnPropertyChanged(nameof(CourseName));
                    OnPropertyChanged(nameof(ToString)); // Optional: if UI binds to ToString()
                }
            }
        }

        public virtual ICollection<Student> Students
        {
            get => _students;
            set
            {
                if (_students != value)
                {
                    _students = value;
                    OnPropertyChanged(nameof(Students));
                }
            }
        }

        public override string ToString() => CourseName ?? string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
