﻿using EveExchange.DataAccess.Entitiy;
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
        string connectionString = "Server=94.73.149.63; User ID=emreyavas; Password=E6i8ycCaK8hdkql2%;  Database=EvaExchange";
        public DbSet<User> Users { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Share> Shares { get; set; }
        public DbSet<UserLot> UserLots { get; set; }
        public DbSet<Trade> Trades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
