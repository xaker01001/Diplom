namespace Diplom_Chikushev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company_id = c.Int(nullable: false),
                        Person_id = c.Int(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_id)
                .ForeignKey("dbo.Person", t => t.Person_id)
                .Index(t => t.Company_id)
                .Index(t => t.Person_id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Adress = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_service = c.Int(nullable: false),
                        id_manager = c.Int(nullable: false),
                        Id_material = c.Int(nullable: false),
                        Id_client = c.Int(nullable: false),
                        DateOfIssue = c.DateTime(nullable: false, storeType: "date"),
                        СirculationTerm = c.Int(nullable: false),
                        Width = c.Single(nullable: false),
                        Height = c.Single(nullable: false),
                        kol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manager", t => t.id_manager)
                .ForeignKey("dbo.Material", t => t.Id_material)
                .ForeignKey("dbo.Services", t => t.Id_service)
                .ForeignKey("dbo.Client", t => t.Id_client)
                .Index(t => t.Id_service)
                .Index(t => t.id_manager)
                .Index(t => t.Id_material)
                .Index(t => t.Id_client);
            
            CreateTable(
                "dbo.Manager",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                        Id_person = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Id_person)
                .Index(t => t.Id_person);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 20),
                        Patronymic = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Material",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Material = c.String(nullable: false, maxLength: 50),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Service = c.String(nullable: false, maxLength: 50),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "Id_client", "dbo.Client");
            DropForeignKey("dbo.Order", "Id_service", "dbo.Services");
            DropForeignKey("dbo.Order", "Id_material", "dbo.Material");
            DropForeignKey("dbo.Manager", "Id_person", "dbo.Person");
            DropForeignKey("dbo.Client", "Person_id", "dbo.Person");
            DropForeignKey("dbo.Order", "id_manager", "dbo.Manager");
            DropForeignKey("dbo.Client", "Company_id", "dbo.Company");
            DropIndex("dbo.Manager", new[] { "Id_person" });
            DropIndex("dbo.Order", new[] { "Id_client" });
            DropIndex("dbo.Order", new[] { "Id_material" });
            DropIndex("dbo.Order", new[] { "id_manager" });
            DropIndex("dbo.Order", new[] { "Id_service" });
            DropIndex("dbo.Client", new[] { "Person_id" });
            DropIndex("dbo.Client", new[] { "Company_id" });
            DropTable("dbo.Services");
            DropTable("dbo.Material");
            DropTable("dbo.Person");
            DropTable("dbo.Manager");
            DropTable("dbo.Order");
            DropTable("dbo.Company");
            DropTable("dbo.Client");
        }
    }
}
