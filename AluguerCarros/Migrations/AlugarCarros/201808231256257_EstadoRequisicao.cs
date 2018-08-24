namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstadoRequisicao : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido_Aluguer", "Estado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedido_Aluguer", "Estado");
        }
    }
}
