using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountsTree",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AccountParentId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_AccountsTree", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountsTree_AccountsTree_AccountParentId",
                        column: x => x.AccountParentId,
                        principalTable: "AccountsTree",
                        principalColumn: "Id");
                });

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
                name: "Collection",
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
                    table.PrimaryKey("PK_Collection", x => x.Id);
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
                name: "AccountTreeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AccountTreeId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_AccountTreeDetails", x => new { x.Id, x.AccountTreeId });
                    table.ForeignKey(
                        name: "FK_AccountTreeDetails_AccountsTree_AccountTreeId",
                        column: x => x.AccountTreeId,
                        principalTable: "AccountsTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "EmployeeCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CteaedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCollection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeCollection_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCollection_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
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
                name: "EmployeePartTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CteaedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeePartTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeePartTime_Employee_EmployeeId",
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
                name: "EmployeeBasicFinancialData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AccountTreeDetailsId = table.Column<int>(type: "int", nullable: false),
                    AccountTreeDetailsAccountTreeId = table.Column<int>(type: "int", nullable: false),
                    FinancialSource = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CteaedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBasicFinancialData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeBasicFinancialData_AccountTreeDetails_AccountTreeDetailsId_AccountTreeDetailsAccountTreeId",
                        columns: x => new { x.AccountTreeDetailsId, x.AccountTreeDetailsAccountTreeId },
                        principalTable: "AccountTreeDetails",
                        principalColumns: new[] { "Id", "AccountTreeId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeBasicFinancialData_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBankAccount",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    BankAId = table.Column<int>(type: "int", nullable: true),
                    AccountANumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BankBId = table.Column<int>(type: "int", nullable: true),
                    AccountBNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CteaedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteddAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBankAccount", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_EmployeeBankAccount_Branch_BankAId",
                        column: x => x.BankAId,
                        principalTable: "Branch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeBankAccount_Branch_BankBId",
                        column: x => x.BankBId,
                        principalTable: "Branch",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeBankAccount_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountsTree",
                columns: new[] { "Id", "AccountParentId", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 21110000, null, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4038), null, null, "اجور و البدلات النقديه و العينيه", null, null },
                    { 21120000, null, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4071), null, null, "المزايا التأمينيه", null, null }
                });

            migrationBuilder.InsertData(
                table: "Bank",
                columns: new[] { "Id", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3735), null, null, "البنك العربى الأفريقى", null, null },
                    { 2, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3777), null, null, "البنك الاهلى المصرى", null, null },
                    { 3, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3779), null, null, "بنك القاهرة", null, null },
                    { 4, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3781), null, null, " بنك مصر", null, null },
                    { 5, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3783), null, null, " بنك قطر الوطنى الاهلى", null, null },
                    { 6, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3786), null, null, " بنك HSBC", null, null }
                });

            migrationBuilder.InsertData(
                table: "Collection",
                columns: new[] { "Id", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4211), null, null, "'طب -مؤقتين'", null, null },
                    { 2, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4215), null, null, "طب -دائمين", null, null },
                    { 3, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4217), null, null, " طب -مدرس", null, null },
                    { 4, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4219), null, null, " طب -أستاذ مساعد", null, null },
                    { 5, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4221), null, null, "طب-أستاذ", null, null }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4003), null, null, "حسابات", null, null },
                    { 2, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4007), null, null, "البرنامج الدولى", null, null },
                    { 3, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4008), null, null, " مركز المؤتمرات", null, null },
                    { 4, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4010), null, null, " شئون العاملين", null, null },
                    { 5, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4012), null, null, "شئون عامه", null, null }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "ParentId", "Qanon", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3881), null, null, "موظف", null, 0, null, null },
                    { 16, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3942), null, null, "هيئة تدريس", null, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "AccountsTree",
                columns: new[] { "Id", "AccountParentId", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 21110100, 21110000, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4042), null, null, "الوظائف الدائمه", null, null },
                    { 21110200, 21110000, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4049), null, null, "الوظائف المؤقته", null, null },
                    { 21110300, 21110000, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4051), null, null, "المكافات", null, null },
                    { 21110400, 21110000, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4061), null, null, "بدلات نوعيه", null, null },
                    { 21110500, 21110000, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4063), null, null, "مزايا نقديه", null, null },
                    { 21110600, 21110000, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4069), null, null, "مزايا عينيه", null, null },
                    { 21120100, 21120000, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4073), null, null, "حصة الحكومه فى صتدوق التأمين الاجتماعى", null, null },
                    { 21120200, 21120000, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4100), null, null, "مزايا تأمينيه اخرى", null, null }
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "BankId", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3843), null, null, "مركز البطاقات", null, null },
                    { 2, 2, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3846), null, null, "مركز البطاقات", null, null },
                    { 3, 2, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3849), null, null, " باكوس", null, null },
                    { 4, 2, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3850), null, null, " بولكلى", null, null },
                    { 5, 2, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3853), null, null, "سيدى جابر", null, null }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "ParentId", "Qanon", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 2, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3886), null, null, "كبير", 1, 0, null, null },
                    { 3, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3888), null, null, "درجة اولى-أ", 1, 0, null, null },
                    { 4, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3890), null, null, "درجة اولى-ب", 1, 0, null, null },
                    { 5, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3892), null, null, "درجة الثانيه-أ", 1, 0, null, null },
                    { 6, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3918), null, null, "درجة الثانيه-ب", 1, 0, null, null },
                    { 7, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3920), null, null, "درجة الثالثه-أ", 1, 0, null, null },
                    { 8, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3922), null, null, "درجة الثالثه-ب", 1, 0, null, null },
                    { 9, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3925), null, null, "درجة الثالثه-ج", 1, 0, null, null },
                    { 10, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3928), null, null, "درجة الرابعه-أ", 1, 0, null, null },
                    { 11, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3930), null, null, "درجة الرابعه-ب", 1, 0, null, null },
                    { 12, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3933), null, null, "درجة الخامسه-أ", 1, 0, null, null },
                    { 13, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3935), null, null, "درجة الخامسه-ب", 1, 0, null, null },
                    { 14, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3937), null, null, "درجة السادسه-أ", 1, 0, null, null },
                    { 15, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3939), null, null, "درجة السادسه-ب", 1, 0, null, null },
                    { 17, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3944), null, null, "أستاذ متفرغ", 16, 1, null, null },
                    { 18, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3947), null, null, "أستاذ ", 16, 1, null, null },
                    { 19, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3949), null, null, "أستاذ مساعد", 16, 1, null, null },
                    { 20, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3951), null, null, "مدرس", 16, 1, null, null },
                    { 21, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3953), null, null, "مدرس مساعد", 16, 1, null, null },
                    { 22, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(3956), null, null, "معيد", 16, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "AccountsTree",
                columns: new[] { "Id", "AccountParentId", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 21110101, 21110100, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4044), null, null, "الاجر الاساسى", null, null },
                    { 21110105, 21110100, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4046), null, null, "الاجر الوظيفى", null, null },
                    { 21110321, 21110300, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4053), null, null, "حوافز اخرى", null, null },
                    { 21110326, 21110300, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4056), null, null, "حافز تعويضى", null, null },
                    { 21110328, 21110300, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4058), null, null, "حافز اضافى", null, null },
                    { 21110511, 21110500, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4065), null, null, "علاوة غلاء معيشه", null, null },
                    { 21110512, 21110500, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4067), null, null, "علاوة الحد الادنى للحزمه الاجتماعيه", null, null },
                    { 21120101, 21120100, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4075), null, null, "حكومه 12 شيخوخة و عجز", null, null },
                    { 21120102, 21120100, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4078), null, null, "حكومه 1  نظام المكافاة", null, null },
                    { 21120201, 21120200, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4102), null, null, "حكومه 3 تأمين صحى ضد المرض", null, null },
                    { 21120202, 21120200, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4104), null, null, "حكومه 1.25  إصابة عمل", null, null }
                });

            migrationBuilder.InsertData(
                table: "AccountTreeDetails",
                columns: new[] { "AccountTreeId", "Id", "CreatedBy", "CteaedAt", "DeletedBy", "DeleteddAt", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 21110105, 1002, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4127), null, null, "الاجر الاساسى", null, null },
                    { 21110105, 1003, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4132), null, null, "100% من الاجر الاساسى", null, null },
                    { 21110105, 1004, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4134), null, null, "الحد الادنى", null, null },
                    { 21110105, 1005, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4136), null, null, "علاوات خاصه غير مضمومه ", null, null },
                    { 21110105, 1006, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4138), null, null, "بدل علاوة اجتماعيه و اضافيه و منحه ", null, null },
                    { 21110105, 1007, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4141), null, null, "علاوة دوريه 2015", null, null },
                    { 21110105, 1008, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4142), null, null, "علاوة دوريه 2016", null, null },
                    { 21110105, 1009, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4145), null, null, "علاوة دوريه 2017", null, null },
                    { 21110105, 1010, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4147), null, null, "علاوة دوريه 2017 اسثنائيه", null, null },
                    { 21110105, 1011, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4149), null, null, "علاوة دوريه 2018", null, null },
                    { 21110105, 1012, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4151), null, null, "علاوة دوريه 2018 اسثنائيه", null, null },
                    { 21110105, 1013, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4153), null, null, "علاوة دوريه 2019", null, null },
                    { 21110105, 1014, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4155), null, null, "علاوة دوريه 2020", null, null },
                    { 21110105, 1015, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4157), null, null, "علاوة دوريه 2021", null, null },
                    { 21110105, 1016, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4159), null, null, "علاوة دوريه 2022", null, null },
                    { 21110105, 1017, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4160), null, null, "علاوة دوريه 2023", null, null },
                    { 21110321, 2001, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4163), null, null, "50 % من الاساسى", null, null },
                    { 21110321, 2002, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4165), null, null, "200 ج بدل جودة", null, null },
                    { 21110321, 2003, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4169), null, null, "مكمل مستعبد", null, null },
                    { 21110321, 2004, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4167), null, null, "بدل الحد الادنى ", null, null },
                    { 21110328, 2006, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4171), null, null, "حافز 2019", null, null },
                    { 21110328, 2007, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4172), null, null, "حافز 2020", null, null },
                    { 21110328, 2008, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4174), null, null, "حافز 2021", null, null },
                    { 21110328, 2009, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4176), null, null, "حافز 2022", null, null },
                    { 21110328, 2010, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4178), null, null, "حافز 2023", null, null },
                    { 21110511, 2011, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4180), null, null, " علاوة غلاء معيشه", null, null },
                    { 21110512, 2012, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4182), null, null, "علاوة الحد الادنى للحزمه الاجتماعيه", null, null },
                    { 21110326, 4001, "12990fe8-1ad9-4e30-a80e-5e664a831480", new DateTime(2023, 7, 8, 1, 35, 30, 253, DateTimeKind.Local).AddTicks(4184), null, null, "حافز تعويضى 2015", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountsTree_AccountParentId",
                table: "AccountsTree",
                column: "AccountParentId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTreeDetails_AccountTreeId_Id",
                table: "AccountTreeDetails",
                columns: new[] { "AccountTreeId", "Id" },
                unique: true);

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
                name: "IX_EmployeeBankAccount_BankAId",
                table: "EmployeeBankAccount",
                column: "BankAId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBankAccount_BankBId",
                table: "EmployeeBankAccount",
                column: "BankBId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBasicFinancialData_AccountTreeDetailsId_AccountTreeDetailsAccountTreeId",
                table: "EmployeeBasicFinancialData",
                columns: new[] { "AccountTreeDetailsId", "AccountTreeDetailsAccountTreeId" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBasicFinancialData_EmployeeId_AccountTreeDetailsAccountTreeId_AccountTreeDetailsId",
                table: "EmployeeBasicFinancialData",
                columns: new[] { "EmployeeId", "AccountTreeDetailsAccountTreeId", "AccountTreeDetailsId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCollection_CollectionId_EmployeeId",
                table: "EmployeeCollection",
                columns: new[] { "CollectionId", "EmployeeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCollection_EmployeeId",
                table: "EmployeeCollection",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDepartment_DepartmentId",
                table: "EmployeeDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeGrade_GradeId",
                table: "EmployeeGrade",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeePartTime_EmployeeId",
                table: "EmployeePartTime",
                column: "EmployeeId");

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
                name: "EmployeeBasicFinancialData");

            migrationBuilder.DropTable(
                name: "EmployeeCollection");

            migrationBuilder.DropTable(
                name: "EmployeeDepartment");

            migrationBuilder.DropTable(
                name: "EmployeeGrade");

            migrationBuilder.DropTable(
                name: "EmployeePartTime");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "AccountTreeDetails");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "AccountsTree");
        }
    }
}
