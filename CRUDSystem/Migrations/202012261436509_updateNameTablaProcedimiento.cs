namespace CRUDSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNameTablaProcedimiento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Procedimientoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TablaProcedimientoes",
                c => new
                    {
                        TablaId = c.Int(nullable: false),
                        ProcedimientoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TablaId, t.ProcedimientoId })
                .ForeignKey("dbo.Procedimientoes", t => t.ProcedimientoId, cascadeDelete: true)
                .ForeignKey("dbo.Tablas", t => t.TablaId, cascadeDelete: true)
                .Index(t => t.TablaId)
                .Index(t => t.ProcedimientoId);
            
            CreateTable(
                "dbo.Tablas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TablaProcedimientoes", "TablaId", "dbo.Tablas");
            DropForeignKey("dbo.TablaProcedimientoes", "ProcedimientoId", "dbo.Procedimientoes");
            DropIndex("dbo.TablaProcedimientoes", new[] { "ProcedimientoId" });
            DropIndex("dbo.TablaProcedimientoes", new[] { "TablaId" });
            DropTable("dbo.Tablas");
            DropTable("dbo.TablaProcedimientoes");
            DropTable("dbo.Procedimientoes");
        }
    }
}
