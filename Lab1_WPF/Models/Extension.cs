using Lab1_WPF.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_WPF.Models
{
    public static class Extension
    {
        public static Employee GetFirstByPosition(this IEnumerable<Employee> employees, Position position, int i)
        {
            IEnumerable<Employee> array = employees.Where(x => x.Position == position);
            return array.FirstOrDefault();
        }

        public static Employee GetByPosition(this IEnumerable<Employee> employees, Position position, int i)
        {
            Employee[] array = employees.Where(x => x.Position == position).ToArray();

            if (array.Length > i)
            {
                return array[i];
            }

            return null;
        }

        public static ObservableCollection<Employee> GetDefaultEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            employees.Add(new Employee
            {
                ID = 1,
                FirstName = "Andrii",
                LastName = "Lepskyi",
                Position = Position.Pilot,
            });

            employees.Add(new Employee
            {
                ID = 2,
                FirstName = "Danylo",
                LastName = "Honcharenko",
                Position = Position.RadioOperator,
            });

            employees.Add(new Employee
            {
                ID = 3,
                FirstName = "Olekii",
                LastName = "Vernadskyi",
                Position = Position.Pilot,
            });

            employees.Add(new Employee
            {
                ID = 4,
                FirstName = "Vladyslav",
                LastName = "Sikorskyi",
                Position = Position.Navigator,
            });

            employees.Add(new Employee
            {
                ID = 5,
                FirstName = "Olena",
                LastName = "Naumenko",
                Position = Position.FlightAttendant,
            });

            employees.Add(new Employee
            {
                ID = 6,
                FirstName = "Iryna",
                LastName = "Honchrova",
                Position = Position.FlightAttendant,
            });

            return employees;
        }

        public static ObservableCollection<Flight> GetDefaultFlights(ObservableCollection<Employee> employees)
        {
            ObservableCollection<Flight> flights = new ObservableCollection<Flight>();
            Flight flight;

            flight = new Flight
            {
                ID = 1,
                CityFrom = "London",
                CityTo = "New York City",
                StartTime = new DateTime(2022, 1, 19, 2, 0, 0),
            };

            AddEmployee(flight, employees, Position.Pilot, 0);
            AddEmployee(flight, employees, Position.Pilot, 1);
            AddEmployee(flight, employees, Position.FlightAttendant, 0);
            AddEmployee(flight, employees, Position.RadioOperator, 0);
            flights.Add(flight);

            flight = new Flight
            {
                ID = 2,
                CityFrom = "Stockholm",
                CityTo = "Rome",
                StartTime = new DateTime(2022, 1, 20, 2, 0, 0),
            };

            AddEmployee(flight, employees, Position.Pilot, 0);
            AddEmployee(flight, employees, Position.Pilot, 1);
            AddEmployee(flight, employees, Position.FlightAttendant, 0);
            AddEmployee(flight, employees, Position.FlightAttendant, 1);

            flights.Add(flight);

            flight = new Flight
            {
                ID = 3,
                CityFrom = "Berlin",
                CityTo = "Paris",
                StartTime = new DateTime(2022, 1, 21, 2, 0, 0),
            };

            AddEmployee(flight, employees, Position.Pilot, 0);
            AddEmployee(flight, employees, Position.Pilot, 1);
            AddEmployee(flight, employees, Position.Navigator, 0);
            AddEmployee(flight, employees, Position.FlightAttendant, 0);

            flights.Add(flight);

            return flights;
        }

        private static void AddEmployee(Flight flight, IEnumerable<Employee> employees, Position position, int i)
        {
            flight.Employees.Add(employees.GetByPosition(position, i));
        }
    }
}
