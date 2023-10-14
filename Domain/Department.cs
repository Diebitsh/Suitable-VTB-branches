using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain
{
    public class Department : IEntity
    {
        public string Name { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Область
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Дом
        /// </summary>
        public string Building { get; set; }

        /// <summary>
        /// Этаж
        /// </summary>
        public string? Floor { get; set; }

        public List<BankServiceToDepartment> BankServices { get; set; }

        /// <summary>
        /// Максимальное число посетителей
        /// </summary>
        public int MaxVisitors { get; set; }

        public ICollection<Workload> Workloads { get; set; }

        public class Map : IEntityTypeConfiguration<Department>
        {
            public void Configure(EntityTypeBuilder<Department> builder)
            {
                builder.ToTable("department");

                builder.HasKey(x => x.Id);

                builder.HasOne(x => x.Schedule).WithMany().HasForeignKey(x => x.ScheduleId);
                builder.HasMany(x => x.BankServices).WithOne(x => x.Department).HasForeignKey(x => x.DepartmentId);
                builder.HasMany(x => x.Workloads).WithOne(x => x.Department).HasForeignKey(x => x.DepartmentId);
            }
        }
    }
}
