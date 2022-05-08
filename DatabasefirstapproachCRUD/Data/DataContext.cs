using DatabasefirstapproachCRUD.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabasefirstapproachCRUD.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
       public DbSet<tbl_employeeData> tbl_employeeData { get; set; }
       public DbSet<Files> Files { get; set; }

        public DbSet<EmployeeRegistration> employeeRegistrations { get; set; }
    }
}
