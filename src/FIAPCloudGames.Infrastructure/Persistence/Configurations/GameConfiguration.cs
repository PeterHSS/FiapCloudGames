﻿using FIAPCloudGames.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAPCloudGames.Infrastructure.Persistence.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {

        builder.ToTable("Games");

        builder.HasKey(game => game.Id).HasName("PK_Games");

        builder.Property(game => game.Id).IsRequired();

        builder.Property(game => game.CreatedAt).IsRequired();

        builder.Property(game => game.Name).IsRequired().HasMaxLength(500);

        builder.Property(game => game.Description).HasMaxLength(1000);

        builder.Property(game => game.ReleasedAt).IsRequired();

        builder.Property(game => game.Price).IsRequired().HasColumnType("decimal(10,2)");

        builder.Property(game => game.IsActive).IsRequired();

        builder.Property(game => game.Genre).IsRequired().HasMaxLength(50);

        builder.Property(game => game.UpdatedAt);

        builder.HasIndex(game => game.IsActive).HasDatabaseName("IX_Games_IsActive");

        builder.HasIndex(game => game.Genre).HasDatabaseName("IX_Games_Genre");

        builder.HasQueryFilter(game => game.IsActive);

        builder.HasOne(game => game.Promotion).WithMany(promotion => promotion.Games).HasForeignKey(game => game.PromotionId).OnDelete(DeleteBehavior.SetNull).HasConstraintName("FK_Games_Promotions");

        builder.Navigation(game => game.Promotion).AutoInclude();
    }
}
