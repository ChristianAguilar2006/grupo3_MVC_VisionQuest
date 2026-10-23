namespace VisionQuest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recuerdoes",
                c => new
                    {
                        RecuerdoId = c.Int(nullable: false, identity: true),
                        TituloRecuerdo = c.String(),
                        TipoRecuerdo = c.String(),
                        Claridad = c.Int(nullable: false),
                        Sintezoide_SintezoideId = c.Int(),
                    })
                .PrimaryKey(t => t.RecuerdoId)
                .ForeignKey("dbo.Sintezoides", t => t.Sintezoide_SintezoideId)
                .Index(t => t.Sintezoide_SintezoideId);
            
            CreateTable(
                "dbo.Sintezoides",
                c => new
                    {
                        SintezoideId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Modelo = c.String(nullable: false),
                        NivelIA = c.Int(nullable: false),
                        FuenteEnergia = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SintezoideId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recuerdoes", "Sintezoide_SintezoideId", "dbo.Sintezoides");
            DropIndex("dbo.Recuerdoes", new[] { "Sintezoide_SintezoideId" });
            DropTable("dbo.Sintezoides");
            DropTable("dbo.Recuerdoes");
        }
    }
}
