using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HillaryHairCare.Migrations
{
    /// <inheritdoc />
    public partial class AddIdToAppointmentServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 1, 1 },
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 1, 3 },
                column: "Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 2, 2 },
                column: "Id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 3, 1 },
                column: "Id",
                value: 4);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 4, 4 },
                column: "Id",
                value: 5);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 5, 1 },
                column: "Id",
                value: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 1, 1 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 1, 3 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 2, 2 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 3, 1 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 4, 4 },
                column: "Id",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AppointmentServices",
                keyColumns: new[] { "AppointmentId", "ServiceId" },
                keyValues: new object[] { 5, 1 },
                column: "Id",
                value: 0);
        }
    }
}
