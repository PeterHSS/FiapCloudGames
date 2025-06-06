﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIAPCloudGames.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Promotions_PromotionId",
                table: "Games");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Promotions",
                table: "Games",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Promotions",
                table: "Games");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Promotions_PromotionId",
                table: "Games",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
