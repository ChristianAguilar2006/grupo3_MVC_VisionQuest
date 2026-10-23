namespace VisionQuest.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Segunda : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recuerdoes", "Sintezoide_SintezoideId", "dbo.Sintezoides");
            DropIndex("dbo.Recuerdoes", new[] { "Sintezoide_SintezoideId" });
            RenameColumn("dbo.Recuerdoes", "RecuerdoId", "Id");
            RenameColumn("dbo.Sintezoides", "SintezoideId", "Id");
            RenameColumn("dbo.Recuerdoes", "Sintezoide_SintezoideId", "SintezoideId");
            AlterColumn("dbo.Recuerdoes", "TituloRecuerdo", c => c.String(nullable: false));
            AlterColumn("dbo.Recuerdoes", "SintezoideId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recuerdoes", "SintezoideId");
            AddForeignKey("dbo.Recuerdoes", "SintezoideId", "dbo.Sintezoides", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Recuerdoes", "SintezoideId", "dbo.Sintezoides");
            DropIndex("dbo.Recuerdoes", new[] { "SintezoideId" });
            AlterColumn("dbo.Recuerdoes", "SintezoideId", c => c.Int());
            AlterColumn("dbo.Recuerdoes", "TituloRecuerdo", c => c.String());
            RenameColumn("dbo.Recuerdoes", "SintezoideId", "Sintezoide_SintezoideId");
            RenameColumn("dbo.Sintezoides", "Id", "SintezoideId");
            RenameColumn("dbo.Recuerdoes", "Id", "RecuerdoId");
            CreateIndex("dbo.Recuerdoes", "Sintezoide_SintezoideId");
            AddForeignKey("dbo.Recuerdoes", "Sintezoide_SintezoideId", "dbo.Sintezoides", "SintezoideId");
        }
    }
}
