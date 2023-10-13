﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Workload> Workloads { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<BankService> BankServices { get; set; }
        public DbSet<BankServiceToDepartment> BankServicesToDepartments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration<Department>(new Department.Map());
            modelBuilder.ApplyConfiguration<Schedule>(new Schedule.Map());
            modelBuilder.ApplyConfiguration<Workload>(new Workload.Map());
            modelBuilder.ApplyConfiguration<BankService>(new BankService.Map());
            modelBuilder.ApplyConfiguration<BankServiceToDepartment>(new BankServiceToDepartment.Map());
        }
    }
}
