﻿using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class UpdateDBContext :DbContext
{
    public UpdateDBContext()
    {
        
    }
    
    public UpdateDBContext(DbContextOptions<UpdateDBContext> options) : base(options)
    {
    }
    
    public  DbSet<Activity> Activities { get; set; }
    public DbSet<Community> Communities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=yonomas1995;Database=UpDateDB;", serverVersion);
        }
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);

        builder.Entity<Activity>().ToTable("activities");
        builder.Entity<Activity>().HasKey(p => p.Id);
        builder.Entity<Activity>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Activity>().Property(c => c.Title).HasMaxLength(60);
        builder.Entity<Activity>().Property(c => c.Description).HasMaxLength(240);
        builder.Entity<Activity>().Property(c => c.Address).HasMaxLength(60);
        builder.Entity<Activity>().Property(c => c.Date).HasMaxLength(20);

        builder.Entity<Community>().ToTable("communities");
        builder.Entity<Community>().HasKey(p => p.Id);
        builder.Entity<Community>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Community>().Property(c => c.Name).IsRequired().HasMaxLength(60);
        builder.Entity<Community>().Property(c => c.Description).IsRequired().HasMaxLength(240);
        builder.Entity<Community>().Property(c => c.CreatedAt).IsRequired().HasMaxLength(20);
    }
}