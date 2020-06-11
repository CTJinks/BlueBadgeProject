namespace PokeTrack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedJoiningTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IndividualPokemon", "MoveID", "dbo.Move");
            DropIndex("dbo.IndividualPokemon", new[] { "MoveID" });
            CreateTable(
                "dbo.IndividualPokemonMoves",
                c => new
                    {
                        IndividualPokemonMovesID = c.Int(nullable: false, identity: true),
                        MoveID = c.Int(nullable: false),
                        IndividualPokemonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IndividualPokemonMovesID)
                .ForeignKey("dbo.IndividualPokemon", t => t.IndividualPokemonID, cascadeDelete: true)
                .ForeignKey("dbo.Move", t => t.MoveID, cascadeDelete: true)
                .Index(t => t.MoveID)
                .Index(t => t.IndividualPokemonID);
            
            DropColumn("dbo.IndividualPokemon", "MoveID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IndividualPokemon", "MoveID", c => c.Int(nullable: false));
            DropForeignKey("dbo.IndividualPokemonMoves", "MoveID", "dbo.Move");
            DropForeignKey("dbo.IndividualPokemonMoves", "IndividualPokemonID", "dbo.IndividualPokemon");
            DropIndex("dbo.IndividualPokemonMoves", new[] { "IndividualPokemonID" });
            DropIndex("dbo.IndividualPokemonMoves", new[] { "MoveID" });
            DropTable("dbo.IndividualPokemonMoves");
            CreateIndex("dbo.IndividualPokemon", "MoveID");
            AddForeignKey("dbo.IndividualPokemon", "MoveID", "dbo.Move", "MoveID", cascadeDelete: true);
        }
    }
}
