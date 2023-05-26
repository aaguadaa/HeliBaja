namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class heli : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id_Booking = c.Int(nullable: false, identity: true),
                        Id_Client = c.Int(nullable: false),
                        Id_Flight = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        TourDate = c.DateTime(nullable: false),
                        PaymentMethod = c.String(),
                        PaymentStatus = c.String(),
                        BookingStatus = c.String(),
                        Admin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id_Booking)
                .ForeignKey("dbo.Clients", t => t.Id_Client, cascadeDelete: true)
                .ForeignKey("dbo.Flights", t => t.Id_Flight, cascadeDelete: true)
                .ForeignKey("dbo.Admins", t => t.Admin_Id)
                .Index(t => t.Id_Client)
                .Index(t => t.Id_Flight)
                .Index(t => t.Admin_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id_Client = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        APaterno = c.String(),
                        AMaterno = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id_Client);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id_Flight = c.Int(nullable: false, identity: true),
                        NumeroVuelo = c.String(),
                        Status = c.String(),
                        Origen = c.String(),
                        Destino = c.String(),
                        HoraSalida = c.DateTime(nullable: false),
                        HoraLlegada = c.DateTime(nullable: false),
                        PilotId = c.Int(nullable: false),
                        Admin_Id = c.Int(),
                        Pilots_Id_Pilot = c.Int(),
                    })
                .PrimaryKey(t => t.Id_Flight)
                .ForeignKey("dbo.Admins", t => t.Admin_Id)
                .ForeignKey("dbo.Pilots", t => t.Pilots_Id_Pilot)
                .Index(t => t.Admin_Id)
                .Index(t => t.Pilots_Id_Pilot);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id_Inventory = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Amount = c.Int(nullable: false),
                        Available = c.Boolean(nullable: false),
                        AdminInventory = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Admin_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id_Inventory)
                .ForeignKey("dbo.Admins", t => t.Admin_Id)
                .Index(t => t.Admin_Id);
            
            CreateTable(
                "dbo.Tools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Inventory_Id_Inventory = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inventories", t => t.Inventory_Id_Inventory)
                .Index(t => t.Inventory_Id_Inventory);
            
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        Id_Agenda = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Id_Pilot = c.Int(nullable: false),
                        Id_Flight = c.Int(nullable: false),
                        Itinerary = c.String(),
                    })
                .PrimaryKey(t => t.Id_Agenda)
                .ForeignKey("dbo.Flights", t => t.Id_Flight, cascadeDelete: true)
                .ForeignKey("dbo.Pilots", t => t.Id_Pilot, cascadeDelete: true)
                .Index(t => t.Id_Pilot)
                .Index(t => t.Id_Flight);
            
            CreateTable(
                "dbo.Pilots",
                c => new
                    {
                        Id_Pilot = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        APaterno = c.String(),
                        AMaterno = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id_Pilot);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        APaterno = c.String(),
                        AMaterno = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        UserType = c.Int(nullable: false),
                        PilotId = c.Int(),
                        ClientId = c.Int(),
                        Cliente_Id_Client = c.Int(),
                        Piloto_Id_Pilot = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Cliente_Id_Client)
                .ForeignKey("dbo.Pilots", t => t.Piloto_Id_Pilot)
                .Index(t => t.Cliente_Id_Client)
                .Index(t => t.Piloto_Id_Pilot);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Piloto_Id_Pilot", "dbo.Pilots");
            DropForeignKey("dbo.Users", "Cliente_Id_Client", "dbo.Clients");
            DropForeignKey("dbo.Flights", "Pilots_Id_Pilot", "dbo.Pilots");
            DropForeignKey("dbo.Agenda", "Id_Pilot", "dbo.Pilots");
            DropForeignKey("dbo.Agenda", "Id_Flight", "dbo.Flights");
            DropForeignKey("dbo.Inventories", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.Tools", "Inventory_Id_Inventory", "dbo.Inventories");
            DropForeignKey("dbo.Flights", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.Bookings", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.Bookings", "Id_Flight", "dbo.Flights");
            DropForeignKey("dbo.Bookings", "Id_Client", "dbo.Clients");
            DropIndex("dbo.Users", new[] { "Piloto_Id_Pilot" });
            DropIndex("dbo.Users", new[] { "Cliente_Id_Client" });
            DropIndex("dbo.Agenda", new[] { "Id_Flight" });
            DropIndex("dbo.Agenda", new[] { "Id_Pilot" });
            DropIndex("dbo.Tools", new[] { "Inventory_Id_Inventory" });
            DropIndex("dbo.Inventories", new[] { "Admin_Id" });
            DropIndex("dbo.Flights", new[] { "Pilots_Id_Pilot" });
            DropIndex("dbo.Flights", new[] { "Admin_Id" });
            DropIndex("dbo.Bookings", new[] { "Admin_Id" });
            DropIndex("dbo.Bookings", new[] { "Id_Flight" });
            DropIndex("dbo.Bookings", new[] { "Id_Client" });
            DropTable("dbo.Users");
            DropTable("dbo.Pilots");
            DropTable("dbo.Agenda");
            DropTable("dbo.Tools");
            DropTable("dbo.Inventories");
            DropTable("dbo.Flights");
            DropTable("dbo.Clients");
            DropTable("dbo.Bookings");
            DropTable("dbo.Admins");
        }
    }
}
