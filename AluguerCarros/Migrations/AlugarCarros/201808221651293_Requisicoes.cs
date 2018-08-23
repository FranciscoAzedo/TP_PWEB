namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requisicoes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedido_Aluguer", "dataInicio", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pedido_Aluguer", "dataFim", c => c.DateTime(nullable: false));
            DropColumn("dbo.Pedido_Aluguer", "Matricula");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedido_Aluguer", "Matricula", c => c.String());
            DropColumn("dbo.Pedido_Aluguer", "dataFim");
            DropColumn("dbo.Pedido_Aluguer", "dataInicio");
        }
    }
}
