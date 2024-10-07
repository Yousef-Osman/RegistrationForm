using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistrationForm.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGovernateResidentTriggerOnAddressTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE TRIGGER trg_ModifyGovernateResidentCount
                ON Addresses
                AFTER INSERT
                AS
                BEGIN
	                UPDATE G
                    SET G.Count = G.Count + 1
                    FROM GovernateResidents G
                    INNER JOIN Cities C ON G.GovernateId = C.GovernateId
                    INNER JOIN inserted I ON C.Id = I.CityId;

                    INSERT INTO GovernateResidents (GovernateId, Count)
                    SELECT C.GovernateId, 1
                    FROM inserted I
                    INNER JOIN Cities C ON I.CityId = C.Id
                    WHERE NOT EXISTS (
                        SELECT 1
                        FROM GovernateResidents G
                        INNER JOIN Cities C ON G.GovernateId = C.GovernateId
		                INNER JOIN inserted I ON C.Id = I.CityId
                    );
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_ModifyGovernateResidentCount ON Addresses;");
        }
    }
}
