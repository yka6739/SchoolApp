using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolApp.Business.Entities;
using SchoolApp.Data.Mapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Data.Helpers
{
    public class SchoolAppDbContext:DbContext
    {
        private string DbConnStr { get; set; }
        public SchoolAppDbContext()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            DbConnStr = root.GetConnectionString("SchoolDBConn");
        }

        public SchoolAppDbContext(DbContextOptions<SchoolAppDbContext> options)
         : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DbConnStr);

        }
        public DbSet<Individual> IndividualSet { get; set; }
        public DbSet<VW_Individual> IndividualVWSet { get; set; }
        public DbSet<Country> CountrySet { get; set; }
        public DbSet<Education> EducationSet { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new IndividualConfiguration());
            modelBuilder.ApplyConfiguration(new VW_IndividualConfiguration());
            modelBuilder.ApplyConfiguration(new EducationConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());

        }

    }
}
