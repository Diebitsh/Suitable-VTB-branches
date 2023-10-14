using Domain;
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

            modelBuilder.Entity<Schedule>().HasData(new Schedule[]
            {
                new Schedule
                {
                    Id = Guid.Parse("3de0d07c-ddb7-4562-b342-4bdffe9bed7c"),
                    Monday = "09:00-18:00",
                    Tuesday = "09:00-18:00",
                    Wednesday = "09:00-18:00",
                    Thursday = "09:00-18:00",
                    Friday = "09:00-17:00",
                    Saturday = "Выходной",
                    Sunday = "Выходной",
                }
            });


            modelBuilder.Entity<Department>().HasData(new Department[]
            {
                new Department
                {
                    Id = Guid.Parse("9b60d282-15cb-41ac-ad2a-609e2f097d46"),
                    Name = "ДО «Солнечногорский» Филиала № 7701 Банка ВТБ (ПАО)",
                    Address = "Московская область, г. Солнечногорск, ул. Красная, д. 60",
                    ScheduleId = Guid.Parse("3de0d07c-ddb7-4562-b342-4bdffe9bed7c"),
                    Latitude = 56.184479,
                    Longitude = 36.984314,
                    MaxVisitors = 60
                },
                new Department
                {
                    Id = Guid.Parse("5e074170-2fa2-49cd-b080-225e17b13500"),
                    Name = "ДО «На Баранова» Филиала № 7701 Банка ВТБ (ПАО)",
                    Address = "Московская область, г. Солнечногорск, ул. Баранова, д. 1",
                    ScheduleId = Guid.Parse("3de0d07c-ddb7-4562-b342-4bdffe9bed7c"),
                    Latitude = 56.183239,
                    Longitude = 36.9757,
                    MaxVisitors = 70
                },
                new Department
                {
                    Id = Guid.Parse("667502f8-c82b-4c7e-83eb-4efe78871d14"),
                    Name = "ДО «Лобня» Филиала № 7701 Банка ВТБ (ПАО)",
                    Address = "Московская область, г. Лобня, ул. Ленина, д. 9",
                    ScheduleId = Guid.Parse("3de0d07c-ddb7-4562-b342-4bdffe9bed7c"),
                    Latitude = 56.184479,
                    Longitude = 36.984314,
                    MaxVisitors = 60
                },
                new Department
                {
                    Id = Guid.Parse("25e942c4-e807-4ae9-9768-04a502bf7bdd"),
                    Name = "ДО «Солнечногорский» Филиала № 7701 Банка ВТБ (ПАО)",
                    Address = "Московская область, г. Солнечногорск, ул. Красная, д. 60",
                    ScheduleId = Guid.Parse("3de0d07c-ddb7-4562-b342-4bdffe9bed7c"),
                    Latitude = 56.184479,
                    Longitude = 36.984314,
                    MaxVisitors = 60
                },
            });

            modelBuilder.Entity<BankService>().HasData(new BankService[]
            {
                new BankService
                {
                    Id = Guid.Parse("aaeb2e2c-af0f-4714-8f90-244c1a2e99f5"),
                    Name = "Кредит наличными",
                    Description = "Получить кредит наличными"
                },
                new BankService
                {
                    Id = Guid.Parse("992d01cb-9893-4264-b08c-34a5c1b337b2"),
                    Name = "Рефинансирование",
                    Description = "Получить рефинансирование"
                },
                new BankService
                {
                    Id = Guid.Parse("8847aaaa-66fc-4ab5-a2e5-8938df1fd02e"),
                    Name = "Экспресс кредит",
                    Description = "Получить экспресс кредит"
                },
                new BankService
                {
                    Id = Guid.Parse("572d672a-d6a7-43f6-8c1a-160f96db2c52"),
                    Name = "Автокредит",
                    Description = "Получить автокредит"
                },
                new BankService
                {
                    Id = Guid.Parse("85381e94-5792-4258-84d3-c88d1661ba73"),
                    Name = "Дебетовые карты",
                    Description = "Работа с дебетовыми картами"
                },
                new BankService
                {
                    Id = Guid.Parse("80b6edbe-9cdc-494a-b6cf-13b3282144fb"),
                    Name = "Кредитные карты",
                    Description = "Работа с кредитными картами"
                }
            });

            modelBuilder.Entity<BankServiceToDepartment>().HasData(new BankServiceToDepartment[]
            {
                new BankServiceToDepartment
                {
                    BankServiceId = Guid.Parse("aaeb2e2c-af0f-4714-8f90-244c1a2e99f5"),
                    DepartmentId = Guid.Parse("9b60d282-15cb-41ac-ad2a-609e2f097d46")
                },
                new BankServiceToDepartment
                {
                    BankServiceId = Guid.Parse("992d01cb-9893-4264-b08c-34a5c1b337b2"),
                    DepartmentId = Guid.Parse("9b60d282-15cb-41ac-ad2a-609e2f097d46")
                },
                new BankServiceToDepartment
                {
                    BankServiceId = Guid.Parse("8847aaaa-66fc-4ab5-a2e5-8938df1fd02e"),
                    DepartmentId = Guid.Parse("9b60d282-15cb-41ac-ad2a-609e2f097d46")
                },
                new BankServiceToDepartment
                {
                    BankServiceId = Guid.Parse("572d672a-d6a7-43f6-8c1a-160f96db2c52"),
                    DepartmentId = Guid.Parse("9b60d282-15cb-41ac-ad2a-609e2f097d46")
                },
            });
        }
    }
}
