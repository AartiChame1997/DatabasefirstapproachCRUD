// <auto-generated />
using System;
using DatabasefirstapproachCRUD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabasefirstapproachCRUD.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DatabasefirstapproachCRUD.Model.EmployeeRegistration", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Imagepath")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Occupitaion")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("employeeRegistrations");
                });

            modelBuilder.Entity("DatabasefirstapproachCRUD.Model.Files", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("DataFiles")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DocumentId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("DatabasefirstapproachCRUD.Model.tbl_employeeData", b =>
                {
                    b.Property<int>("Employeeid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CAddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CAddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPpincode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ccity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Child1Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Child2Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CpState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateofBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Division")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Emailid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeNo")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSameAddress")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaritalStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PAddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PAddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pcity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pincode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pstate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpouseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("joiningDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Employeeid");

                    b.ToTable("tbl_employeeData");
                });
#pragma warning restore 612, 618
        }
    }
}
