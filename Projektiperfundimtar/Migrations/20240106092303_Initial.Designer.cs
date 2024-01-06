﻿// <auto-generated />
using System;
using Find_me_a_roommate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Find_me_a_roommate.Migrations
{
    [DbContext(typeof(OurContext))]
    [Migration("20240106092303_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Find_me_a_roommate.Announcements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DormitoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DormitoryId");

                    b.ToTable("Announcement");
                });

            modelBuilder.Entity("Find_me_a_roommate.Applications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnnouncementId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnnouncementId");

                    b.HasIndex("StudentsId");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("Find_me_a_roommate.Dormitories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dormitory");
                });

            modelBuilder.Entity("Find_me_a_roommate.DormitoryStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("DormitoryId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DormitoryId");

                    b.HasIndex("StudentId");

                    b.ToTable("DormitoryStudent");
                });

            modelBuilder.Entity("Find_me_a_roommate.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Find_me_a_roommate.Announcements", b =>
                {
                    b.HasOne("Find_me_a_roommate.Dormitories", "Dormitory")
                        .WithMany("Announcement")
                        .HasForeignKey("DormitoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dormitory");
                });

            modelBuilder.Entity("Find_me_a_roommate.Applications", b =>
                {
                    b.HasOne("Find_me_a_roommate.Announcements", "Announcement")
                        .WithMany("Application")
                        .HasForeignKey("AnnouncementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Find_me_a_roommate.Students", "Students")
                        .WithMany("Application")
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Announcement");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Find_me_a_roommate.DormitoryStudent", b =>
                {
                    b.HasOne("Find_me_a_roommate.Dormitories", "Dormitory")
                        .WithMany("DormitoryStudent")
                        .HasForeignKey("DormitoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Find_me_a_roommate.Students", "Student")
                        .WithMany("DormitoryStudent")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dormitory");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Find_me_a_roommate.Announcements", b =>
                {
                    b.Navigation("Application");
                });

            modelBuilder.Entity("Find_me_a_roommate.Dormitories", b =>
                {
                    b.Navigation("Announcement");

                    b.Navigation("DormitoryStudent");
                });

            modelBuilder.Entity("Find_me_a_roommate.Students", b =>
                {
                    b.Navigation("Application");

                    b.Navigation("DormitoryStudent");
                });
#pragma warning restore 612, 618
        }
    }
}
