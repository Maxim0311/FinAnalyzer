using FinAnalyzer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinAnalyzer.Data.EntityFramework.ModelConfiguration
{
    public class RequestToJoinConfiguration : BaseEntityConfiguration<RequestToJoin>
    {
        public override void Configure(EntityTypeBuilder<RequestToJoin> builder)
        {
            base.Configure(builder);

            builder.ToTable("request_to_join");
            builder.Property(p => p.PersonId).HasColumnName("person_id");
            builder.Property(p => p.RoomId).HasColumnName("room_id");
        }
    }
}
