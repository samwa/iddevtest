using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace iddevtest
{
    public class LgaContext : DbContext
    {
        public DbSet<LgaModel> Lgas { get; set; }
          
        public LgaContext()
        {
            
        }
        
        public LgaContext(DbContextOptions<LgaContext> options)
            :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\SQL2012;Database=sdb-iddevtest;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LgaModel>(b =>
            {
                b.HasKey(e => e.LgaId);
                b.Property(e => e.LgaId).ValueGeneratedOnAdd();
            });            
        }
    }

    public class LgaModel
    {
        [Key]
        public int LgaId { get; set; } 
        public string Place { get; set; }
        public string State { get; set; }
        public int? SEIFADisadvantage2011 { get; set; }
        public int? SEIFADisadvantage2016 { get; set; }
    }
}