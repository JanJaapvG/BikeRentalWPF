namespace BikeRental.Migrations
{
    using BikeRental.Model;
    using System;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BikeRental.Model.BikeRentalModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BikeRentalModel context)
        {
            var bike1 = new Bike
            {
                Name = "Sonic Bike",
                Description = "Gotta Go Fast",
                Brand = "Speed",
                Type = Category.Racefiets,
                BikeSize = BikeSize.Large,
                Gender = Gender.Male,
                HourRate = 7.50,
                DailyRate = 14.75
            };

            var bike2 = new Bike
            {
                Name = "Herenfiets",
                Description = "Goede stadsfiets",
                Brand = "Gazelle",
                Type = Category.Stadsfiets,
                BikeSize = BikeSize.Large,
                Gender = Gender.Male,
                HourRate = 5.50,
                DailyRate = 12.75
            };

            var bike3 = new Bike
            {
                Name = "Damesfiets",
                Description = "Goede stadsfiets",
                Brand = "Gazelle",
                Type = Category.Elektrischefiets,
                BikeSize = BikeSize.Large,
                Gender = Gender.Female,
                HourRate = 5.50,
                DailyRate = 12.75
            };

            var bike4 = new Bike
            {
                Name = "Cubernettes",
                Description = "Voor waaghalzen",
                Brand = "Cube",
                Type = Category.Mountainbike,
                BikeSize = BikeSize.Large,
                Gender = Gender.Male,
                HourRate = 5.50,
                DailyRate = 12.75
            };

            var bike5 = new Bike
            {
                Name = "RubyOnRails",
                Description = "Voor avonturiers",
                Brand = "Cube",
                Type = Category.Mountainbike,
                BikeSize = BikeSize.Large,
                Gender = Gender.Female,
                HourRate = 5.50,
                DailyRate = 12.75
            };

            var customer1 = new Customer
            {
                Id = 1,
                FirstName = "Appie",
                LastName = "Heijn",
                Gender = Gender.Male,
                Email = "Appie@Heijn.nl",
            };

            var customer2 = new Customer
            {
                Id = 2,
                FirstName = "Celine",
                LastName = "Duizend",
                Gender = Gender.Female,
                Email = "Celine@Duizend.nl",
            };

            var customer3 = new Customer
            {
                Id = 3,
                FirstName = "Jum",
                LastName = "Beau",
                Gender = Gender.Female,
                Email = "Jum@Beau.nl",
            };

            var store1 = new Store
            {
                Id = 1,
                Name = "Fietsenwinkel Almere",
                Adress = "Fietslaan 1",
                City = "Almere",
                MaxCapacity = 1,
                Bikes = new ObservableCollection<Bike>() { bike1 }
            };

            var store2 = new Store
            {
                Id = 2,
                Name = "Fietsenwinkel Amsterdam",
                Adress = "Lelylaan 2",
                City = "Amsterdam",
                MaxCapacity = 1,
                Bikes = new ObservableCollection<Bike>() { bike2 }
            };

            var store3 = new Store
            {
                Id = 3,
                Name = "Profile Nijmegen",
                Adress = "Groesbeekseweg 2",
                City = "Nijmegen",
                MaxCapacity = 1,
                Bikes = new ObservableCollection<Bike>() { bike3, bike4, bike5 }
            };

            var reservation1 = new Reservation {
                Start = new DateTime(2021, 03, 30, 13, 45, 00),
                End = new DateTime(2021, 04, 04, 13, 45, 00),
                TotalPrice = 65.00,
                Bike = bike1,
                Customer = customer1,
                DropoffStore = store1,
                PickupStore = store1
            };

            var reservation2 = new Reservation
            {
                Start = new DateTime(2021, 03, 30, 13, 45, 00),
                End = new DateTime(2021, 04, 04, 13, 45, 00),
                TotalPrice = 65.00,
                Bike = bike2,
                Customer = customer2,
                DropoffStore = store2,
                PickupStore = store2
            };

            store1.Reservations.Add(reservation1);
            store1.Customers.Add(customer1);
            store2.Reservations.Add(reservation2);
            store2.Customers.Add(customer2);
            store3.Customers.Add(customer3);

            context.Stores.AddOrUpdate(
                n => n.Name,
                store1,
                store2,
                store3
                );

            context.Customers.AddOrUpdate(
                p => p.Email,
                customer1,
                customer2,
                customer3
                );
        }
    }
}


                    