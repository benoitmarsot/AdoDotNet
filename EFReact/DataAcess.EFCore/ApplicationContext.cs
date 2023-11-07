using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.EFCore;
public class ApplicationContext : DbContext {
    public DbSet<Assessment> Assessments { get; set; }
    public DbSet<AssessmentVersion> AssessmentVersions { get; set; }
    public DbSet<BodyQuestion> BodyQuestions { get; set; }
    public DbSet<BodyQuestionText> BodyQuestionTexts { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<ProviderPatient> ProviderPatients { get; set; }
    protected readonly IConfiguration Configuration;
    public ApplicationContext(IConfiguration configuration) {
        Configuration = configuration;

    }
    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));

    }
    //Dealing with composite key with EF 6, see in class BodyQuestion for other versions
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //modelBuilder.Entity<AssessmentVersion>()
        //    .Property(x => x.AssementVersionId).UseSerialColumn();
        modelBuilder.Entity<AssessmentVersion>()
            .Property(av => av.AssementVersionId).ValueGeneratedOnAdd();
        modelBuilder.Entity<AssessmentVersion>()
            .HasMany(av => av.VersionTexts)
            .WithOne(bqt => bqt.AssessmentVersion)
            .HasForeignKey(bqt => bqt.AssessmentVersionId)
            .HasConstraintName("bodyquestiontext_fk_assessmentversion");
        modelBuilder.Entity<BodyQuestionText>()
            .HasKey(m => new { m.BodyQuestionId, m.AssessmentVersionId });
        modelBuilder.Entity<ProviderPatient>()
            .HasKey(m => new { m.ProviderId, m.PatientId });
        modelBuilder.Entity<Assessment>()
            .HasMany(e => e.AssessmentVersions)
            .WithOne(e => e.Assessment)
            .HasForeignKey(e => e.AssessmentId)
            .HasConstraintName("assessmentversion_fk_assessment");
        modelBuilder.Entity<Assessment>()
            .HasMany(e => e.BodyQuestions)
            .WithOne(e => e.Assessment)
            .HasForeignKey(e => e.assessmentid)
            .HasConstraintName("bodyquestion_fk_assessment");
        //modelBuilder.Entity<BodyQuestion>()
        //    .HasMany(bq => bq.VersionTexts)
        //    .WithOne(bqt => bqt.BodyQuestion)
        //    .HasForeignKey(bqt => bqt.BodyQuestionId)
        //    .HasConstraintName("bodyquestiontext_fk_assessmentversion");

        //.HasPrincipalKey(e=>e.AssessmentId)

    }
}
