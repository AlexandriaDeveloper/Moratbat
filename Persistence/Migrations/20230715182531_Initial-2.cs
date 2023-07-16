using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Repeat",
                table: "EmployeeBasicFinancialData",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1002 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7123));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1003 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1004 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7130));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1005 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7132));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1006 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7134));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1007 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7137));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1008 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7139));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1009 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7141));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1010 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1011 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7146));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1012 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7147));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1013 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7149));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1014 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7151));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1015 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1016 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1017 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7157));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110321, 2001 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7159));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110321, 2002 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7161));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110321, 2003 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7165));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110321, 2004 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7163));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110328, 2006 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7167));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110328, 2007 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7169));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110328, 2008 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110328, 2009 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110328, 2010 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110511, 2011 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7177));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110512, 2012 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7179));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110326, 4001 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110000,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110100,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110101,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7036));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110105,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110200,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110300,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110321,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110326,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110328,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110400,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110500,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7053));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110511,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7056));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110512,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7058));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110600,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21120000,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7062));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21120100,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7064));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21120101,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7066));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21120102,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7069));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21120200,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7071));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21120201,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21120202,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7075));

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 1,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6667));

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 2,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6712));

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 3,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6714));

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 4,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6716));

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 5,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6718));

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 6,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6721));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6819));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 2,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6823));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 3,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6826));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 4,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6828));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 5,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "Collection",
                keyColumn: "Id",
                keyValue: 1,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7211));

            migrationBuilder.UpdateData(
                table: "Collection",
                keyColumn: "Id",
                keyValue: 2,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "Collection",
                keyColumn: "Id",
                keyValue: 3,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "Collection",
                keyColumn: "Id",
                keyValue: 4,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "Collection",
                keyColumn: "Id",
                keyValue: 5,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7220));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6999));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6860));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6864));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6867));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6869));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6872));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6875));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 7,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6877));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 8,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6879));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 9,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 10,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6907));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 11,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 12,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6912));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 13,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6914));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 14,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6916));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 15,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6918));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 16,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6921));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 17,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6923));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 18,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6926));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 19,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6928));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 20,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 21,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6933));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 22,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 15, 21, 25, 31, 199, DateTimeKind.Local).AddTicks(6935));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Repeat",
                table: "EmployeeBasicFinancialData");

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1002 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4127));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1003 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4132));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1004 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4134));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1005 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4136));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1006 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4138));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1007 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4141));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1008 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4142));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1009 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4145));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1010 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4147));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1011 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4149));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1012 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4151));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1013 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4153));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1014 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4155));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1015 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1016 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4159));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110105, 1017 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4160));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110321, 2001 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4163));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110321, 2002 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4165));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110321, 2003 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4169));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110321, 2004 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4167));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110328, 2006 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4171));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110328, 2007 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4172));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110328, 2008 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4174));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110328, 2009 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110328, 2010 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4178));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110511, 2011 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110512, 2012 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "AccountTreeDetails",
                keyColumns: new[] { "AccountTreeId", "Id" },
                keyValues: new object[] { 21110326, 4001 },
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110000,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4038));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110100,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4042));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110101,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4044));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110105,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4046));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110200,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110300,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4051));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110321,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110326,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4056));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110328,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4058));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110400,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4061));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110500,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4063));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110511,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4065));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110512,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4067));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21110600,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4069));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21120000,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21120100,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4073));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21120101,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4075));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21120102,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4078));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21120200,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21120201,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.UpdateData(
                table: "AccountsTree",
                keyColumn: "Id",
                keyValue: 21120202,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 1,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3735));

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 2,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3777));

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 3,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 4,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3781));

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 5,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3783));

            migrationBuilder.UpdateData(
                table: "Bank",
                keyColumn: "Id",
                keyValue: 6,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3786));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3843));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 2,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3846));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 3,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3849));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 4,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 5,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "Collection",
                keyColumn: "Id",
                keyValue: 1,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "Collection",
                keyColumn: "Id",
                keyValue: 2,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4215));

            migrationBuilder.UpdateData(
                table: "Collection",
                keyColumn: "Id",
                keyValue: 3,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "Collection",
                keyColumn: "Id",
                keyValue: 4,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "Collection",
                keyColumn: "Id",
                keyValue: 5,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4221));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4003));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4007));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4010));

            migrationBuilder.UpdateData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 5,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3881));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3886));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3888));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3890));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3892));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3918));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 7,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 8,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3922));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 9,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3925));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 10,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3928));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 11,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3930));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 12,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3933));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 13,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3935));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 14,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3937));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 15,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3939));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 16,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3942));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 17,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 18,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3947));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 19,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3949));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 20,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3951));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 21,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3953));

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 22,
                column: "CteaedAt",
                value: new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3956));
        }
    }
}
