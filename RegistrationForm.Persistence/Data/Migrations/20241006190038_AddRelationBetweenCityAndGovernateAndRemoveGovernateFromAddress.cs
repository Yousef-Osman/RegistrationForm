using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationForm.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetweenCityAndGovernateAndRemoveGovernateFromAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Governates_GovernateId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_GovernateId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "GovernateId",
                table: "Addresses");

            migrationBuilder.AddColumn<long>(
                name: "GovernateId",
                table: "Cities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_GovernateId",
                table: "Cities",
                column: "GovernateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Governates_GovernateId",
                table: "Cities",
                column: "GovernateId",
                principalTable: "Governates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Governates_GovernateId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_GovernateId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "GovernateId",
                table: "Cities");

            migrationBuilder.AddColumn<long>(
                name: "GovernateId",
                table: "Addresses",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_GovernateId",
                table: "Addresses",
                column: "GovernateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Governates_GovernateId",
                table: "Addresses",
                column: "GovernateId",
                principalTable: "Governates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
