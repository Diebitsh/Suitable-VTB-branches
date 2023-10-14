using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain
{   
    public class Atm: IEntity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        /// <summary>
        /// Почтовый индекс
        /// </summary>
        public string? ZipCode { get; set; }

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

