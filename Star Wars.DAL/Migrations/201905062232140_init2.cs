namespace Star_Wars.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Planet = c.String(),
                        FriendId = c.Int(),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.Character", t => t.FriendId)
                .Index(t => t.FriendId);
            
            CreateTable(
                "dbo.Episode",
                c => new
                    {
                        EpisodeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EpisodeId);
            
            CreateTable(
                "dbo.EpisodeCharacter",
                c => new
                    {
                        Episode_EpisodeId = c.Int(nullable: false),
                        Character_CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Episode_EpisodeId, t.Character_CharacterId })
                .ForeignKey("dbo.Episode", t => t.Episode_EpisodeId, cascadeDelete: true)
                .ForeignKey("dbo.Character", t => t.Character_CharacterId, cascadeDelete: true)
                .Index(t => t.Episode_EpisodeId)
                .Index(t => t.Character_CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Character", "FriendId", "dbo.Character");
            DropForeignKey("dbo.EpisodeCharacter", "Character_CharacterId", "dbo.Character");
            DropForeignKey("dbo.EpisodeCharacter", "Episode_EpisodeId", "dbo.Episode");
            DropIndex("dbo.EpisodeCharacter", new[] { "Character_CharacterId" });
            DropIndex("dbo.EpisodeCharacter", new[] { "Episode_EpisodeId" });
            DropIndex("dbo.Character", new[] { "FriendId" });
            DropTable("dbo.EpisodeCharacter");
            DropTable("dbo.Episode");
            DropTable("dbo.Character");
        }
    }
}
