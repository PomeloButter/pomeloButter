﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PomeloButter.Repository.MySQL;

namespace PomeloButter.Repository.Migrations
{
    [DbContext(typeof(PomeloContext))]
    [Migration("20181106074709_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PomeloButter.Model.TableModel.Image", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("PomeloButter.Model.TableModel.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("PomeloButter.Model.TableModel.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Email");

                    b.Property<bool>("Gender");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("RoleId");

                    b.Property<string>("UserName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PomeloButter.Model.TableModel.Image", b =>
                {
                    b.HasOne("PomeloButter.Model.TableModel.User", "User")
                        .WithMany("ImageList")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("PomeloButter.Model.TableModel.User", b =>
                {
                    b.HasOne("PomeloButter.Model.TableModel.Role")
                        .WithMany("UserList")
                        .HasForeignKey("RoleId");
                });
#pragma warning restore 612, 618
        }
    }
}