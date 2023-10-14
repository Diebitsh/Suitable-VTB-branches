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

        public string Address { get; set; }

        public string ImageUrl { get; set; }

        /// <summary>
        /// Максимальное число посетителей
        /// </summary>
        public int MaxVisitors { get; set; }

        public class Map : IEntityTypeConfiguration<Department>
        {
            public void Configure(EntityTypeBuilder<Department> builder)
            {
                builder.ToTable("department");

                builder.HasKey(x => x.Id);

                builder.HasOne(x => x.Schedule).WithMany().HasForeignKey(x => x.ScheduleId);
            }
        }
    }
}
