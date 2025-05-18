using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamManagementSystem.Models
{
    public partial class Section : INotifyPropertyChanged
    {
        private int _sectionId;
        private string _sectionName = string.Empty;

        public int SectionId
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

        public string SectionName
        {
            get => _sectionName;
            set
            {
                if (_sectionName != value)
                {
                    _sectionName = value;
                    OnPropertyChanged(nameof(SectionName));
                }
            }
        }

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        public override string ToString() => SectionName;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
