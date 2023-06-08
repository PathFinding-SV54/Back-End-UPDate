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
    }
}