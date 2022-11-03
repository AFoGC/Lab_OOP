using Lab1_WPF.Entity;
using Lab1_WPF.Models;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Lab1_WPF.ViewModels
{
    //Реалызація View-Model в паттерні MVVM
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly MainModel model;
        public ObservableCollection<Employee> Employees => model.Employees;
        public ObservableCollection<Flight> Flights => model.Flights;
        public IEnumerable Positions { get; private set; }

        public MainViewModel()
        {
            model = MainModel.Instance;
            Positions = Enum.GetValues(typeof(Position)).Cast<Position>();
        }

        private RelayCommand _addFlight;
        public RelayCommand AddFlight
        {
            get
            {
                return _addFlight ??
                (_addFlight = new RelayCommand(obj =>
                {
                    model.AddFlight();
                }));
            }
        }

        private RelayCommand _removeFlight;
        public RelayCommand RemoveFlight
        {
            get
            {
                return _removeFlight ??
                (_removeFlight = new RelayCommand(obj =>
                {
                    model.RemoveFlight(SelectedFlight);
                    SelectedFlight = null;
                }));
            }
        }

        private RelayCommand _addEmployee;
        public RelayCommand AddEmployee
        {
            get
            {
                return _addEmployee ??
                (_addEmployee = new RelayCommand(obj =>
                {
                    model.AddEmployee();
                }));
            }
        }

        private RelayCommand _removeEmployee;
        public RelayCommand RemoveEmployee
        {
            get
            {
                return _removeEmployee ??
                (_removeEmployee = new RelayCommand(obj =>
                {
                    model.RemoveEmployee(SelectedEmployee);
                    SelectedEmployee = null;
                }));
            }
        }

        private RelayCommand _addEmployeeToFlight;
        public RelayCommand AddEmployeeToFlight
        {
            get
            {
                return _addEmployeeToFlight ??
                (_addEmployeeToFlight = new RelayCommand(obj =>
                {
                    model.AddEmployeeToFlight(SelectedFlight, SelectedEmployee);
                }));
            }
        }

        private RelayCommand _removeEmployeeFromFlight;
        public RelayCommand RemoveEmployeeFromFlight
        {
            get
            {
                return _removeEmployeeFromFlight ??
                (_removeEmployeeFromFlight = new RelayCommand(obj =>
                {
                    model.RemoveEmployeeFromFlight(SelectedFlight, SelectedEmployee);
                }));
            }
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        private Flight _selectedFlight;
        public Flight SelectedFlight
        {
            get => _selectedFlight;
            set
            {
                _selectedFlight = value;

                if (_selectedFlight != null)
                    FlightEmployees = _selectedFlight.Employees;

                else FlightEmployees = null;

                OnPropertyChanged();
            }
        }

        private ObservableCollection<Employee> _flightEmployees;
        public ObservableCollection<Employee> FlightEmployees
        {
            get => _flightEmployees;
            set
            {
                _flightEmployees = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
    }
}
