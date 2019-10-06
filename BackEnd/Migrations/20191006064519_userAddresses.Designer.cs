﻿// <auto-generated />
using System;
using FullStack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FullStack.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191006064519_userAddresses")]
    partial class userAddresses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099");

            modelBuilder.Entity("FullStack.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("email");

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<string>("nationalId");

                    b.Property<byte[]>("passwordHash");

                    b.Property<byte[]>("passwordSalt");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("FullStack.Models.UserAddress", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address");

                    b.Property<int>("userId");

                    b.HasKey("id");

                    b.HasIndex("userId");

                    b.ToTable("UserAddress");
                });

            modelBuilder.Entity("FullStack.Models.UserAddress", b =>
                {
                    b.HasOne("FullStack.Models.User", "user")
                        .WithMany("userAddresses")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}