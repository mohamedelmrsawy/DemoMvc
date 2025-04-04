using Demo.DataAccess.Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Configuration.EmployeeConfiguration
{
    class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).HasColumnType("varchar(150)");
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");
        
        }
    }
}
