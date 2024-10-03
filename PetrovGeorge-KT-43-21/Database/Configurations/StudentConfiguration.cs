using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetrovGeorge_KT_43_21.Helpers;
using PetrovGeorge_KT_43_21.Models;
using System.Runtime.CompilerServices;

namespace PetrovGeorge_KT_43_21.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            builder.Property(p => p.StudentId)
                     .ValueGeneratedOnAdd();

            builder.Property(p => p.StudentId)
                .HasColumnName("student_id")
                .HasComment("Идентификатор записи студента");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя студента");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия студента");

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("c_student_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество студента");

            builder.Property(p => p.GroupId)
                .IsRequired()
                .HasColumnName("c_student_group_id")
                .HasComment("Идентификатор группы");

            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(p => p.Group)
                .AutoInclude();
        }
    }
}
