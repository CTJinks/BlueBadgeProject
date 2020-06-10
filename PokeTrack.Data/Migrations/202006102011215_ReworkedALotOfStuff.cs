namespace PokeTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReworkedALotOfStuff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IndividualPokemon",
                c => new
                    {
                        IndividualPokemonID = c.Int(nullable: false, identity: true),
                        IndividualPokemonName = c.String(nullable: false),
                        MoveID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        PokemonID = c.Int(nullable: false),
                        TeamID = c.Int(),
                    })
                .PrimaryKey(t => t.IndividualPokemonID)
                .ForeignKey("dbo.Move", t => t.MoveID, cascadeDelete: true)
                .ForeignKey("dbo.Pokemon", t => t.PokemonID, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.TeamID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.MoveID)
                .Index(t => t.UserID)
                .Index(t => t.PokemonID)
                .Index(t => t.TeamID);
            
            CreateTable(
                "dbo.Move",
                c => new
                    {
                        MoveID = c.Int(nullable: false, identity: true),
                        MoveName = c.String(nullable: false),
                        Damage = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.MoveID);
            
            CreateTable(
                "dbo.Pokemon",
                c => new
                    {
                        PokemonID = c.Int(nullable: false, identity: true),
                        PokemonName = c.String(nullable: false),
                        PokemonType = c.String(nullable: false),
                        DietType = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.PokemonID);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.TeamID)
                .ForeignKey("dbo.User", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        ApplicationUserID = c.String(maxLength: 128),
                        UserName = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.IndividualPokemon", "UserID", "dbo.User");
            DropForeignKey("dbo.Team", "User_UserID", "dbo.User");
            DropForeignKey("dbo.User", "ApplicationUserID", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IndividualPokemon", "TeamID", "dbo.Team");
            DropForeignKey("dbo.IndividualPokemon", "PokemonID", "dbo.Pokemon");
            DropForeignKey("dbo.IndividualPokemon", "MoveID", "dbo.Move");
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.User", new[] { "ApplicationUserID" });
            DropIndex("dbo.Team", new[] { "User_UserID" });
            DropIndex("dbo.IndividualPokemon", new[] { "TeamID" });
            DropIndex("dbo.IndividualPokemon", new[] { "PokemonID" });
            DropIndex("dbo.IndividualPokemon", new[] { "UserID" });
            DropIndex("dbo.IndividualPokemon", new[] { "MoveID" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.User");
            DropTable("dbo.Team");
            DropTable("dbo.Pokemon");
            DropTable("dbo.Move");
            DropTable("dbo.IndividualPokemon");
        }
    }
}
