namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pedido_Avaliacoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido_Aluguer", "aval_Carro", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pedido_Aluguer", "aval_Dono", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pedido_Aluguer", "aval_Cliente", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedido_Aluguer", "aval_Cliente");
            DropColumn("dbo.Pedido_Aluguer", "aval_Dono");
            DropColumn("dbo.Pedido_Aluguer", "aval_Carro");
        }
    }
}
