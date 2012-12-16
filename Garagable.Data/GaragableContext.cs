using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Garagable.Model;

namespace Garagable.Data {

    public class GaragableContext : DbContext  {

        public GaragableContext()
            : base("GaragableDb") { }

        public DbSet<GarageSale> GarageSales { get; set; } 
        public DbSet<Item> Items { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<SavedSearch> Searches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {

            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new GarageSaleConfiguration());
            modelBuilder.Configurations.Add(new SearchConfiguration());
            modelBuilder.Configurations.Add(new PhotoConfiguration());
        }

        #region Expose the context's underlying methods
        
        public virtual void Commit() {
            base.SaveChanges();
        }

        #endregion

    }

}
