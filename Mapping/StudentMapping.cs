using _18_MVC_Example.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _18_MVC_Example.Mapping
{
    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.StudentId);

            builder
                    .HasOne(p => p.School)
                    .WithMany(t => t.Students)
                    .HasForeignKey(x => x.SchoolID)
                    .IsRequired();
        }
    }
}
