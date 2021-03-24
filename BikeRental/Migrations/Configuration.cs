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
            context.Stores.AddOrUpdate(
                p => p.Name,
                new Store
                {
                    Id = 1,
                    Name = "Fietsenwinkel Almere",
                    Adress = "Fietslaan 1",
                    City = "Almere",
                    MaxCapacity = 1,
                    Bikes = new ObservableCollection<Bike>() {
                        new Bike
                            {
                                Name = "Sonic Bike",
                                Description = "Gotta Go Fast",
                                Brand = "Speed",
                                Type = Category.Racefiets,
                                BikeSize = BikeSize.Large,
                                Gender = Gender.Male,
                                HourRate = 7.50,
                                DailyRate = 14.75
                            }
                    }
                },
                new Store
                {
                    Name = "Fietsenwinkel Amsterdam",
                    Adress = "Lelylaan 2",
                    City = "Amsterdam",
                    MaxCapacity = 1,
                    Bikes = new ObservableCollection<Bike>()
                    {
                        new Bike()
                        {
                            Name = "Herenfiets",
                            Description = "Goede stadsfiest",
                            Brand = "Gazelle",
                            Type = Category.Stadsfiets,
                            BikeSize = BikeSize.Large,
                            Gender = Gender.Male,
                            HourRate = 5.50,
                            DailyRate = 12.75
                        },
                    }
                });
        }
    }
}


                    