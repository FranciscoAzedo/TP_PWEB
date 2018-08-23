namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modelo_Marca1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carroes", "Marca_MarcaID", "dbo.Marcas");
            DropForeignKey("dbo.Carroes", "Modelo_ModeloID", "dbo.Modeloes");
            DropIndex("dbo.Carroes", new[] { "Marca_MarcaID" });
            DropIndex("dbo.Carroes", new[] { "Modelo_ModeloID" });
            AddColumn("dbo.Carroes", "Marca", c => c.String());
            AddColumn("dbo.Carroes", "Modelo", c => c.String());
            DropColumn("dbo.Carroes", "Marca_MarcaID");
            DropColumn("dbo.Carroes", "Modelo_ModeloID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carroes", "Modelo_ModeloID", c => c.Int());
            AddColumn("dbo.Carroes", "Marca_MarcaID", c => c.Int());
            DropColumn("dbo.Carroes", "Modelo");
            DropColumn("dbo.Carroes", "Marca");
            CreateIndex("dbo.Carroes", "Modelo_ModeloID");
            CreateIndex("dbo.Carroes", "Marca_MarcaID");
            AddForeignKey("dbo.Carroes", "Modelo_ModeloID", "dbo.Modeloes", "ModeloID");
            AddForeignKey("dbo.Carroes", "Marca_MarcaID", "dbo.Marcas", "MarcaID");
        }
    }
}
