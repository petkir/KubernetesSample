using DataAccess.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ChannelContext : DbContext
    {

        public ChannelContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ChannelSystem> ChannelSystems { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<ChannelMessage> ChannelMessages { get; set; } = null;

        public DbSet<LogEntry> Logs { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        { 
            options.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=transdb;Integrated Security=SSPI;");
        }
        */

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasIndex(c => new { c.FirstName, c.LastName, c.Email });
            modelBuilder.Entity<Contact>()
                .HasIndex(c => new { c.Email });
           
            var valueComparer = new ValueComparer<Dictionary<string, string>>(
       (c1, c2) => c1.Equals(c2),
       c => c.GetHashCode(),
       c => c.ToDictionary(entry => entry.Key,entry => entry.Value)
       );


            modelBuilder.Entity<Contact>()
                        .Property(b => b.Properties)
                        .HasConversion(
                            v => JsonConvert.SerializeObject(v),
                            v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v))
                        .Metadata.SetValueComparer(valueComparer);


            /*
            modelBuilder.Entity<Contact>()
       .Property(b => b.Properties)
       .HasConversion(
           v => JsonConvert.SerializeObject(v),
           v => JsonConvert.DeserializeObject<List<Tuple<string, string>>>(v))
       .HasColumnType("json");
       */
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public override int SaveChanges()
        {
            return SaveChanges(true);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AddAuitInfo();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            return await SaveChangesAsync(true, cancellationToken);
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
            ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
    }
}

