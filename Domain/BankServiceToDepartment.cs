using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain
{
    public class BankServiceToDepartment
    {
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        public Guid BankServiceId { get; set; }
        public BankService BankService { get; set; }

        public class Map : IEntityTypeConfiguration<BankServiceToDepartment>
        {
            public void Configure(EntityTypeBuilder<BankServiceToDepartment> builder)
            {
                builder.ToTable("bank_service_to_department");

                builder.HasKey(x => new { x.DepartmentId, x.BankServiceId });

                builder.HasOne(x => x.Department).WithMany().HasForeignKey(x => x.DepartmentId);
                builder.HasOne(x => x.BankService).WithMany().HasForeignKey(x => x.BankServiceId);
            }
        }
    }
}
