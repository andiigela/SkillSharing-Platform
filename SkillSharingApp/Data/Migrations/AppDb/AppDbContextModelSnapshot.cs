using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillSharingApp_DAL.Data;


namespace SkillSharingApp.Migrations.AppDb
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SkillSharingApp_DAL.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("imageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("SkillSharingApp_DAL.Models.Tutorial", b =>
                {
                    b.Property<int>("TutorialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TutorialId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instructions")
            modelBuilder.Entity("SkillSharingApp_DAL.DAL_DTOs.ApplicationUser.CreateApplicationUserDto_DAL", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("ComputerScience")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Math")
                        .HasColumnType("bit");

                    b.Property<bool>("Medicine")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("CreateApplicationUserDto_DAL");
                });

            modelBuilder.Entity("SkillSharingApp_DAL.Models.Attendance", b =>
                {
                    b.Property<string>("CreateApplicationUserDto_DALId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.Property<bool>("isAttended")
                        .HasColumnType("bit");

                    b.HasKey("CreateApplicationUserDto_DALId", "WorkshopId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("SkillSharingApp_DAL.Models.Image", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("SkillSharingApp_DAL.Models.Workshop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Availability")
                        .HasColumnType("datetime2");

                    b.Property<long>("Capacity")
                        .HasColumnType("bigint");

                    b.Property<string>("CreateApplicationUserDto_DALId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TutorialId");

                    b.ToTable("Tutorials");
                    b.Property<int>("isVisible")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreateApplicationUserDto_DALId");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("SkillSharingApp_DAL.Models.Attendance", b =>
                {
                    b.HasOne("SkillSharingApp_DAL.DAL_DTOs.ApplicationUser.CreateApplicationUserDto_DAL", "CreateApplicationUserDto_DAL")
                        .WithMany()
                        .HasForeignKey("CreateApplicationUserDto_DALId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillSharingApp_DAL.Models.Workshop", "Workshop")
                        .WithMany("Attendances")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreateApplicationUserDto_DAL");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("SkillSharingApp_DAL.Models.Image", b =>
                {
                    b.HasOne("SkillSharingApp_DAL.Models.Workshop", "Workshop")
                        .WithMany("Images")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("SkillSharingApp_DAL.Models.Workshop", b =>
                {
                    b.HasOne("SkillSharingApp_DAL.DAL_DTOs.ApplicationUser.CreateApplicationUserDto_DAL", "CreateApplicationUserDto_DAL")
                        .WithMany("Workshops")
                        .HasForeignKey("CreateApplicationUserDto_DALId");

                    b.Navigation("CreateApplicationUserDto_DAL");
                });

            modelBuilder.Entity("SkillSharingApp_DAL.DAL_DTOs.ApplicationUser.CreateApplicationUserDto_DAL", b =>
                {
                    b.Navigation("Workshops");
                });

            modelBuilder.Entity("SkillSharingApp_DAL.Models.Workshop", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Images");
                });
        }
    }
}
