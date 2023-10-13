using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain
{
    /// <summary>
    /// Услуги, предоставляемые банком
    /// </summary>
    public class BankService : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public class Map : IEntityTypeConfiguration<BankService>
        {
            public void Configure(EntityTypeBuilder<BankService> builder)
            {
                builder.ToTable("bank_service");

                builder.HasKey(x => x.Id);
            }
        }
    }
}
