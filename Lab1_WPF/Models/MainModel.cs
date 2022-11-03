using Lab1_WPF.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_WPF.Models
{
    //Реалізація паттерну Singleton
    //Та реалізація Model в паттерні MVVM
    public class MainModel 
    {
        public ObservableCollection<Employee> Employees { get; private set; }
        public ObservableCollection<Flight> Flights { get; private set; }

        private MainModel()
        {
            Employees = Extension.GetDefaultEmployees();
            Flights = Extension.GetDefaultFlights(Employees);
        }

        private static MainModel instance;
        public static MainModel Instance
        {
            get
            {
                if (instance == null)
                    instance = new MainModel();

                return instance;
            }
        }

        public void AddFlight()
        {
            Flight flight = new Flight();
            flight.ID = Flights.Last().ID + 1;
            flight.StartTime = DateTime.Now;
            Flights.Add(flight);
        }

        public void RemoveFlight(Flight flight)
        {
            Flights.Remove(flight);
        }

        public void AddEmployee()
        {
            Employee employee = new Employee();
            employee.ID = Employees.Last().ID + 1;
            Employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
            foreach (Flight flight in Flights)
            {
                flight.Employees.Remove(employee);
            }
        }

        public void AddEmployeeToFlight(Flight flight, Employee employee)
        {
            if (!flight.Employees.Contains(employee))
            {
                flight.Employees.Add(employee);
            }
        }

        public void RemoveEmployeeFromFlight(Flight flight, Employee employee)
        {
            flight.Employees.Remove(employee);
        }
    }
}
