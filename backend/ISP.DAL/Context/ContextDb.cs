using ISP.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.DAL.Context
{
    public class ContextDb : IdentityDbContext <User>
    {

        public ContextDb(DbContextOptions<ContextDb> options):base(options) {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Group>(entity =>
            {
                entity.HasIndex(group => group.Name).IsUnique();
            });
           
            builder.Entity<Offer>()
                 .HasMany(o => o.Branches)
                 .WithMany(x => x.Offers)
                 .UsingEntity<BranchOffer>(
                 j => j
                 .HasOne(b => b.Branch)
                 .WithMany(b => b.BranchOffers)
                 .HasForeignKey(pt => pt.BranchesId),
                 j => j
                 .HasOne(pt => pt.Offer)
                 .WithMany(t => t.BranchOffers)
                 .HasForeignKey(pt => pt.OffersId),
                 j => j
                 .HasKey(t => new { t.BranchesId, t.OffersId }).HasName("PK_BranchOffer")
                 );

            builder.Entity<Group>().HasData(
                
                new Group {Id = 1 ,  Name = "Admin" , IsAdmin = true , IsEmployee = false , IsManager = false , ReadClients = false , ReadWriteClients = false , groupRole = "Admin" } ,
                new Group {Id = 2 ,  Name = "Manager" , IsManager = true , IsAdmin = false , IsEmployee = false , ReadClients = false , ReadWriteClients = false , groupRole = "Manager" },
                new Group {Id = 3 ,  Name = "Employee" , IsAdmin = false , IsManager = false , IsEmployee = true , ReadClients = false , ReadWriteClients = false , groupRole = "Employee" }
                );

            builder.Entity<Client>()  //Plus==>
                    .HasIndex(client => client.Phone)   
                    .IsUnique();
            
        }

        #region override Savechanges() to enforce Validation of the data annotation
        public override int SaveChanges()
        {
            var Entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Modified || e.State == EntityState.Added
                           && (e.Entity is Client) && (e.Entity is Branch)

                           select e.Entity;
            foreach (var Entity in Entities)
            {
                ValidationContext validationContext = new ValidationContext(Entity);
                Validator.ValidateObject(Entity, validationContext, true);
            }


            return base.SaveChanges();
        }
        #endregion

        public DbSet<Group> Groups { get; set; }
        public DbSet<Governarate> Governarates { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Central> Centrals { get; set; }

        public DbSet<InternetServiceProvider> InternetServiceProviders { get; set; }

        public DbSet<Bundle> Bundles { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<BranchOffer> BranchOffer { get; set; }

        public DbSet<ClientTakeOffer> ClientOffer { get; set; }

        public DbSet<Bill> Bills { get; set; }

    }
}
