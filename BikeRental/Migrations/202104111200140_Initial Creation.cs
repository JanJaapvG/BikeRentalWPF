namespace BikeRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Brand = c.String(),
                        HourRate = c.Double(nullable: false),
                        DailyRate = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        BikeSize = c.Int(nullable: false),
                        Store_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.Store_Id)
                .Index(t => t.Store_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        Email = c.String(),
                        Store_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.Store_Id)
                .Index(t => t.Store_Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Bike_Id = c.Int(),
                        Customer_Id = c.Int(),
                        Store_Id = c.Int(),
                        DropoffStore_Id = c.Int(),
                        PickupStore_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bikes", t => t.Bike_Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Stores", t => t.Store_Id)
                .ForeignKey("dbo.Stores", t => t.DropoffStore_Id)
                .ForeignKey("dbo.Stores", t => t.PickupStore_Id)
                .Index(t => t.Bike_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Store_Id)
                .Index(t => t.DropoffStore_Id)
                .Index(t => t.PickupStore_Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                        City = c.String(),
                        MaxCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "PickupStore_Id", "dbo.Stores");
            DropForeignKey("dbo.Reservations", "DropoffStore_Id", "dbo.Stores");
            DropForeignKey("dbo.Reservations", "Store_Id", "dbo.Stores");
            DropForeignKey("dbo.Customers", "Store_Id", "dbo.Stores");
            DropForeignKey("dbo.Bikes", "Store_Id", "dbo.Stores");
            DropForeignKey("dbo.Reservations", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Reservations", "Bike_Id", "dbo.Bikes");
            DropIndex("dbo.Reservations", new[] { "PickupStore_Id" });
            DropIndex("dbo.Reservations", new[] { "DropoffStore_Id" });
            DropIndex("dbo.Reservations", new[] { "Store_Id" });
            DropIndex("dbo.Reservations", new[] { "Customer_Id" });
            DropIndex("dbo.Reservations", new[] { "Bike_Id" });
            DropIndex("dbo.Customers", new[] { "Store_Id" });
            DropIndex("dbo.Bikes", new[] { "Store_Id" });
            DropTable("dbo.Stores");
            DropTable("dbo.Reservations");
            DropTable("dbo.Customers");
            DropTable("dbo.Bikes");
        }
    }
}
