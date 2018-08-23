namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloID_MarcaID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carroes", "Marca_MarcaID", "dbo.Marcas");
            DropForeignKey("dbo.Carroes", "Modelo_ModeloID", "dbo.Modeloes");
            DropIndex("dbo.Carroes", new[] { "Marca_MarcaID" });
            DropIndex("dbo.Carroes", new[] { "Modelo_ModeloID" });
            AddColumn("dbo.Carroes", "MarcaID", c => c.Int(nullable: false));
            AddColumn("dbo.Carroes", "ModeloID", c => c.Int(nullable: false));
            DropColumn("dbo.Carroes", "Marca_MarcaID");
            DropColumn("dbo.Carroes", "Modelo_ModeloID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carroes", "Modelo_ModeloID", c => c.Int());
            AddColumn("dbo.Carroes", "Marca_MarcaID", c => c.Int());
            DropColumn("dbo.Carroes", "ModeloID");
            DropColumn("dbo.Carroes", "MarcaID");
            CreateIndex("dbo.Carroes", "Modelo_ModeloID");
            CreateIndex("dbo.Carroes", "Marca_MarcaID");
            AddForeignKey("dbo.Carroes", "Modelo_ModeloID", "dbo.Modeloes", "ModeloID");
            AddForeignKey("dbo.Carroes", "Marca_MarcaID", "dbo.Marcas", "MarcaID");
        }
    }
}
