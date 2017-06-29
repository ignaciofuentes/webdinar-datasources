using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace demoken.Model
{
public class StoreContext : DbContext
    {
        public DbSet<MonthlySale> MonthlySales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=store.db");
        }
    }

    public class MonthlySale
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public decimal VideoGames { get; set; }
        public decimal DVDs { get; set; }
        public decimal BluRays { get; set; }
    }

    public class MonthlySaleVm
    {
        public int id { get; set; }
        public string month { get; set; }
        public decimal videoGames { get; set; }
        public decimal dvds { get; set; }
        public decimal bluRays { get; set; }
    }
}