using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using Garagable.Model;

namespace Garagable.Data {

    public class UserConfiguration : EntityTypeConfiguration<User> {

        public UserConfiguration()
            : base() {

            HasKey(u => u.Id).Property(u => u.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.FacebookId).HasMaxLength(64);
            Property(u => u.AccessToken).HasMaxLength(64);
            Property(u => u.HashedPassword).IsRequired().HasMaxLength(256);
            Property(u => u.Email).IsRequired().HasMaxLength(100);
            Property(u => u.UserName).IsRequired().HasMaxLength(100);
            HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(m => {
                    m.ToTable("UserRole");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                });
            
        }

    }

    public class RoleConfiguration : EntityTypeConfiguration<Role> {

        public RoleConfiguration()
            : base() {

            HasKey(r => r.Id).Property(r => r.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            Property(r => r.RoleName).HasMaxLength(100).IsRequired();
        }

    }

    public class GarageSaleConfiguration : EntityTypeConfiguration<GarageSale> {

        public GarageSaleConfiguration()
            : base() {
            HasKey(l => l.Id).Property(l => l.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(l => l.Name).HasMaxLength(100).IsRequired();
            Property(l => l.Keyword).HasMaxLength(100);
            Property(l => l.Address1);
            Property(l => l.City).IsRequired();
            Property(l => l.State).IsRequired();
            Property(l => l.State).IsRequired();

            HasRequired(l => l.User)
                .WithMany(u => u.Locations)
                .HasForeignKey(l => l.UserId);
        }
    }

    public class ItemConfiguration : EntityTypeConfiguration<Item> {

        public ItemConfiguration() 
            : base() {

            HasKey(i => i.Id).Property(i => i.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).IsRequired().HasMaxLength(100);
            Property(i => i.Description).HasMaxLength(150);

            HasRequired(i => i.GarageSale)
                .WithMany(l => l.Items)
                .HasForeignKey(i => i.GarageSaleId);
            

        }
    }

    public class SearchConfiguration : EntityTypeConfiguration<SavedSearch> {

        public SearchConfiguration() 
            : base() {

            HasKey(s => s.Id).Property(s => s.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            Property(s => s.Name).HasMaxLength(100);

            HasRequired(s => s.User)
                .WithMany(u => u.SavedSearches)
                .HasForeignKey(s => s.UserId);
        }
    }

    public class ScheduleConfiguration : EntityTypeConfiguration<Schedule> {
        public ScheduleConfiguration() 
            :base() {

            HasKey(sch => sch.Id).Property(sch => sch.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            HasRequired(sch => sch.GarageSale)
                .WithMany(l => l.Schedules)
                .HasForeignKey(sch => sch.Id);
        }
    }

    public class PhotoConfiguration : EntityTypeConfiguration<Photo>
    {
        public PhotoConfiguration()
            : base() {

            HasKey(photo => photo.Id).Property(photo => photo.Id).HasDatabaseGeneratedOption(
                DatabaseGeneratedOption.Identity);
            Property(p => p.ImageKey).HasMaxLength(512);
            Property(p => p.SmallUrl).HasMaxLength(512);
            Property(p => p.MediumUrl).HasMaxLength(512);
            Property(p => p.TinyUrl).HasMaxLength(512);
            Property(p => p.LargeUrl).HasMaxLength(512);
            Property(p => p.LightboxUrl).HasMaxLength(512);
            Property(p => p.ThumbUrl).HasMaxLength(512);
            Property(p => p.XLargeUrl).HasMaxLength(512);
            Property(p => p.X2LargeUrl).HasMaxLength(512);
            Property(p => p.X3LargeUrl).HasMaxLength(512);
            Property(p => p.Url).HasMaxLength(512);
            Property(p => p.OriginalUrl).HasMaxLength(512);

            HasOptional(p => p.GarageSale)
                .WithMany(gs => gs.Photos)
                .HasForeignKey(p => p.GarageSaleId);
            HasOptional(p => p.Item)
                .WithMany(i => i.Photos)
                .HasForeignKey(p => p.ItemId);
        }
    }

}
