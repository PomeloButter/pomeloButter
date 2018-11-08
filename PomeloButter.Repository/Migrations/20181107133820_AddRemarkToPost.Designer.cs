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
    [Migration("20181107133820_AddRemarkToPost")]
    partial class AddRemarkToPost
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PomeloButter.Model.TableModel.Post", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<byte[]>("Body")
                        .IsRequired()
                        .HasColumnType("blob");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Post");
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

                    b.Property<string>("UserName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}