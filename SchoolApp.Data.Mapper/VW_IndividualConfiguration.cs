using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolApp.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Data.Mapper
{
    public class VW_IndividualConfiguration : IEntityTypeConfiguration<VW_Individual>
    {
        public void Configure(EntityTypeBuilder<VW_Individual> builder)
        {
            builder.ToTable("VW_Individual");
            builder.HasKey(t => t.IndividualId);
        }
    }
}
