using HaliSahaPortali.Models;
using Microsoft.EntityFrameworkCore;

namespace HaliSahaPortali.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Tesis> Tesisler { get; set; }
        public DbSet<Saha> Sahalar { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
    }
}