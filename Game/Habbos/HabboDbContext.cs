using Microsoft.EntityFrameworkCore;

namespace Nordlys.Game.Habbos
{
    public class HabboDbContext : DbContext
    {
        public HabboDbContext()
        {
            // TODO: Inject some kind of config for MySQL options?
        }

        public DbSet<Habbo> Habbos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;Database=nordlys_db;Uid=root;Pwd=1234;Pooling=True;", options => options.EnableRetryOnFailure());
        }
    }
}
