using Accreditaire.Infra.Data.Context;
using System.Data.Entity.Migrations;
namespace Accreditaire.AppMvc.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MeuDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
