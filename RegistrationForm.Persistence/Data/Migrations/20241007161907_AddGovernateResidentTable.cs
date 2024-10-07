using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationForm.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGovernateResidentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GovernateResidents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovernateId = table.Column<long>(type: "bigint", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernateResidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GovernateResidents_Governates_GovernateId",
                        column: x => x.GovernateId,
                        principalTable: "Governates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GovernateResidents_GovernateId",
                table: "GovernateResidents",
                column: "GovernateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GovernateResidents");
        }
    }
}
