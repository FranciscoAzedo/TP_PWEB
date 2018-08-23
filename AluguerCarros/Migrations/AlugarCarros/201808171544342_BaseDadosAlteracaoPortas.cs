namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseDadosAlteracaoPortas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carroes", "Lugares", c => c.Int(nullable: false));
            AlterColumn("dbo.Carroes", "Portas", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carroes", "Portas", c => c.Int(nullable: false));
            AlterColumn("dbo.Carroes", "Lugares", c => c.String());
        }
    }
}
