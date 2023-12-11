using EveExchange.DataAccess.Entitiy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveExchange.DataAccess.EvaExchangeDbContext
{
    public class EvaExchangeContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<UserLot> UserLots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=EvaExchangeDb;Username=postgres;Password=192535");
        }
    }
}
