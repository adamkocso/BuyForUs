using Microsoft.EntityFrameworkCore.Migrations;

namespace buyforus.Migrations
{
    public partial class add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "844ea899-5b6d-4e25-b509-9164a0ba4db4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a34bed61-e656-49e8-965f-a75ef045bd5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffe837c5-8a25-474a-bc6c-66bf70c04c20");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d9ca966-47a2-40f1-8de1-536673e303fc", "0a1defab-9e4c-4b47-875d-486c9fa55867", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "196d0779-21df-491f-87e3-54472d41bf9a", "cec50947-0f96-4796-95d2-daa46bf861fa", "Donator", "DONATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f47df732-92fc-4a5d-9a26-54e142e8f532", "f0a873f1-a505-4945-a5ca-796fc491ba77", "Organization", "ORGANIZATION" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "196d0779-21df-491f-87e3-54472d41bf9a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d9ca966-47a2-40f1-8de1-536673e303fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f47df732-92fc-4a5d-9a26-54e142e8f532");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "844ea899-5b6d-4e25-b509-9164a0ba4db4", "4a010300-7e66-462c-ab7a-7505071f32ea", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a34bed61-e656-49e8-965f-a75ef045bd5f", "a1ee07fa-7879-4d1a-b005-2ee6cce64598", "Donator", "DONATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ffe837c5-8a25-474a-bc6c-66bf70c04c20", "c2b1535b-2522-4d64-a189-783bf5a4d531", "Organization", "ORGANIZATION" });
        }
    }
}
