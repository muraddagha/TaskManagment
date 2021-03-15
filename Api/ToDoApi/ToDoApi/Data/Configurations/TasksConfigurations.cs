  using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Data.Entities;

namespace ToDoApi.Data.Configurations
{
    public class TasksConfigurations : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.Property(t => t.Node).IsRequired();
            builder.Property(t => t.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.Property(t => t.EndDate).IsRequired();
            builder.Property(t => t.DoneNote).HasMaxLength(200);
            builder.Property(t => t.IsDone).HasDefaultValue(false);
            builder.HasOne(t => t.Categories).WithMany().HasForeignKey(t => t.CategoryId).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Tasks");
        }
    }
}
