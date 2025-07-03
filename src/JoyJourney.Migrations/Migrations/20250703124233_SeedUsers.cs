﻿#nullable disable

namespace JoyJourney.Migrations.Migrations
{
    using Microsoft.AspNetCore.Identity;

    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create password hasher
            var hasher = new PasswordHasher<object>();

            // Pre-generate static values for migrations
            var aliceId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var aliceSecurityStamp = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa").ToString();
            var aliceConcurrencyStamp = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb").ToString();
            var alicePasswordHash = hasher.HashPassword(null, "Pass123$");
            var seedDateTime = new DateTime(2025, 6, 27, 18, 0, 0, DateTimeKind.Utc);

            // Create Alice user
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "user_name", "normalized_user_name", "email", "normalized_email",
                               "email_confirmed", "password_hash", "security_stamp", "concurrency_stamp",
                               "phone_number", "phone_number_confirmed", "two_factor_enabled",
                               "lockout_enabled", "access_failed_count", "first_name", "last_name",
                               "birth_year", "country", "created_at", "updated_at" },
                values: new object[] {
                    aliceId,
                    "alice",
                    "ALICE",
                    "AliceSmith@email.com",
                    "ALICESMITH@EMAIL.COM",
                    true,
                    alicePasswordHash,
                    aliceSecurityStamp,
                    aliceConcurrencyStamp,
                    "1234567890",
                    false,
                    false,
                    true,
                    0,
                    "Alice",
                    "Smith",
                    0, // Default birth year if not specified
                    "U.S.",
                    seedDateTime,
                    seedDateTime
                });

            // Pre-generate static values for Bob
            var bobId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var bobSecurityStamp = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc").ToString();
            var bobConcurrencyStamp = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd").ToString();
            var bobPasswordHash = hasher.HashPassword(null, "Pass123$");

            // Create Bob user
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "user_name", "normalized_user_name", "email", "normalized_email",
                               "email_confirmed", "password_hash", "security_stamp", "concurrency_stamp",
                               "phone_number", "phone_number_confirmed", "two_factor_enabled",
                               "lockout_enabled", "access_failed_count", "first_name", "last_name",
                               "birth_year", "country", "created_at", "updated_at" },
                values: new object[] {
                    bobId,
                    "bob",
                    "BOB",
                    "BobSmith@email.com",
                    "BOBSMITH@EMAIL.COM",
                    true,
                    bobPasswordHash,
                    bobSecurityStamp,
                    bobConcurrencyStamp,
                    "1234567890",
                    false,
                    false,
                    true,
                    0,
                    "Bob",
                    "Smith",
                    0, // Default birth year if not specified
                    "U.S.",
                    seedDateTime,
                    seedDateTime
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove seeded users
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: Guid.Parse("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: Guid.Parse("22222222-2222-2222-2222-222222222222"));
        }
    }
}
