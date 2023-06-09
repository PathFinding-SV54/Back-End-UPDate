﻿using Infrastructure.Model;
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
    public DbSet<Location> Locations { get; set; }
    public DbSet<Role> Roles { get; set; }
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
        builder.Entity<Activity>().HasKey(a => a.Id);
        builder.Entity<Activity>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Activity>().Property(a => a.Title).IsRequired().HasMaxLength(60);
        builder.Entity<Activity>().Property(a => a.Description).IsRequired().HasMaxLength(240);
        builder.Entity<Activity>().Property(a => a.Address).IsRequired().HasMaxLength(60);
        builder.Entity<Activity>().Property(a => a.CreatedAt).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Activity>().Property(a => a.IsActive).IsRequired();
        //Relationship One to Many with Location
        builder.Entity<Activity>()
            .HasOne<Location>(a => a.Location)
            .WithMany(l => l.Activities)
            .HasForeignKey(a => a.LocationId);

        builder.Entity<Community>().ToTable("communities");
        builder.Entity<Community>().HasKey(c => c.Id);
        builder.Entity<Community>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Community>().Property(c => c.Name).IsRequired().HasMaxLength(30);
        builder.Entity<Community>().Property(c => c.Description).IsRequired().HasMaxLength(500);
        builder.Entity<Community>().Property(c => c.CreatedAt).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Community>().Property(c => c.IsActive).IsRequired();

        builder.Entity<Participation>().ToTable("participations");
        builder.Entity<Participation>().HasKey(p => p.Id);
        builder.Entity<Participation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Participation>().Property(p => p.CreatedAt).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Participation>().Property(p => p.IsActive).IsRequired();
        //Relationship One to Many with Activity
        builder.Entity<Participation>()
            .HasOne<Activity>(p => p.Activity)
            .WithMany(a => a.Participations)
            .HasForeignKey(p => p.ActivityId);
        //Relationship One to Many with GroupMembers--

        builder.Entity<Location>().ToTable("locations");
        builder.Entity<Location>().HasKey(l => l.Id);
        builder.Entity<Location>().Property(l => l.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Location>().Property(l => l.Description).IsRequired().HasMaxLength(60);
        builder.Entity<Location>().Property(l => l.CreatedAt).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Location>().Property(l => l.IsActive).IsRequired();

        builder.Entity<Role>().ToTable("roles");
        builder.Entity<Role>().HasKey(r => r.Id);
        builder.Entity<Role>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(15);
        builder.Entity<Role>().Property(r => r.CreatedAt).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Role>().Property(r => r.IsActive).IsRequired();
    }
}