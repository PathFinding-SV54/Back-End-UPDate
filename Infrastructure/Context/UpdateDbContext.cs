using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class UpdateDbContext :DbContext
{
    public UpdateDbContext()
    {
    }
    
    public UpdateDbContext(DbContextOptions<UpdateDbContext> options) : base(options)
    {
    }
    
    public  DbSet<Activity> Activities { get; set; }
    public DbSet<Community> Communities { get; set; }

    public DbSet<Participation> Participations { get; set; }
    
    public DbSet<User> Users { get; set; }
    public DbSet<University> Universities { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=sql10.freemysqlhosting.net,3306;Uid=sql10623949;Pwd=iQ8auZS7z7;Database=sql10623949;", serverVersion);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

        builder.Entity<Activity>().ToTable("activities");
        builder.Entity<Activity>().HasKey(p => p.Id);
        builder.Entity<Activity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Activity>().Property(c => c.Title).IsRequired().HasMaxLength(60);
        builder.Entity<Activity>().Property(c => c.Description).IsRequired().HasMaxLength(240);
        builder.Entity<Activity>().Property(c => c.Address).IsRequired().HasMaxLength(60);
        builder.Entity<Activity>().Property(c => c.CreatedAt).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<Community>().ToTable("communities");
        builder.Entity<Community>().HasKey(p => p.Id);
        builder.Entity<Community>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Community>().Property(c => c.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Community>().Property(c => c.Description).IsRequired().HasMaxLength(500);
        builder.Entity<Community>().Property(c => c.CreatedAt).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Community>().Property(c => c.IsActive).IsRequired();

        builder.Entity<Participation>().ToTable("participations");
        builder.Entity<Participation>().HasKey(p => p.Id);
        builder.Entity<Participation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        //Relationship One to Many with Activity
        builder.Entity<Participation>()
            .HasOne<Activity>(s => s.Activity)
            .WithMany(g => g.Participations)
            .HasForeignKey(s => s.ActivityId);
        //Relationship One to Many with GroupMembers--


        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(25);
        builder.Entity<User>().Property(p => p.ApellidoPaterno).IsRequired().HasMaxLength(25);
        builder.Entity<User>().Property(p => p.ApellidoMaterno).IsRequired().HasMaxLength(25);
        builder.Entity<User>().Property(p => p.Bio).IsRequired().HasMaxLength(500);
        builder.Entity<User>().Property(p => p.Birthday).IsRequired();
        builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(40);
        builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(40);
        builder.Entity<User>().Property(p => p.Gender).IsRequired();
        builder.Entity<User>().Property(p => p.IsActive).IsRequired();

        builder.Entity<User>()
            .HasOne<University>(c => c.University)
            .WithMany(c => c.Users)
            .HasForeignKey(c => c.UniversityId);


        builder.Entity<University>().ToTable("universities");
        builder.Entity<University>().HasKey(p => p.Id);
        builder.Entity<University>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<University>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Entity<University>().Property(p => p.WebSite).IsRequired().HasMaxLength(50);
        builder.Entity<University>().Property(p => p.IsActive).IsRequired();

    }
}