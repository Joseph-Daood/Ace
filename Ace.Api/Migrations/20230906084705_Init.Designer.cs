﻿// <auto-generated />
using System;
using Ace.Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ace.Api.Migrations
{
    [DbContext(typeof(AceDbContext))]
    [Migration("20230906084705_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ace.Model.Community", b =>
                {
                    b.Property<int>("CommunityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommunityId"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MainEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NotificationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("modifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CommunityId");

                    b.HasIndex("NotificationId");

                    b.ToTable("Communities");
                });

            modelBuilder.Entity("Ace.Model.Family", b =>
                {
                    b.Property<int>("FamilyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FamilyId"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FamilyId");

                    b.ToTable("Families");
                });

            modelBuilder.Entity("Ace.Model.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<DateTime?>("ActiveDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("BaptismalDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Contry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CprNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FamilyId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMainFamilyPerson")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMale")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMarried")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUnderAge")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("MovingDatetoNewCommuity")
                        .HasColumnType("date");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("date");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNumber1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelephoneNumber2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("WeddingDate")
                        .HasColumnType("date");

                    b.Property<int?>("communityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("modifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MemberId");

                    b.HasIndex("FamilyId");

                    b.HasIndex("communityId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Ace.Model.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NoteficationFrom")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("modifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Ace.Shared.Build", b =>
                {
                    b.Property<string>("BuildNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("modifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BuildNumber");

                    b.ToTable("Builds");
                });

            modelBuilder.Entity("Ace.Model.Community", b =>
                {
                    b.HasOne("Ace.Model.Notification", null)
                        .WithMany("ToCommunities")
                        .HasForeignKey("NotificationId");
                });

            modelBuilder.Entity("Ace.Model.Member", b =>
                {
                    b.HasOne("Ace.Model.Family", "Family")
                        .WithMany("Members")
                        .HasForeignKey("FamilyId");

                    b.HasOne("Ace.Model.Community", "Community")
                        .WithMany("Members")
                        .HasForeignKey("communityId");

                    b.Navigation("Community");

                    b.Navigation("Family");
                });

            modelBuilder.Entity("Ace.Model.Community", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Ace.Model.Family", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Ace.Model.Notification", b =>
                {
                    b.Navigation("ToCommunities");
                });
#pragma warning restore 612, 618
        }
    }
}
