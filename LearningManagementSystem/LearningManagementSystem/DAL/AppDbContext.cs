using LearningManagementSystem.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace LearningManagementSystem.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<PrimaryInfo> PrimaryInfos { get; set; }
        public DbSet<SecondaryInfo> SecondaryInfos { get; set; }
        public DbSet<EducationDetail> EducationDetails { get; set; }
        public DbSet<AddressDetail> AddressDetails { get; set; }
        public DbSet<BankDetail> BankDetails { get; set; }
        public DbSet<TechnicalSkill> TechnicalSkills { get; set; }
        public DbSet<ExperienceDetail> Experiences { get; set; }
        public DbSet<ContactDetail> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EducationDetail>()
               .Property(e => e.Percentage)
               .HasPrecision(5, 2); // Precision 5, Scale 2

            base.OnModelCreating(modelBuilder);
            // Configure many-to-many relationship for PrimaryInfo and TechnicalSkills
            modelBuilder.Entity<PrimaryInfo>()
                .HasMany(ps => ps.TechnicalSkillsInfos)
                .WithMany(ts => ts.PrimaryInfos)
                //UsingEntity<Dictionary<string, object>> is a way to configure the join table in a more flexible manner without creating a separate class for the join entity.
                .UsingEntity<Dictionary<string, object>>(
                    "PrimaryInfoTechnicalSkills",
                    j => j.HasOne<TechnicalSkill>().WithMany().HasForeignKey("TechnicalSkillId"),
                    j => j.HasOne<PrimaryInfo>().WithMany().HasForeignKey("PrimaryInfoId"),
                    j =>
                    {
                        //HasKey method sets the composite primary key for the join table.
                        j.HasKey("PrimaryInfoId", "TechnicalSkillId");
                    }
                );
        }
    }
}
