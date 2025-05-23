using Microsoft.EntityFrameworkCore;
using SocialAssistanceFundApp.Models.AddressInfo;
using SocialAssistanceFundApp.Models.ApplicantInfo;
using SocialAssistanceFundApp.Models.ApplicationInfo;

namespace SocialAssistanceFundApp.Data
{
    public class SAFDbContext : DbContext
    {
        public SAFDbContext(DbContextOptions<SAFDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MaritalStatus>().HasData(
                new MaritalStatus { Id = 1, Status = "Single" },
                new MaritalStatus { Id = 2, Status = "Married" },
                new MaritalStatus { Id = 3, Status = "Separated" },
                new MaritalStatus { Id = 4, Status = "Divorced" },
                new MaritalStatus { Id = 5, Status = "Widowed" }
            );

            modelBuilder.Entity<Sex>().HasData(
                new Sex { Id = 1, Name = "Male" },
                new Sex { Id = 2, Name = "Female" }
            );

            modelBuilder.Entity<SocialAssistanceProgram>().HasData(
                new SocialAssistanceProgram { Id = 1, Name = "Orphans and vulnerable children" },
                new SocialAssistanceProgram { Id = 2, Name = "Poor elderly persons" },
                new SocialAssistanceProgram { Id = 3, Name = "Persons with disability" },
                new SocialAssistanceProgram { Id = 4, Name = "Persons in extreme poverty" }
            );
        }

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Approval> Approvals { get; set; }

        public DbSet<Approver> Approvers { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<MaritalStatus> MaritalStatuses { get; set; }

        public DbSet<Sex> Sexes { get; set; }

        public DbSet<SocialAssistanceProgram> SocialAssistancePrograms { get; set; }

        public DbSet<SubCountry> SubCountries { get; set; }

        public DbSet<SubLocation> SubLocations { get; set; }

        public DbSet<TelephoneContact> TelephoneContacts { get; set; }

        public DbSet<Village> Villages { get; set; }
    }
}
