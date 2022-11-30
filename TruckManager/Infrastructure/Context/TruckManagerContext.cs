using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckManager.Domain.Entity;
using TruckManager.Infrastructure.Mapping;

namespace TruckManager.Infrastructure.Context
{
    public class TruckManagerContext : DbContext
    {
        public DbSet<Truck> Truck { get; set; }
        public DbSet<Modelo> Modelo { get; set; }

        public IDbContextTransaction Transaction { get; private set; }

        public TruckManagerContext(DbContextOptions<TruckManagerContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public IDbContextTransaction InitTransacao()
        {
            if (Transaction == null) Transaction = this.Database.BeginTransaction();
            return Transaction;
        }


        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        private void Save()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Save();
            Commit();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TruckMap());
            modelBuilder.ApplyConfiguration(new ModeloMap());
        }
    }
}
