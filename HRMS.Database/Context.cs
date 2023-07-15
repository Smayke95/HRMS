using HRMS.Database.Models;
using HRMS.Database.Models.Enums;
using HRMS.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Task = HRMS.Database.Models.Task;
using TaskStatus = HRMS.Database.Models.TaskStatus;

namespace HRMS.Database;

public class Context : DbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeePosition> EmployeePositions { get; set; }
    public DbSet<EmployeeRole> EmployeeRoles { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
    public DbSet<Log> Logs { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<PayGrade> PayGrades { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<TaskComment> TaskComments { get; set; }
    public DbSet<TaskStatus> TaskStatuses { get; set; }
    public DbSet<TaskType> TaskTypes { get; set; }



    public Context() { }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("Server=localhost; Database=IB210295; Trusted_Connection=False; Encrypt=False; User ID=sa; Password=inetdesign;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

        modelBuilder.Entity<Country>().SeedData();
        modelBuilder.Entity<City>().SeedData();
        modelBuilder.Entity<Department>().SeedData();
        modelBuilder.Entity<Education>().SeedData();
        modelBuilder.Entity<PayGrade>().SeedData();
        modelBuilder.Entity<Position>().SeedData();
        modelBuilder.Entity<Notification>().SeedData();
        modelBuilder.Entity<EventType>().SeedData();
        modelBuilder.Entity<Event>().SeedData();
        modelBuilder.Entity<Project>().SeedData();
        modelBuilder.Entity<Task>().SeedData();
        modelBuilder.Entity<TaskStatus>().SeedData();
        modelBuilder.Entity<TaskType>().SeedData();
        modelBuilder.Entity<TaskComment>().SeedData();
    }
}