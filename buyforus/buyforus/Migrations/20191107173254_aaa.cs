using Microsoft.EntityFrameworkCore.Migrations;

namespace buyforus.Migrations
{
    public partial class aaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d6d0274-7907-4c32-97dc-8940b2dfef46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0db6760-a29c-40b3-9ab8-0f556a474398");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3dbf839-2bf6-417f-a4ad-aca4b678f5f3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6cd510e6-87dc-4218-9f97-eaca103499ba", "a7c739bd-1f37-439d-815e-9624f3f75768", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2976f48-a7e5-4502-939d-aff8564bea57", "d8fe205b-f695-4c8a-929c-61ec6aa3d60a", "Donator", "DONATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83b6f22c-3cae-4208-ae92-0bc4b35caafd", "f735b3dd-8ed2-42d3-9efd-6b34ad7c88f8", "Organization", "ORGANIZATION" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cd510e6-87dc-4218-9f97-eaca103499ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83b6f22c-3cae-4208-ae92-0bc4b35caafd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2976f48-a7e5-4502-939d-aff8564bea57");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3dbf839-2bf6-417f-a4ad-aca4b678f5f3", "4e207105-ee68-42de-aae4-d98ba135c092", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d6d0274-7907-4c32-97dc-8940b2dfef46", "bd7edf3f-4319-4a93-b85d-846adab3f91b", "Donator", "DONATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0db6760-a29c-40b3-9ab8-0f556a474398", "c66a501f-3140-46be-a5eb-1f5e7719b1cc", "Organization", "ORGANIZATION" });
        }
    }
}
