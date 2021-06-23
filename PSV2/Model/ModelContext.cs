using System;
using Microsoft.EntityFrameworkCore;
using PSV2.Configuration;

namespace PSV2.Model
{
    public class ModelContext : DbContext
    {
        public static ProjectConfiguration Configuration;

        public ModelContext(DbContextOptions<ModelContext> context, ProjectConfiguration configuration) : base(context)
        {
            if (configuration != null)
            {
                ModelContext.Configuration = configuration;
            }
        }

        public ModelContext() : base() { }

        public DbSet<User> Users { get; set; }

        public DbSet<Apointment> Apointments { get; set; }

        public DbSet<Drugs> Drugs { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Instruction> Instructions { get; set; }

        public DbSet<Recepie> Recepie { get; set; }

        public DbSet<Visit> Visits { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer("Data Source=68.183.211.117;Initial Catalog=psvborisa;User ID=sa;Password=Lilly021!");
        }
    }
}
