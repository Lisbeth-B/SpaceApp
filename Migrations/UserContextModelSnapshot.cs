﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaceApp.Models;

namespace SpaceApp.Migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("SpaceApp.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nchar(11)")
                        .IsFixedLength(true);

                    b.Property<bool>("IsMarried")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWorker")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdNumber")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SpaceApp.Entity.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nchar(11)")
                        .IsFixedLength(true);

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdNumber")
                        .IsUnique();

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("SpaceApp.Entity.Worker", b =>
                {
                    b.HasOne("SpaceApp.Entity.User", "WorkerUser")
                        .WithOne("UserWorker")
                        .HasForeignKey("SpaceApp.Entity.Worker", "IdNumber")
                        .HasPrincipalKey("SpaceApp.Entity.User", "IdNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkerUser");
                });

            modelBuilder.Entity("SpaceApp.Entity.User", b =>
                {
                    b.Navigation("UserWorker");
                });
#pragma warning restore 612, 618
        }
    }
}
