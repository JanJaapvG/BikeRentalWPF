using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BikeRental.Model
{

    public class Customer : INotifyPropertyChanged
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private Gender _gender;
        private string _email;
        private ObservableCollection<Reservation> _reservations;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                Notify("Id");
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                Notify("FirstName");
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                Notify("LastName");
            }
        }

        public Gender Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                Notify("Gender");
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                Notify("Email");
            }
        }

        //List with reservations of the customer itself.
        public virtual ObservableCollection<Reservation> Reservations
        {
            get => _reservations;
            set
            {
                _reservations = value;
                Notify("Reservations");
            }
        }

        public Store Store { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //Method for notifying changes in properties
        public void Notify(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Customer()
        {
            Reservations = new ObservableCollection<Reservation>();
        }

    }

}
