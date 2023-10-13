using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class Schedule : IEntity
    {
        public string Monday { get; set; }
        public string Tuesday { get; set; }
        public string Wednesday { get; set; }
        public string Thursday { get; set; }
        public string Friday { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }

        public class Map : IEntityTypeConfiguration<Schedule>
        {
            public void Configure(EntityTypeBuilder<Schedule> builder)
            {
                builder.ToTable("schedule");

                builder.HasKey(x => x.Id);
            }
        }
    }
}