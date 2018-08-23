namespace AluguerCarros.Migrations.Identity
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AluguerCarros.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(AluguerCarros.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Administrador"))
                roleManager.Create(new IdentityRole("Administrador"));
            if (!roleManager.RoleExists("Externo"))
                roleManager.Create(new IdentityRole("Externo"));
            if (!roleManager.RoleExists("Privado"))
                roleManager.Create(new IdentityRole("Privado"));
            if (!roleManager.RoleExists("Profissional"))
                roleManager.Create(new IdentityRole("Profissional"));
        }
    }
}
