namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MatriculaRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Carroes", "Matricula", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carroes", "Matricula", c => c.String());
        }
    }
}
