namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migstart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        GuaAbout = c.String(),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Description = c.String(),
                        Admin = c.String(maxLength: 100),
                        Image = c.String(maxLength: 100),
                        DateAct = c.DateTime(nullable: false),
                        DateActivityStart = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ActID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Description = c.String(),
                        Image = c.String(maxLength: 100),
                        ByAdmin = c.String(maxLength: 100),
                        BlogDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BlogID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactID = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(maxLength: 100),
                        Email = c.String(maxLength: 40),
                        Subject = c.String(maxLength: 100),
                        Message = c.String(maxLength: 1000),
                        DateMessage = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactID);
            
            CreateTable(
                "dbo.Franchises",
                c => new
                    {
                        FranID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 20),
                        CompanyName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 30),
                        Note = c.String(maxLength: 100),
                        Message = c.String(maxLength: 500),
                        DateFran = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FranID);
            
            CreateTable(
                "dbo.Galeries",
                c => new
                    {
                        GaleryID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Image = c.String(maxLength: 100),
                        DatePhoto = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GaleryID);
            
            CreateTable(
                "dbo.Kariyers",
                c => new
                    {
                        KarID = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 20),
                        Birim = c.String(maxLength: 20),
                        LastWorkingName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 30),
                        Subject = c.String(maxLength: 100),
                        DateKar = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KarID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Description = c.String(maxLength: 1000),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MenuID);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        SetID = c.Int(nullable: false, identity: true),
                        Address = c.String(maxLength: 40),
                        City = c.String(maxLength: 20),
                        Country = c.String(maxLength: 20),
                        Phone = c.String(maxLength: 20),
                        Email = c.String(maxLength: 20),
                        Facebook = c.String(maxLength: 100),
                        Youtube = c.String(maxLength: 100),
                        Map = c.String(maxLength: 1500),
                        Instagram = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.SetID);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        SliderID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 150),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.SliderID);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Description = c.String(),
                        Color = c.String(),
                        Image = c.String(maxLength: 100),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateStore = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StoreID);
            
            CreateTable(
                "dbo.Subes",
                c => new
                    {
                        SubeID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        Map = c.String(maxLength: 1500),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SubeID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        VideoID = c.Int(nullable: false, identity: true),
                        VideoURL = c.String(maxLength: 250),
                        Status = c.Boolean(nullable: false),
                        DateVideo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VideoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Videos");
            DropTable("dbo.Subes");
            DropTable("dbo.Stores");
            DropTable("dbo.Sliders");
            DropTable("dbo.Settings");
            DropTable("dbo.Menus");
            DropTable("dbo.Kariyers");
            DropTable("dbo.Galeries");
            DropTable("dbo.Franchises");
            DropTable("dbo.Contacts");
            DropTable("dbo.Blogs");
            DropTable("dbo.Admins");
            DropTable("dbo.Activities");
            DropTable("dbo.Abouts");
        }
    }
}
