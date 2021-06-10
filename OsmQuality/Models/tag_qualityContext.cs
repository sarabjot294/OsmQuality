using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OsmQuality.Models
{
    public partial class tag_qualityContext : DbContext
    {
        public tag_qualityContext()
        {
        }

        public tag_qualityContext(DbContextOptions<tag_qualityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<TagCombination> TagCombinations { get; set; }
        public virtual DbSet<TagCombinationDetail> TagCombinationDetails { get; set; }
        public virtual DbSet<TagsKeyValue> TagsKeyValues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=tag_quality;Username=postgres;Password=osm");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Db).HasColumnName("db");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<TagCombination>(entity =>
            {
                entity.ToTable("tag_combinations");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AverageCorrosTags).HasColumnName("average_corros_tags");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.TagCount).HasColumnName("tag_count");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.Property(e => e.TopTags).HasColumnName("top_tags");
            });

            modelBuilder.Entity<TagCombinationDetail>(entity =>
            {
                entity.ToTable("tag_combination_details");

                entity.HasIndex(e => e.TcId, "fki_Reference to Tag Combination table");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Percent).HasColumnName("percent");

                entity.Property(e => e.TagKey).HasColumnName("tag_key");

                entity.Property(e => e.TcId).HasColumnName("tc_id");
            });

            modelBuilder.Entity<TagsKeyValue>(entity =>
            {
                entity.ToTable("tags_key_value");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.IdealTags).HasColumnName("ideal_tags");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
