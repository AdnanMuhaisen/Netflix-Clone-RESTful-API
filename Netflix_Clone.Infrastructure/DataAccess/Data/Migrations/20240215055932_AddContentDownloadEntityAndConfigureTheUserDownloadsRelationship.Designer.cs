﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Netflix_Clone.Infrastructure.DataAccess.Data.Contexts;

#nullable disable

namespace Netflix_Clone.Infrastructure.DataAccess.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240215055932_AddContentDownloadEntityAndConfigureTheUserDownloadsRelationship")]
    partial class AddContentDownloadEntityAndConfigureTheUserDownloadsRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.Award", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AwardTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("tbl_Awards", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContentGenreId")
                        .HasColumnType("int");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<bool>("IsAvailableToDownload")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("MinimumAgeToWatch")
                        .HasColumnType("int");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Synopsis")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TotalNumberOfDownloads")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("Id");

                    b.HasIndex("ContentGenreId");

                    b.HasIndex("DirectorId");

                    b.HasIndex("LanguageId");

                    b.ToTable("tbl_Contents", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Content");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.ContentActor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("ContentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("ContentId");

                    b.ToTable("tbl_ContentsActors", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.ContentAward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AwardId")
                        .HasColumnType("int");

                    b.Property<int>("ContentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AwardId");

                    b.HasIndex("ContentId");

                    b.ToTable("tbl_ContentsAwards", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.ContentDownload", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ContentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ContentId");

                    b.ToTable("tbl_UsersDownloads", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.ContentGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tbl_ContentGenres", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.ContentLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("tbl_ContentLanguages", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.ContentTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContentId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("TagId");

                    b.ToTable("tbl_ContentsTags", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tbl_Persons", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.SubscriptionPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Plan")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("tbl_SubscriptionPlans", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.SubscriptionPlanFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Feature")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.ToTable("tbl_SubscriptionPlanFeatures", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.SubscriptionPlanSubscriptionPlanFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SubscriptionPlanFeatureId")
                        .HasColumnType("int");

                    b.Property<int>("SubscriptionPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionPlanFeatureId");

                    b.HasIndex("SubscriptionPlanId");

                    b.ToTable("tbl_SubscriptionPlansFeatures", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.TVShowEpisode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EpisodeNumber")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("LengthInMinutes")
                        .HasColumnType("int");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("int");

                    b.Property<int>("TVShowId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("tbl_TVShowEpisodes", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.TVShowSeason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DirectoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SeasonName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("int");

                    b.Property<int>("TVShowId")
                        .HasColumnType("int");

                    b.Property<int>("TotalNumberOfEpisodes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TVShowId");

                    b.ToTable("tbl_TVShowSeason", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TagValue")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tbl_Tags", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.UserSubscriptionPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsEnded")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubscriptionPlanId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionPlanId");

                    b.HasIndex("UserId");

                    b.ToTable("tbl_UsersSubscriptions", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.UserWatchHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ContentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ContentId");

                    b.ToTable("tbl_UsersWatchHistory", (string)null);
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.Movie", b =>
                {
                    b.HasBaseType("Netflix_Clone.Domain.Entities.Content");

                    b.Property<int>("LengthInMinutes")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Movie");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.TVShow", b =>
                {
                    b.HasBaseType("Netflix_Clone.Domain.Entities.Content");

                    b.Property<int>("TotalNumberOfEpisodes")
                        .HasColumnType("int");

                    b.Property<int>("TotalNumberOfSeasons")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("TVShow");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.Actor", b =>
                {
                    b.HasBaseType("Netflix_Clone.Domain.Entities.Person");

                    b.HasDiscriminator().HasValue("Actor");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.Director", b =>
                {
                    b.HasBaseType("Netflix_Clone.Domain.Entities.Person");

                    b.HasDiscriminator().HasValue("Director");
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
                    b.HasOne("Netflix_Clone.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Netflix_Clone.Domain.Entities.ApplicationUser", null)
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

                    b.HasOne("Netflix_Clone.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Netflix_Clone.Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.Content", b =>
                {
                    b.HasOne("Netflix_Clone.Domain.Entities.ContentGenre", null)
                        .WithMany("GenreContents")
                        .HasForeignKey("ContentGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Netflix_Clone.Domain.Entities.Director", null)
                        .WithMany("Contents")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Netflix_Clone.Domain.Entities.ContentLanguage", "ContentLanguage")
                        .WithMany("LanguageContents")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContentLanguage");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.ContentActor", b =>
                {
                    b.HasOne("Netflix_Clone.Domain.Entities.Actor", "Actor")
                        .WithMany("ContentsActors")
                        .HasForeignKey("ActorId");

                    b.HasOne("Netflix_Clone.Domain.Entities.Content", "Content")
                        .WithMany("ContentsActors")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.ContentAward", b =>
                {
                    b.HasOne("Netflix_Clone.Domain.Entities.Award", "Award")
                        .WithMany("ContentsAwards")
                        .HasForeignKey("AwardId");

                    b.HasOne("Netflix_Clone.Domain.Entities.Content", "Content")
                        .WithMany("ContentsAwards")
                        .HasForeignKey("ContentId");

                    b.Navigation("Award");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.ContentDownload", b =>
                {
                    b.HasOne("Netflix_Clone.Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("ContentsDownloads")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Netflix_Clone.Domain.Entities.Content", "Content")
                        .WithMany("ContentsDownloads")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.ContentTag", b =>
                {
                    b.HasOne("Netflix_Clone.Domain.Entities.Content", "Content")
                        .WithMany("ContentsTags")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Netflix_Clone.Domain.Entities.Tag", "Tag")
                        .WithMany("ContentsTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Content");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.SubscriptionPlanSubscriptionPlanFeature", b =>
                {
                    b.HasOne("Netflix_Clone.Domain.Entities.SubscriptionPlanFeature", "SubscriptionPlanFeature")
                        .WithMany("SubscriptionPlansFeatures")
                        .HasForeignKey("SubscriptionPlanFeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Netflix_Clone.Domain.Entities.SubscriptionPlan", "SubscriptionPlan")
                        .WithMany("SubscriptionPlansFeatures")
                        .HasForeignKey("SubscriptionPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubscriptionPlan");

                    b.Navigation("SubscriptionPlanFeature");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.TVShowEpisode", b =>
                {
                    b.HasOne("Netflix_Clone.Domain.Entities.TVShowSeason", "Season")
                        .WithMany("Episodes")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Season");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.TVShowSeason", b =>
                {
                    b.HasOne("Netflix_Clone.Domain.Entities.TVShow", "TVShow")
                        .WithMany("Seasons")
                        .HasForeignKey("TVShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TVShow");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.UserSubscriptionPlan", b =>
                {
                    b.HasOne("Netflix_Clone.Domain.Entities.SubscriptionPlan", "SubscriptionPlan")
                        .WithMany("UsersSubscriptionPlans")
                        .HasForeignKey("SubscriptionPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Netflix_Clone.Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("UsersSubscriptionPlans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("SubscriptionPlan");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.UserWatchHistory", b =>
                {
                    b.HasOne("Netflix_Clone.Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("UsersHistory")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Netflix_Clone.Domain.Entities.Content", "Content")
                        .WithMany("UsersHistory")
                        .HasForeignKey("ContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Content");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("ContentsDownloads");

                    b.Navigation("UsersHistory");

                    b.Navigation("UsersSubscriptionPlans");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.Award", b =>
                {
                    b.Navigation("ContentsAwards");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.Content", b =>
                {
                    b.Navigation("ContentsActors");

                    b.Navigation("ContentsAwards");

                    b.Navigation("ContentsDownloads");

                    b.Navigation("ContentsTags");

                    b.Navigation("UsersHistory");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.ContentGenre", b =>
                {
                    b.Navigation("GenreContents");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.ContentLanguage", b =>
                {
                    b.Navigation("LanguageContents");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.SubscriptionPlan", b =>
                {
                    b.Navigation("SubscriptionPlansFeatures");

                    b.Navigation("UsersSubscriptionPlans");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.SubscriptionPlanFeature", b =>
                {
                    b.Navigation("SubscriptionPlansFeatures");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.TVShowSeason", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.Tag", b =>
                {
                    b.Navigation("ContentsTags");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.TVShow", b =>
                {
                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.Actor", b =>
                {
                    b.Navigation("ContentsActors");
                });

            modelBuilder.Entity("Netflix_Clone.Domain.Entities.Director", b =>
                {
                    b.Navigation("Contents");
                });
#pragma warning restore 612, 618
        }
    }
}
