using System;

namespace Lab1_WPF.Entity
{
    public class Employee : BaseEntity
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private Position _position;

        public int ID 
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public String FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public String LastName 
        { 
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public Position Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged();
            }
        }
    }
}
