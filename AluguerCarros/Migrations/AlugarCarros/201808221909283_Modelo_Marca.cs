namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelo_Marca : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carroes", "Marca_MarcaID", c => c.Int());
            AddColumn("dbo.Carroes", "Modelo_ModeloID", c => c.Int());
            CreateIndex("dbo.Carroes", "Marca_MarcaID");
            CreateIndex("dbo.Carroes", "Modelo_ModeloID");
            AddForeignKey("dbo.Carroes", "Marca_MarcaID", "dbo.Marcas", "MarcaID");
            AddForeignKey("dbo.Carroes", "Modelo_ModeloID", "dbo.Modeloes", "ModeloID");
            DropColumn("dbo.Carroes", "MarcaID");
            DropColumn("dbo.Carroes", "ModeloID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carroes", "ModeloID", c => c.Int(nullable: false));
            AddColumn("dbo.Carroes", "MarcaID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Carroes", "Modelo_ModeloID", "dbo.Modeloes");
            DropForeignKey("dbo.Carroes", "Marca_MarcaID", "dbo.Marcas");
            DropIndex("dbo.Carroes", new[] { "Modelo_ModeloID" });
            DropIndex("dbo.Carroes", new[] { "Marca_MarcaID" });
            DropColumn("dbo.Carroes", "Modelo_ModeloID");
            DropColumn("dbo.Carroes", "Marca_MarcaID");
        }
    }
}
