﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectMunch.Persistence;

#nullable disable

namespace ProjectMunch.Persistence.Migrations
{
    [DbContext(typeof(MunchContext))]
    [Migration("20240320104218_FixedDataSeeding")]
    partial class FixedDataSeeding
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "31970cf7-e77c-416a-ac9d-f73ef2894111",
                            ConcurrencyStamp = "201323df-ce26-4ff3-bdb3-fafce7d9ec2a",
                            Name = "Verified",
                            NormalizedName = "VERIFIED"
                        },
                        new
                        {
                            Id = "1f45ef73-4344-4ce7-8619-b3a4ba013b32",
                            ConcurrencyStamp = "e968d8d2-89da-4478-9e8f-cbbf5d300e7a",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "cf51d8b9-5465-4149-8184-8b3dacd05c12",
                            ConcurrencyStamp = "dad59009-97ed-4f4d-8dfc-e708a4761714",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "156068d4-f2c2-48f6-808d-219e2de742d5",
                            RoleId = "cf51d8b9-5465-4149-8184-8b3dacd05c12"
                        },
                        new
                        {
                            UserId = "0712aaac-a550-461c-9051-6401ec876151",
                            RoleId = "31970cf7-e77c-416a-ac9d-f73ef2894111"
                        },
                        new
                        {
                            UserId = "0712aaac-a550-461c-9051-6401ec876151",
                            RoleId = "cf51d8b9-5465-4149-8184-8b3dacd05c12"
                        },
                        new
                        {
                            UserId = "c16a609f-7b0c-4d65-a002-d8c00a558c53",
                            RoleId = "1f45ef73-4344-4ce7-8619-b3a4ba013b32"
                        },
                        new
                        {
                            UserId = "c16a609f-7b0c-4d65-a002-d8c00a558c53",
                            RoleId = "31970cf7-e77c-416a-ac9d-f73ef2894111"
                        },
                        new
                        {
                            UserId = "c16a609f-7b0c-4d65-a002-d8c00a558c53",
                            RoleId = "cf51d8b9-5465-4149-8184-8b3dacd05c12"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProjectMunch.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c16a609f-7b0c-4d65-a002-d8c00a558c53",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9bc43052-e931-4a7e-aaa5-9ef0125ec8e0",
                            Email = "admin@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@EXAMPLE.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEMD16hI0kmUkdISF36b23FznrX+BsVpz3OXCLbzh7YsQfp7+ZH6o0Ul4c6pITpMHtQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e8c1dec2-5b8a-4eca-b214-8effaea2bd97",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "0712aaac-a550-461c-9051-6401ec876151",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a14857a7-4417-41df-b73a-7c6c83ed4c52",
                            Email = "verified@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "VERIFIED@EXAMPLE.COM",
                            NormalizedUserName = "VERIFIED",
                            PasswordHash = "AQAAAAIAAYagAAAAEPuVJnf+XvzsZWUpYCrozZ6/uzRZU9Lxip/BJPq1qryhh19ThMywpL3bkdBVCDmVkA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e59b4cdd-f78f-4780-885d-48e402a47080",
                            TwoFactorEnabled = false,
                            UserName = "verified"
                        },
                        new
                        {
                            Id = "156068d4-f2c2-48f6-808d-219e2de742d5",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "872d4735-bb62-4d7b-925d-1bbd7ded8f81",
                            Email = "user@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@EXAMPLE.COM",
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAIAAYagAAAAEAv1Yybfyt8PFI29O/brNDV+q2CqkEN89Hgq2jLRHgB5hPpOSNKn5PvEtj2vGHU94g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ef1469c9-4bc8-47d6-9520-d6d386d5d041",
                            TwoFactorEnabled = false,
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("ProjectMunch.Models.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Point>("Coordinate")
                        .IsRequired()
                        .HasColumnType("geography (point)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PointOfInterests");
                });

            modelBuilder.Entity("ProjectMunch.Models.Save", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("PointOfInterestId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Saves");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProjectMunch.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProjectMunch.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectMunch.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProjectMunch.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectMunch.Models.Save", b =>
                {
                    b.HasOne("ProjectMunch.Models.ApplicationUser", "User")
                        .WithMany("Saves")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectMunch.Models.ApplicationUser", b =>
                {
                    b.Navigation("Saves");
                });
#pragma warning restore 612, 618
        }
    }
}