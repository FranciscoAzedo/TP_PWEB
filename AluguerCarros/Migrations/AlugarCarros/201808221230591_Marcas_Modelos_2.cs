namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Marcas_Modelos_2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Modeloes", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modeloes", "Nome", c => c.Int(nullable: false));
        }
    }
}
