namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Avalicaoes_Clientes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Avaliacaos", "Carro_CarroID", "dbo.Carroes");
            RenameColumn(table: "dbo.Avaliacaos", name: "Carro_CarroID", newName: "CarroID");
            RenameIndex(table: "dbo.Avaliacaos", name: "IX_Carro_CarroID", newName: "IX_CarroID");
            AddColumn("dbo.Avaliacaos", "Dono", c => c.String());
            AddColumn("dbo.Avaliacaos", "Cliente", c => c.String());
            AddForeignKey("dbo.Avaliacaos", "CarroID", "dbo.Carroes", "CarroID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Avaliacaos", "CarroID", "dbo.Carroes");
            DropColumn("dbo.Avaliacaos", "Cliente");
            DropColumn("dbo.Avaliacaos", "Dono");
            RenameIndex(table: "dbo.Avaliacaos", name: "IX_CarroID", newName: "IX_Carro_CarroID");
            RenameColumn(table: "dbo.Avaliacaos", name: "CarroID", newName: "Carro_CarroID");
            AddForeignKey("dbo.Avaliacaos", "Carro_CarroID", "dbo.Carroes", "CarroID");
        }
    }
}
