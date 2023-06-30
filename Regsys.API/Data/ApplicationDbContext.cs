using Microsoft.EntityFrameworkCore;
using Regsys.API.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserTask> UserTasks { get; set; }
    public DbSet<ProjectTask> Tasks { get; set; }
    public DbSet<TimeRegistration> TimeRegistrations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserTask>()
            .HasKey(ut => new { ut.UserId, ut.TaskId });

        modelBuilder.Entity<ProjectTask>()
            .HasKey(t => t.TaskId);

        modelBuilder.Entity<UserTask>()
            .HasOne(ut => ut.User)
            .WithMany(u => u.UserTasks)
            .HasForeignKey(ut => ut.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserTask>()
            .HasOne(ut => ut.Task)
            .WithMany(t => t.UserTasks)
            .HasForeignKey(ut => ut.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Company)
            .WithMany(c => c.Users)
            .HasForeignKey(u => u.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectTask>()
            .HasOne(t => t.Company)
            .WithMany(c => c.Tasks)
            .HasForeignKey(t => t.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(u => u.TimeRegistrations)
            .WithOne(tr => tr.User)
            .HasForeignKey(tr => tr.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectTask>()
            .HasMany(t => t.TimeRegistrations)
            .WithOne(tr => tr.Task)
            .HasForeignKey(tr => tr.TaskId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
