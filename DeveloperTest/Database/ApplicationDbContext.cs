﻿using System;
using Microsoft.EntityFrameworkCore;
using DeveloperTest.Database.Models;

namespace DeveloperTest.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Job>()
                .HasKey(x => x.JobId);

            modelBuilder.Entity<Job>()
                .Property(x => x.JobId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Job>()
                .HasData(new Job
                {
                    JobId = 1,
                    Engineer = "Test",
                    When = new DateTime(2022, 2, 1, 12, 0, 0)
                });

            modelBuilder.Entity<Customer>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Customer>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Customer>()
                .HasData(new Customer
                {
                    Id = 1,
                    Name = "John",
                    Type = "Small"
                });
        }
    }
}
