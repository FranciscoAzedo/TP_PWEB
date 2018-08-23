namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseDadosInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Avaliacaos",
                c => new
                    {
                        AvaliacaoID = c.Int(nullable: false, identity: true),
                        Resultado = c.Int(nullable: false),
                        Tempo_Resposta = c.Int(),
                        Simpatia = c.Int(),
                        Estado_Veiculo = c.Int(),
                        Limpeza_Veiculo = c.Int(),
                        Comportamento = c.Int(),
                        Estado_Veiculo1 = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Carro_CarroID = c.Int(),
                    })
                .PrimaryKey(t => t.AvaliacaoID)
                .ForeignKey("dbo.Carroes", t => t.Carro_CarroID)
                .Index(t => t.Carro_CarroID);
            
            CreateTable(
                "dbo.Carroes",
                c => new
                    {
                        CarroID = c.Int(nullable: false, identity: true),
                        Matricula = c.String(),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Combustivel = c.String(),
                        Lugares = c.Int(nullable: false),
                        Portas = c.Int(nullable: false),
                        Preco_Diario = c.Int(nullable: false),
                        Preco_Mensal = c.Int(nullable: false),
                        Condicoes = c.String(),
                        Zona = c.String(),
                        Disponivel = c.Boolean(nullable: false),
                        DonoID = c.String(),
                    })
                .PrimaryKey(t => t.CarroID);
            
            CreateTable(
                "dbo.Pedido_Aluguer",
                c => new
                    {
                        PedidoID = c.Int(nullable: false, identity: true),
                        ClienteID = c.String(),
                        Matricula = c.String(),
                        Veiculo_CarroID = c.Int(),
                    })
                .PrimaryKey(t => t.PedidoID)
                .ForeignKey("dbo.Carroes", t => t.Veiculo_CarroID)
                .Index(t => t.Veiculo_CarroID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido_Aluguer", "Veiculo_CarroID", "dbo.Carroes");
            DropForeignKey("dbo.Avaliacaos", "Carro_CarroID", "dbo.Carroes");
            DropIndex("dbo.Pedido_Aluguer", new[] { "Veiculo_CarroID" });
            DropIndex("dbo.Avaliacaos", new[] { "Carro_CarroID" });
            DropTable("dbo.Pedido_Aluguer");
            DropTable("dbo.Carroes");
            DropTable("dbo.Avaliacaos");
        }
    }
}
