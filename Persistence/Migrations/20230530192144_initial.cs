using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CteaedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CteaedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TabCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    TegaraCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Collage = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PaymentMethodA = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodB = table.Column<int>(type: "int", nullable: false),
                    Qanon = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CteaedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Qanon = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CteaedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Grades_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Grades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CteaedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_Bank_BankId",
                        column: x => x.BankId,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDepartment",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    StartFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CteaedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDepartment", x => new { x.EmployeeId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_EmployeeDepartment_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDepartment_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeGrade",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    StartFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CteaedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeGrade", x => new { x.EmployeeId, x.GradeId });
                    table.ForeignKey(
                        name: "FK_EmployeeGrade_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeGrade_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBankAccount",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BankId = table.Column<int>(type: "int", nullable: false),
                    EmployeeAccountNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    StartFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CteaedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBankAccount", x => new { x.EmployeeId, x.BankId });
                    table.ForeignKey(
                        name: "FK_EmployeeBankAccount_Branch_BankId",
                        column: x => x.BankId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeBankAccount_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bank",
                columns: new[] { "Id", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(660), null, null, "البنك الاهلى المصرى", null, null },
                    { 2, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(708), null, null, "البنك التجارى الدولى", null, null },
                    { 3, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(710), null, null, " بنك مصر", null, null },
                    { 4, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(712), null, null, " بنك قطر الوطنى الاهلى", null, null },
                    { 5, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(714), null, null, " بنك HSBC", null, null }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(863), null, null, "حسابات", null, null },
                    { 2, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(867), null, null, "البرنامج الدولى", null, null },
                    { 3, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(869), null, null, " مركز المؤتمرات", null, null },
                    { 4, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(871), null, null, " شئون العاملين", null, null },
                    { 5, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(873), null, null, "شئون عامه", null, null }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "ParentId", "Qanon", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(748), null, null, "موظف", null, 0, null, null },
                    { 16, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(816), null, null, "هيئة تدريس", null, 1, null, null },
                    { 2, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(752), null, null, "كبير", 1, 0, null, null },
                    { 3, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(754), null, null, "درجة اولى-أ", 1, 0, null, null },
                    { 4, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(756), null, null, "درجة اولى-ب", 1, 0, null, null },
                    { 5, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(789), null, null, "درجة الثانيه-أ", 1, 0, null, null },
                    { 6, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(792), null, null, "درجة الثانيه-ب", 1, 0, null, null },
                    { 7, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(795), null, null, "درجة الثالثه-أ", 1, 0, null, null },
                    { 8, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(797), null, null, "درجة الثالثه-ب", 1, 0, null, null },
                    { 9, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(799), null, null, "درجة الثالثه-ج", 1, 0, null, null },
                    { 10, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(802), null, null, "درجة الرابعه-أ", 1, 0, null, null },
                    { 11, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(804), null, null, "درجة الرابعه-ب", 1, 0, null, null },
                    { 12, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(807), null, null, "درجة الخامسه-أ", 1, 0, null, null },
                    { 13, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(809), null, null, "درجة الخامسه-ب", 1, 0, null, null },
                    { 14, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(811), null, null, "درجة السادسه-أ", 1, 0, null, null },
                    { 15, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(813), null, null, "درجة السادسه-ب", 1, 0, null, null },
                    { 17, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(818), null, null, "أستاذ متفرغ", 16, 1, null, null },
                    { 18, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(821), null, null, "أستاذ ", 16, 1, null, null },
                    { 19, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(823), null, null, "أستاذ مساعد", 16, 1, null, null },
                    { 20, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(825), null, null, "مدرس", 16, 1, null, null },
                    { 21, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(827), null, null, "مدرس مساعد", 16, 1, null, null },
                    { 22, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 5, 30, 22, 21, 43, 814, DateTimeKind.Local).AddTicks(829), null, null, "معيد", 16, 1, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_BankId",
                table: "Branch",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBankAccount_BankId",
                table: "EmployeeBankAccount",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartment_DepartmentId",
                table: "EmployeeDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeGrade_GradeId",
                table: "EmployeeGrade",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_ParentId",
                table: "Grades",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_AppUserId",
                table: "RefreshToken",
                column: "AppUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EmployeeBankAccount");

            migrationBuilder.DropTable(
                name: "EmployeeDepartment");

            migrationBuilder.DropTable(
                name: "EmployeeGrade");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Bank");
        }
    }
}
