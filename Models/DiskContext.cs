using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project4.Models
{

    public class DiskContext : DbContext
    {

        public DiskContext(DbContextOptions<DiskContext> options)
          : base(options)
        { }

      


        public DbSet<Disk> Disks { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<DiskType> DiskTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<DiskHasBorrower> BorrowedDisks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiskHasBorrower>()
            .ToTable("BorrowedDisks");

        
        }

        }
}
