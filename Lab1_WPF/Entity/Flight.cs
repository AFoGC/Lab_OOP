using System;
using System.Collections.ObjectModel;

namespace Lab1_WPF.Entity
{
    public class Flight : BaseEntity
    {
        private int _id;
        private string _cityFrom;
        private string _cityTo;
        private DateTime _startTime;
        private ObservableCollection<Employee> employees;

        public Flight()
        {
            employees = new ObservableCollection<Employee>();
        }

        public int ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public String CityFrom
        {
            get => _cityFrom;
            set
            {
                _cityFrom = value;
                OnPropertyChanged();
            }
        }

        public String CityTo
        {
            get => _cityTo;
            set
            {
                _cityTo = value;
                OnPropertyChanged();
            }
        }

        public DateTime StartTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Employee> Employees => employees;
    }
}
