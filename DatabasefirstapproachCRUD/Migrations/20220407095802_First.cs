using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabasefirstapproachCRUD.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employeeRegistrations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Occupitaion = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Imagepath = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeRegistrations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DataFiles = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_employeeData",
                columns: table => new
                {
                    Employeeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNo = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emailid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Child1Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Child2Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pcity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pstate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSameAddress = table.Column<bool>(type: "bit", nullable: false),
                    CAddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CAddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ccity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPpincode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    joiningDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    EmergencyNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_employeeData", x => x.Employeeid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeeRegistrations");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "tbl_employeeData");
        }
    }
}
