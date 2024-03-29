﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Netflix_Clone.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Netflix_Clone.Infrastructure.DataAccess.Data.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) { }

        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Actor> ContentActor { get; set; }
        public DbSet<Director> ContentDirectors { get; set; }
        public DbSet<UserWatchHistory> UsersWatchHistories { get; set; }
        public DbSet<ContentDownload> UsersDownloads { get; set; }
        public DbSet<UserWatchList> UsersWatchLists { get; set; }
        public DbSet<WatchListContent> WatchListsContents { get; set; }

        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentActor> ContentsActors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ContentTag> ContentsTags { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<ContentAward> ContentAwards { get; set; }
        public DbSet<ContentGenre> ContentGenres { get; set; }
        public DbSet<ContentLanguage> ContentLanguages { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<SubscriptionPlanFeature> SubscriptionPlanFeatures { get; set; }
        public DbSet<SubscriptionPlanSubscriptionPlanFeature> SubscriptionPlansFeatures { get; set; }
        public DbSet<UserSubscriptionPlan> UsersSubscriptions { get; set; }
        public DbSet<TVShow> TVShows { get; set; }
        public DbSet<TVShowSeason> TVShowsSeasons { get; set; }
        public DbSet<TVShowEpisode> TVShowEpisodes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
