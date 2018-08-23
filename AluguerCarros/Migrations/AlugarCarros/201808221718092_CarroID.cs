namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarroID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedido_Aluguer", "Veiculo_CarroID", "dbo.Carroes");
            DropIndex("dbo.Pedido_Aluguer", new[] { "Veiculo_CarroID" });
            RenameColumn(table: "dbo.Pedido_Aluguer", name: "Veiculo_CarroID", newName: "CarroID");
            AlterColumn("dbo.Pedido_Aluguer", "CarroID", c => c.Int(nullable: false));
            CreateIndex("dbo.Pedido_Aluguer", "CarroID");
            AddForeignKey("dbo.Pedido_Aluguer", "CarroID", "dbo.Carroes", "CarroID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido_Aluguer", "CarroID", "dbo.Carroes");
            DropIndex("dbo.Pedido_Aluguer", new[] { "CarroID" });
            AlterColumn("dbo.Pedido_Aluguer", "CarroID", c => c.Int());
            RenameColumn(table: "dbo.Pedido_Aluguer", name: "CarroID", newName: "Veiculo_CarroID");
            CreateIndex("dbo.Pedido_Aluguer", "Veiculo_CarroID");
            AddForeignKey("dbo.Pedido_Aluguer", "Veiculo_CarroID", "dbo.Carroes", "CarroID");
        }
    }
}
