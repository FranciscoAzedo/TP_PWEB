namespace AluguerCarros.Migrations.AlugarCarros
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CarroDono : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carroes", "Dono", c => c.String());
            DropColumn("dbo.Carroes", "DonoID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carroes", "DonoID", c => c.String());
            DropColumn("dbo.Carroes", "Dono");
        }
    }
}
