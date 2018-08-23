namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Marcas_Modelos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        MarcaID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.MarcaID);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        ModeloID = c.Int(nullable: false, identity: true),
                        Nome = c.Int(nullable: false),
                        Marca_MarcaID = c.Int(),
                    })
                .PrimaryKey(t => t.ModeloID)
                .ForeignKey("dbo.Marcas", t => t.Marca_MarcaID)
                .Index(t => t.Marca_MarcaID);
            
            AddColumn("dbo.Carroes", "Marca_MarcaID", c => c.Int());
            AddColumn("dbo.Carroes", "Modelo_ModeloID", c => c.Int());
            CreateIndex("dbo.Carroes", "Marca_MarcaID");
            CreateIndex("dbo.Carroes", "Modelo_ModeloID");
            AddForeignKey("dbo.Carroes", "Marca_MarcaID", "dbo.Marcas", "MarcaID");
            AddForeignKey("dbo.Carroes", "Modelo_ModeloID", "dbo.Modeloes", "ModeloID");
            DropColumn("dbo.Carroes", "Marca");
            DropColumn("dbo.Carroes", "Modelo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carroes", "Modelo", c => c.String());
            AddColumn("dbo.Carroes", "Marca", c => c.String());
            DropForeignKey("dbo.Carroes", "Modelo_ModeloID", "dbo.Modeloes");
            DropForeignKey("dbo.Modeloes", "Marca_MarcaID", "dbo.Marcas");
            DropForeignKey("dbo.Carroes", "Marca_MarcaID", "dbo.Marcas");
            DropIndex("dbo.Modeloes", new[] { "Marca_MarcaID" });
            DropIndex("dbo.Carroes", new[] { "Modelo_ModeloID" });
            DropIndex("dbo.Carroes", new[] { "Marca_MarcaID" });
            DropColumn("dbo.Carroes", "Modelo_ModeloID");
            DropColumn("dbo.Carroes", "Marca_MarcaID");
            DropTable("dbo.Modeloes");
            DropTable("dbo.Marcas");
        }
    }
}
