namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Avalicaoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Avaliacaos", "Tipo", c => c.String());
            AddColumn("dbo.Avaliacaos", "PedidoID", c => c.Int(nullable: false));
            AddColumn("dbo.Pedido_Aluguer", "aval_Cli", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pedido_Aluguer", "aval_Dono", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pedido_Aluguer", "aval_Carro", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedido_Aluguer", "aval_Carro");
            DropColumn("dbo.Pedido_Aluguer", "aval_Dono");
            DropColumn("dbo.Pedido_Aluguer", "aval_Cli");
            DropColumn("dbo.Avaliacaos", "PedidoID");
            DropColumn("dbo.Avaliacaos", "Tipo");
        }
    }
}
