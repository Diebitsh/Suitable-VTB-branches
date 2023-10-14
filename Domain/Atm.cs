using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain
{   
    public class Atm: IEntity
    {
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; } 

        public class Map : IEntityTypeConfiguration<Atm>
        {
            public void Configure(EntityTypeBuilder<Atm> builder)
            {
                builder.ToTable("atms");

                builder.HasKey(x => x.Id);
            }
        }
    }
}

