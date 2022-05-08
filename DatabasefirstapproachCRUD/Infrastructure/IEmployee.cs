using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabasefirstapproachCRUD.Model;
using DatabasefirstapproachCRUD.ViewModel;
using Microsoft.AspNetCore.Http;

namespace DatabasefirstapproachCRUD.Infrastructure
{
    public interface IEmployee
    {
        Task<IEnumerable<tbl_employeeData>> GetEmployeeDetails();
        int AddEmpdata(EmployeeViewModel model, IFormFile files);
        int DeleteEmployee(int id);
        int UpdateEmployee(tbl_employeeData tbl_employeeData,int id);
        Task<IEnumerable<tbl_employeeData>> GetEmployee(int id);

        int SignupEmp(EmployeeRegistration employeeRegistration);

        int savefile(IFormFile files);
        //public bool UploadProfilePhotoUrl(int employeeId, string url);

        //int saveProfile(tbl_employeeData  model  , IFormFile[] photos);



    }
}
