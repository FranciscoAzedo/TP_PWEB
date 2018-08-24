namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomeCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido_Aluguer", "Cliente", c => c.String());
            DropColumn("dbo.Pedido_Aluguer", "ClienteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedido_Aluguer", "ClienteID", c => c.String());
            DropColumn("dbo.Pedido_Aluguer", "Cliente");
        }
    }
}
