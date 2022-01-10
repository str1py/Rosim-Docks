﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RosreestDocks.Contexts;

namespace RosreestDocks.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20220110194446_RequestUpdate")]
    partial class RequestUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.12");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RosreestDocks.Models.AgencyAcronymModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AcronymDatPad")
                        .HasColumnType("longtext");

                    b.Property<string>("AcronymImPad")
                        .HasColumnType("longtext");

                    b.Property<string>("AcronymRodPad")
                        .HasColumnType("longtext");

                    b.Property<string>("AcronymTvorPad")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EditTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastEditorId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LastEditorId");

                    b.ToTable("Acronyms");
                });

            modelBuilder.Entity("RosreestDocks.Models.AgencyModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AcronymId")
                        .HasColumnType("int");

                    b.Property<string>("AddInfo")
                        .HasColumnType("longtext");

                    b.Property<string>("Adress")
                        .HasColumnType("longtext");

                    b.Property<string>("AgencyINN")
                        .HasColumnType("longtext");

                    b.Property<string>("AgencyStatus")
                        .HasColumnType("longtext");

                    b.Property<string>("CityAndZip")
                        .HasColumnType("longtext");

                    b.Property<int?>("DirectorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EditTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastEditorId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("NameDatPad")
                        .HasColumnType("longtext");

                    b.Property<string>("NameImPad")
                        .HasColumnType("longtext");

                    b.Property<string>("NameRodPad")
                        .HasColumnType("longtext");

                    b.Property<string>("NameTvorPad")
                        .HasColumnType("longtext");

                    b.Property<bool>("Regulation")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("RegulationName")
                        .HasColumnType("longtext");

                    b.Property<int?>("SecondDirectorId")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AcronymId");

                    b.HasIndex("DirectorId");

                    b.HasIndex("LastEditorId");

                    b.HasIndex("SecondDirectorId");

                    b.ToTable("Agency");
                });

            modelBuilder.Entity("RosreestDocks.Models.AppealModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .HasColumnType("longtext");

                    b.Property<string>("Number")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Appeals");
                });

            modelBuilder.Entity("RosreestDocks.Models.Common.ArticlesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("RosreestDocks.Models.DirectorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddInfo")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Director");
                });

            modelBuilder.Entity("RosreestDocks.Models.DocCategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DocCategories");
                });

            modelBuilder.Entity("RosreestDocks.Models.DockStatusModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DocStatus");
                });

            modelBuilder.Entity("RosreestDocks.Models.DockTypeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("DocType");
                });

            modelBuilder.Entity("RosreestDocks.Models.DocumentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Discription")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("RosreestDocks.Models.FoivModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("EditTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FoivDatPad")
                        .HasColumnType("longtext");

                    b.Property<string>("FoivRodPad")
                        .HasColumnType("longtext");

                    b.Property<string>("FoivTvorPad")
                        .HasColumnType("longtext");

                    b.Property<string>("LastEditorId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LastEditorId");

                    b.ToTable("Foiv");
                });

            modelBuilder.Entity("RosreestDocks.Models.ImportanceState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Importance");
                });

            modelBuilder.Entity("RosreestDocks.Models.ManageRightsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("RightsRodPad")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ManageRights");
                });

            modelBuilder.Entity("RosreestDocks.Models.NoteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreatorId")
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("ImportanceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ImportanceId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("RosreestDocks.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("RosreestDocks.Models.RequestModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AddInfo")
                        .HasColumnType("longtext");

                    b.Property<int?>("ArticlesId")
                        .HasColumnType("int");

                    b.Property<bool>("BuildingsString")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CreateUserId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DocDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DocName")
                        .HasColumnType("longtext");

                    b.Property<int?>("DockTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("FirstFoivAppealId")
                        .HasColumnType("int");

                    b.Property<int?>("FirstFoivId")
                        .HasColumnType("int");

                    b.Property<bool>("IsRosim")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("ManageRightsFromId")
                        .HasColumnType("int");

                    b.Property<int?>("ManageRightsToId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyCount")
                        .HasColumnType("int");

                    b.Property<string>("PropertyDiscription")
                        .HasColumnType("longtext");

                    b.Property<int?>("RecipientAgencyId")
                        .HasColumnType("int");

                    b.Property<int?>("RecipientAppealId")
                        .HasColumnType("int");

                    b.Property<int?>("RosimAppealId")
                        .HasColumnType("int");

                    b.Property<int?>("SecondFoivAppealId")
                        .HasColumnType("int");

                    b.Property<int?>("SecondFoivId")
                        .HasColumnType("int");

                    b.Property<string>("SendNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("SoprovodNumber")
                        .HasColumnType("longtext");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("TransferAgencyId")
                        .HasColumnType("int");

                    b.Property<int?>("TransferAppealId")
                        .HasColumnType("int");

                    b.Property<int?>("TypeOfPropertyId")
                        .HasColumnType("int");

                    b.Property<int>("WhatAnnex")
                        .HasColumnType("int");

                    b.Property<int>("WhoApplied")
                        .HasColumnType("int");

                    b.Property<int>("WorkNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticlesId");

                    b.HasIndex("CreateUserId");

                    b.HasIndex("DockTypeId");

                    b.HasIndex("FirstFoivAppealId");

                    b.HasIndex("FirstFoivId");

                    b.HasIndex("ManageRightsFromId");

                    b.HasIndex("ManageRightsToId");

                    b.HasIndex("RecipientAgencyId");

                    b.HasIndex("RecipientAppealId");

                    b.HasIndex("RosimAppealId");

                    b.HasIndex("SecondFoivAppealId");

                    b.HasIndex("SecondFoivId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TransferAgencyId");

                    b.HasIndex("TransferAppealId");

                    b.HasIndex("TypeOfPropertyId");

                    b.ToTable("Request");
                });

            modelBuilder.Entity("RosreestDocks.Models.TypeOfPropertyModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("PropertyRodPad")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TypeOfPropertyModels");
                });

            modelBuilder.Entity("RosreestDocks.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("MemberSince")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("User");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RosreestDocks.Models.AgencyAcronymModel", b =>
                {
                    b.HasOne("RosreestDocks.Models.User", "LastEditor")
                        .WithMany()
                        .HasForeignKey("LastEditorId");

                    b.Navigation("LastEditor");
                });

            modelBuilder.Entity("RosreestDocks.Models.AgencyModel", b =>
                {
                    b.HasOne("RosreestDocks.Models.AgencyAcronymModel", "Acronym")
                        .WithMany()
                        .HasForeignKey("AcronymId");

                    b.HasOne("RosreestDocks.Models.DirectorModel", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorId");

                    b.HasOne("RosreestDocks.Models.User", "LastEditor")
                        .WithMany()
                        .HasForeignKey("LastEditorId");

                    b.HasOne("RosreestDocks.Models.DirectorModel", "SecondDirector")
                        .WithMany()
                        .HasForeignKey("SecondDirectorId");

                    b.Navigation("Acronym");

                    b.Navigation("Director");

                    b.Navigation("LastEditor");

                    b.Navigation("SecondDirector");
                });

            modelBuilder.Entity("RosreestDocks.Models.DirectorModel", b =>
                {
                    b.HasOne("RosreestDocks.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("RosreestDocks.Models.DocumentModel", b =>
                {
                    b.HasOne("RosreestDocks.Models.DocCategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RosreestDocks.Models.FoivModel", b =>
                {
                    b.HasOne("RosreestDocks.Models.User", "LastEditor")
                        .WithMany()
                        .HasForeignKey("LastEditorId");

                    b.Navigation("LastEditor");
                });

            modelBuilder.Entity("RosreestDocks.Models.NoteModel", b =>
                {
                    b.HasOne("RosreestDocks.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("RosreestDocks.Models.ImportanceState", "Importance")
                        .WithMany()
                        .HasForeignKey("ImportanceId");

                    b.Navigation("Creator");

                    b.Navigation("Importance");
                });

            modelBuilder.Entity("RosreestDocks.Models.RequestModel", b =>
                {
                    b.HasOne("RosreestDocks.Models.Common.ArticlesModel", "Articles")
                        .WithMany()
                        .HasForeignKey("ArticlesId");

                    b.HasOne("RosreestDocks.Models.User", "CreateUser")
                        .WithMany()
                        .HasForeignKey("CreateUserId");

                    b.HasOne("RosreestDocks.Models.DockTypeModel", "DockType")
                        .WithMany()
                        .HasForeignKey("DockTypeId");

                    b.HasOne("RosreestDocks.Models.AppealModel", "FirstFoivAppeal")
                        .WithMany()
                        .HasForeignKey("FirstFoivAppealId");

                    b.HasOne("RosreestDocks.Models.FoivModel", "FirstFoiv")
                        .WithMany()
                        .HasForeignKey("FirstFoivId");

                    b.HasOne("RosreestDocks.Models.ManageRightsModel", "ManageRightsFrom")
                        .WithMany()
                        .HasForeignKey("ManageRightsFromId");

                    b.HasOne("RosreestDocks.Models.ManageRightsModel", "ManageRightsTo")
                        .WithMany()
                        .HasForeignKey("ManageRightsToId");

                    b.HasOne("RosreestDocks.Models.AgencyModel", "RecipientAgency")
                        .WithMany()
                        .HasForeignKey("RecipientAgencyId");

                    b.HasOne("RosreestDocks.Models.AppealModel", "RecipientAppeal")
                        .WithMany()
                        .HasForeignKey("RecipientAppealId");

                    b.HasOne("RosreestDocks.Models.AppealModel", "RosimAppeal")
                        .WithMany()
                        .HasForeignKey("RosimAppealId");

                    b.HasOne("RosreestDocks.Models.AppealModel", "SecondFoivAppeal")
                        .WithMany()
                        .HasForeignKey("SecondFoivAppealId");

                    b.HasOne("RosreestDocks.Models.FoivModel", "SecondFoiv")
                        .WithMany()
                        .HasForeignKey("SecondFoivId");

                    b.HasOne("RosreestDocks.Models.DockStatusModel", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("RosreestDocks.Models.AgencyModel", "TransferAgency")
                        .WithMany()
                        .HasForeignKey("TransferAgencyId");

                    b.HasOne("RosreestDocks.Models.AppealModel", "TransferAppeal")
                        .WithMany()
                        .HasForeignKey("TransferAppealId");

                    b.HasOne("RosreestDocks.Models.TypeOfPropertyModel", "TypeOfProperty")
                        .WithMany()
                        .HasForeignKey("TypeOfPropertyId");

                    b.Navigation("Articles");

                    b.Navigation("CreateUser");

                    b.Navigation("DockType");

                    b.Navigation("FirstFoiv");

                    b.Navigation("FirstFoivAppeal");

                    b.Navigation("ManageRightsFrom");

                    b.Navigation("ManageRightsTo");

                    b.Navigation("RecipientAgency");

                    b.Navigation("RecipientAppeal");

                    b.Navigation("RosimAppeal");

                    b.Navigation("SecondFoiv");

                    b.Navigation("SecondFoivAppeal");

                    b.Navigation("Status");

                    b.Navigation("TransferAgency");

                    b.Navigation("TransferAppeal");

                    b.Navigation("TypeOfProperty");
                });
#pragma warning restore 612, 618
        }
    }
}
