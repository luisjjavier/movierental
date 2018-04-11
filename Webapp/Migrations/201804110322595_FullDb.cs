namespace Webapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 600, unicode: false),
                        ImageUrl = c.String(maxLength: 600, unicode: false),
                        NickName = c.String(maxLength: 600, unicode: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 600, unicode: false),
                        ImageUrl = c.String(maxLength: 600, unicode: false),
                        Description = c.String(nullable: false, maxLength: 600, unicode: false),
                        ReleaseYear = c.Int(nullable: false),
                        Director = c.String(nullable: false, maxLength: 600, unicode: false),
                        LanguageId = c.Int(nullable: false),
                        OriginalLanguageId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rating = c.Int(nullable: false),
                        ReplacementCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ApplicationUserId = c.String(nullable: false, maxLength: 600, unicode: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.user", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.OriginalLanguageId)
                .Index(t => t.Title, unique: true)
                .Index(t => t.LanguageId)
                .Index(t => t.OriginalLanguageId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.user",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 600, unicode: false),
                        Email = c.String(maxLength: 256, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 600, unicode: false),
                        SecurityStamp = c.String(maxLength: 600, unicode: false),
                        PhoneNumber = c.String(maxLength: 600, unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.userclaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 600, unicode: false),
                        ClaimType = c.String(maxLength: 600, unicode: false),
                        ClaimValue = c.String(maxLength: 600, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.user", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.userlogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 600, unicode: false),
                        ProviderKey = c.String(nullable: false, maxLength: 600, unicode: false),
                        UserId = c.String(nullable: false, maxLength: 600, unicode: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.user", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 600, unicode: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.user", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 600, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 600, unicode: false),
                        Email = c.String(nullable: false, maxLength: 600, unicode: false),
                        Address = c.String(maxLength: 500, unicode: false),
                        Phone = c.String(maxLength: 600, unicode: false),
                        Created = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(nullable: false, maxLength: 600, unicode: false),
                        PaymentId = c.Int(nullable: false),
                        RentMovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.user", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.RentMovieId)
                .ForeignKey("dbo.Payments", t => t.PaymentId)
                .Index(t => t.CustomerId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.PaymentId)
                .Index(t => t.RentMovieId);
            
            CreateTable(
                "dbo.userrole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 600, unicode: false),
                        RoleId = c.String(nullable: false, maxLength: 600, unicode: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.user", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 600, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 600, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Tapes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 600, unicode: false),
                        Name = c.String(nullable: false, maxLength: 256, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ActorsMovie",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.ActorId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.ActorId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.ActorId);
            
            CreateTable(
                "dbo.MovieCategories",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.CustomerId })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.userrole", "RoleId", "dbo.role");
            DropForeignKey("dbo.Customers", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Tapes", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Movies", "OriginalLanguageId", "dbo.Languages");
            DropForeignKey("dbo.Movies", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.MovieCategories", "CustomerId", "dbo.Categories");
            DropForeignKey("dbo.MovieCategories", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Movies", "ApplicationUserId", "dbo.user");
            DropForeignKey("dbo.userrole", "UserId", "dbo.user");
            DropForeignKey("dbo.Rentals", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Rentals", "RentMovieId", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "ApplicationUserId", "dbo.user");
            DropForeignKey("dbo.Payments", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Payments", "ApplicationUserId", "dbo.user");
            DropForeignKey("dbo.userlogin", "UserId", "dbo.user");
            DropForeignKey("dbo.userclaim", "UserId", "dbo.user");
            DropForeignKey("dbo.ActorsMovie", "ActorId", "dbo.Actors");
            DropForeignKey("dbo.ActorsMovie", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieCategories", new[] { "CustomerId" });
            DropIndex("dbo.MovieCategories", new[] { "MovieId" });
            DropIndex("dbo.ActorsMovie", new[] { "ActorId" });
            DropIndex("dbo.ActorsMovie", new[] { "MovieId" });
            DropIndex("dbo.role", "RoleNameIndex");
            DropIndex("dbo.Tapes", new[] { "MovieId" });
            DropIndex("dbo.Languages", new[] { "Name" });
            DropIndex("dbo.Categories", new[] { "Name" });
            DropIndex("dbo.userrole", new[] { "RoleId" });
            DropIndex("dbo.userrole", new[] { "UserId" });
            DropIndex("dbo.Rentals", new[] { "RentMovieId" });
            DropIndex("dbo.Rentals", new[] { "PaymentId" });
            DropIndex("dbo.Rentals", new[] { "ApplicationUserId" });
            DropIndex("dbo.Rentals", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "Movie_Id" });
            DropIndex("dbo.Payments", new[] { "ApplicationUserId" });
            DropIndex("dbo.Payments", new[] { "CustomerId" });
            DropIndex("dbo.userlogin", new[] { "UserId" });
            DropIndex("dbo.userclaim", new[] { "UserId" });
            DropIndex("dbo.user", "UserNameIndex");
            DropIndex("dbo.Movies", new[] { "ApplicationUserId" });
            DropIndex("dbo.Movies", new[] { "OriginalLanguageId" });
            DropIndex("dbo.Movies", new[] { "LanguageId" });
            DropIndex("dbo.Movies", new[] { "Title" });
            DropTable("dbo.MovieCategories");
            DropTable("dbo.ActorsMovie");
            DropTable("dbo.role");
            DropTable("dbo.Tapes");
            DropTable("dbo.Languages");
            DropTable("dbo.Categories");
            DropTable("dbo.userrole");
            DropTable("dbo.Rentals");
            DropTable("dbo.Customers");
            DropTable("dbo.Payments");
            DropTable("dbo.userlogin");
            DropTable("dbo.userclaim");
            DropTable("dbo.user");
            DropTable("dbo.Movies");
            DropTable("dbo.Actors");
        }
    }
}
