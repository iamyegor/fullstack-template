﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240802174617_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("boolean")
                        .HasColumnName("is_email_verified");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Domain.Users.User", b =>
                {
                    b.OwnsOne("Domain.Users.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("email");

                            b1.HasKey("UserId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Domain.Users.ValueObjects.Login", "Login", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("login");

                            b1.HasKey("UserId");

                            b1.HasIndex("Value")
                                .IsUnique();

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Domain.Users.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("HashedPassword")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("hashed_password");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsMany("Domain.Users.ValueObjects.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("id"));

                            b1.Property<DateTime>("ExpiryTime")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("expiry_time");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("value");

                            b1.Property<Guid?>("user_id")
                                .HasColumnType("uuid");

                            b1.HasKey("id");

                            b1.HasIndex("user_id");

                            b1.ToTable("user_refresh_tokens", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("user_id");

                            b1.OwnsOne("Domain.Users.ValueObjects.DeviceId", "DeviceId", b2 =>
                                {
                                    b2.Property<int>("RefreshTokenid")
                                        .HasColumnType("integer");

                                    b2.Property<Guid>("Value")
                                        .HasColumnType("uuid")
                                        .HasColumnName("device_id");

                                    b2.HasKey("RefreshTokenid");

                                    b2.ToTable("user_refresh_tokens");

                                    b2.WithOwner()
                                        .HasForeignKey("RefreshTokenid");
                                });

                            b1.Navigation("DeviceId")
                                .IsRequired();
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Login")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}