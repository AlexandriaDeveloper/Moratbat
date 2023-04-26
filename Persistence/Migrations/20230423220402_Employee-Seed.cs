using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bank",
                columns: new[] { "Id", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9381), null, null, "البنك الاهلى المصرى", null, null },
                    { 2, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9428), null, null, "البنك التجارى الدولى", null, null },
                    { 3, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9430), null, null, " بنك مصر", null, null },
                    { 4, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9433), null, null, " بنك قطر الوطنى الاهلى", null, null },
                    { 5, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9434), null, null, " بنك HSBC", null, null }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9632), null, null, "حسابات", null, null },
                    { 2, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9636), null, null, "البرنامج الدولى", null, null },
                    { 3, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9638), null, null, " مركز المؤتمرات", null, null },
                    { 4, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9640), null, null, " شئون العاملين", null, null },
                    { 5, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9642), null, null, "شئون عامه", null, null }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "ParentId", "Qanon", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9476), null, null, "موظف", null, 0, null, null },
                    { 22, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9583), null, null, "هيئة تدريس", null, 1, null, null },
                    { 2, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9480), null, null, "كبير", 1, 0, null, null },
                    { 3, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9482), null, null, "درجة اولى", 1, 0, null, null },
                    { 6, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9490), null, null, "درجة الثانيه", 1, 0, null, null },
                    { 9, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9497), null, null, "درجة الثالثه", 1, 0, null, null },
                    { 13, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9507), null, null, "درجة الرابعه", 1, 0, null, null },
                    { 16, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9514), null, null, "درجة الخامسه", 1, 0, null, null },
                    { 19, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9522), null, null, "درجة السادسه", 1, 0, null, null },
                    { 23, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9585), null, null, "أستاذ متفرغ", 22, 1, null, null },
                    { 24, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9588), null, null, "أستاذ ", 22, 1, null, null },
                    { 25, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9590), null, null, "أستاذ مساعد", 22, 1, null, null },
                    { 26, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9593), null, null, "مدرس", 22, 1, null, null },
                    { 27, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9595), null, null, "مدرس مساعد", 22, 1, null, null },
                    { 28, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9597), null, null, "معيد", 22, 1, null, null },
                    { 4, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9485), null, null, "أ", 3, 0, null, null },
                    { 5, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9487), null, null, "ب ", 3, 0, null, null },
                    { 7, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9492), null, null, "أ", 6, 0, null, null },
                    { 8, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9495), null, null, "ب ", 6, 0, null, null },
                    { 10, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9500), null, null, "أ", 9, 0, null, null },
                    { 11, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9503), null, null, "ب ", 9, 0, null, null },
                    { 12, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9505), null, null, "ج ", 9, 0, null, null },
                    { 14, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9509), null, null, "أ", 13, 0, null, null },
                    { 15, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9512), null, null, "ب ", 13, 0, null, null },
                    { 17, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9516), null, null, "أ", 16, 0, null, null },
                    { 18, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9519), null, null, "ب ", 16, 0, null, null },
                    { 20, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9524), null, null, "أ", 18, 0, null, null },
                    { 21, "ea158a09-f87b-4736-9e50-f0516c8ece15", new DateTime(2023, 4, 24, 0, 4, 2, 439, DateTimeKind.Local).AddTicks(9580), null, null, "ب ", 18, 0, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
