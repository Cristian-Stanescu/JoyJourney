using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JoyJourney.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "application_user_id",
                table: "journal_entries",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_journal_entries_application_user_id",
                table: "journal_entries",
                column: "application_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_journal_entries_users_application_user_id",
                table: "journal_entries",
                column: "application_user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_journal_entries_users_application_user_id",
                table: "journal_entries");

            migrationBuilder.DropIndex(
                name: "ix_journal_entries_application_user_id",
                table: "journal_entries");

            migrationBuilder.DropColumn(
                name: "application_user_id",
                table: "journal_entries");
        }
    }
}
