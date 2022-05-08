using DatabasefirstapproachCRUD.Data;
using DatabasefirstapproachCRUD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabasefirstapproachCRUD.Model;
using Microsoft.AspNetCore.Http;
using System.IO;
using DatabasefirstapproachCRUD.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DatabasefirstapproachCRUD
{
    public class EmployeeRepository : IEmployee
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHostingEnvironment hostingEnvironment;
        public EmployeeRepository(DataContext context,IWebHostEnvironment hostEnvironment,IHostingEnvironment _hostingEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
            hostingEnvironment = _hostingEnvironment;
        }

        public int AddEmpdata(EmployeeViewModel empdata, IFormFile files)
        {
            int res = 0;
           if(_context!=null)
            {

                tbl_employeeData data = new tbl_employeeData
                {
                    EmployeeNo=empdata.EmployeeNo,
                    EmployeeName=empdata.EmployeeName,

                        MobileNo =empdata.MobileNo,
                           Emailid=empdata.Emailid,

      FirstName =empdata.FirstName,
    LastName=empdata.LastName,
         Gender=empdata.Gender,
         DateofBirth=empdata.DateofBirth,
        MaritalStatus =empdata.MaritalStatus,
        SpouseName =empdata.SpouseName,
       Child1Name=empdata.Child1Name,
      Child2Name =empdata.Child2Name,
        PAddressLine1=empdata.PAddressLine1,
         PAddressLine2=empdata.PAddressLine2,
      Pcity=empdata.Pcity,
         Pstate=empdata.Pstate,
     Pincode=empdata.Pincode,
         IsSameAddress=empdata.IsSameAddress,
        CAddressLine1=empdata.CAddressLine1,
        CAddressLine2=empdata.CAddressLine2,
       Ccity=empdata.Ccity,
         CpState=empdata.CpState,
  CPpincode=empdata.CPpincode,
   joiningDate=empdata.joiningDate,
    Division=empdata.Division,
    Department=empdata.Department,
   ProfilePhotoPath=empdata.ProfilePhotoPath,
   EmergencyNo=empdata.EmergencyNo 
    };
                if (!_context.tbl_employeeData.Any(x => x.FirstName == data.FirstName)) //Repeated entry code
                {
                  

                    _context.tbl_employeeData.Add(data);
                    res=_context.SaveChanges();
                    return res;
                }
                
            }
            return 0;
        }

        //Method for upload file
        //public string uploadfile(EmployeeViewModel model)
        //{
        //    string uniqueFileName = null;

        //    if (model.ProfileImage != null)
        //    {
        //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.ProfileImage.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;

        //}

       

        public int DeleteEmployee(int id)
        {
            int res;
            if (_context != null)
            {
                var result = _context.tbl_employeeData.Where(x => x.Employeeid == id).FirstOrDefault();
                if (result != null)
                {
                    _context.tbl_employeeData.Remove(result);
                    res = _context.SaveChanges();
                    return res;
                }
                return 0;
            }
            return 0;

        }

        public async Task<IEnumerable<tbl_employeeData>> GetEmployee(int id)
        {
            if(_context!=null)
            {
                var result = _context.tbl_employeeData.Where(x => x.Employeeid == id);
                return result;
            }
            return null;
            
        }

        public async Task<IEnumerable<tbl_employeeData>> GetEmployeeDetails()
        {
            var result =_context.tbl_employeeData.ToList();
            return result;
        }

        public int savefile(IFormFile files)
        {
            int res = 0;
            if (files != null)
            {
                if (files.Length > 0)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(files.FileName);
                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);
                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                    var objfiles = new tbl_employeeData()
                    {
                        
                        ProfilePhotoPath = newFileName

                    };

                    using (var target = new MemoryStream())
                    {
                        files.CopyTo(target);
                        objfiles.ProfilePhotoPath = target.ToString();
                    }

                    _context.tbl_employeeData.Add(objfiles);
                   res= _context.SaveChanges();

                }
            }
            return res;
        }
        //sign up Employee
        public int SignupEmp(EmployeeRegistration employeeRegistration)
        {
            int res = 0;
            employeeRegistration.Imagepath = SaveImage(employeeRegistration.ImageFile);
            _context.employeeRegistrations.Add(employeeRegistration);
            res = _context.SaveChanges();
            return res;
        }
        [NonAction]
        public string SaveImage(IFormFile file)
        {
            // string fName = file.FileName;
            //string path = Path.Combine(hostingEnvironment.ContentRootPath, "Images/" + file.FileName);
            //using (var stream = new FileStream(path, FileMode.Create))
            //{
            //    file.CopyTo(stream);
            //}
            //return file.FileName;

            string Imagename = new string(Path.GetFileNameWithoutExtension(file.FileName).Take(10).ToArray()).Replace(' ', '_');
            Imagename = Imagename + DateTime.Now.ToString("yymmsfff") + Path.GetExtension(file.FileName);
            var imgpath = Path.Combine(hostingEnvironment.ContentRootPath, "Images", Imagename);
            using(var filesream=new FileStream(imgpath,FileMode.Create))
            {
                file.CopyTo(filesream);
            }
            return Imagename;

        }

        public int UpdateEmployee(tbl_employeeData tbl_employeeData ,int id)
        {
            int res;
            if (_context != null)
            {
                var result = _context.tbl_employeeData.Where(x => x.Employeeid ==id).FirstOrDefault();
                if (result != null)
                {
                    result.EmployeeNo= tbl_employeeData.EmployeeNo;
                    result.EmployeeName = tbl_employeeData.EmployeeName;
                    result.FirstName = tbl_employeeData.FirstName;
                    result.Department = tbl_employeeData.Department;
                  

                    res = _context.SaveChanges();
                    return res;
                }
                return 0;
            }
            return 0;
        }

        //public int saveProfile(tbl_employeeData model, IFormFile[] photos)
        //{
        //    if (photos == null || photos.Length == 0)
        //    {
        //        return Content("File(s) not selected");
        //    }
        //    else
        //    {
        //        model.ProfilePhotoPath = new List<string>();
        //        foreach (IFormFile photo in photos)
        //        {
        //            var path = Path.Combine(this.hostingEnvironment.WebRootPath, "images", photo.FileName);
        //            var stream = new FileStream(path, FileMode.Create);
        //            photo.CopyToAsync(stream);
        //            _context.tbl_employeeData.Add(model);
        //        }
        //    }
         
        //}

        public class FileUploadAPI
        {
            public IFormFile files { get; set; }
        }

    }
}
