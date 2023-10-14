using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class Workload : IEntity
    {
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        public DateTime LoggingDate { get; set; }

        /// <summary>
        /// Сколько вошлы/выщло
        /// </summary>
        public int Visitors { get; set; }

        public bool? IsEntered { get; set; }

        public class Map : IEntityTypeConfiguration<Workload>
        {
            public void Configure(EntityTypeBuilder<Workload> builder)
            {
                builder.ToTable("workloads");

                builder.HasKey(x => x.Id);

                builder.HasOne(x => x.Department).WithMany(x => x.Workloads).HasForeignKey(x => x.DepartmentId);
            }
        }
    }
}