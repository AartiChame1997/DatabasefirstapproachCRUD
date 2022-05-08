using DatabasefirstapproachCRUD.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabasefirstapproachCRUD.Model;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;
using System.Web.Http;
using DatabasefirstapproachCRUD.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace DatabasefirstapproachCRUD.Controllers
{


    [Route("api/[controller]")]
    [ApiController]


    public class EmployeeController : ControllerBase
    {



        private readonly IEmployee _employee;

        private readonly IWebHostEnvironment _webHostEnvironment;

        List<Info> information = new List<Info>
        {
            new Info(){id=1,Name="Aarti"},
            new Info(){id=2,Name="Pranali"},

        };
        
    public class Info
    {
            public int id { get; set; }
            public string Name { get; set; }
    }

        public EmployeeController(IEmployee emp, IWebHostEnvironment webHostEnvironment)
        {
            _employee = emp;
            _webHostEnvironment = webHostEnvironment;
        }

        //HTTPError Exception handling
        //public HttpResponseMessage getbyid(int id)
        //{
        //    var res = information.Where(x => x.id == id).FirstOrDefault();
        //    if (res == null)
        //    {
        //        var errmsg = string.Format("Data is not found {0}", id);
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, errmsg);

        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, res);


        //}
        //HttpResponseException 

        [HttpPost]
        [Route("AddEmp")]
        public async Task<IActionResult> AddEmployee( EmployeeViewModel model, IFormFile files)
        {
            try
            {
                //file save operation

                if(model.CoverPhoto!=null)
                {
                    string folder = "books/cover";
                    folder += Guid.NewGuid().ToString() + "_" + model.CoverPhoto.FileName;
                    model.ProfilePhotoPath = folder;
                    string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                    model.CoverPhoto.CopyTo(new FileStream(serverfolder, FileMode.Create));
                }

                var res = _employee.AddEmpdata(model,files);
                if (res < 0)
                {
                    return NotFound();
                }
                return Ok(res);

            }

            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public IActionResult GetAll()
        {
            try
            {
                var res = _employee.GetEmployeeDetails();
                if (res == null)
                {
                    return NotFound();
                }
                return Ok(res);
            }

            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpGet]
        [Route("GetEmployee")]
        public IActionResult GetEmployee(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var res = _employee.GetEmployee(id);
                return Ok(res);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("DeleteEmp")]
        public IActionResult DeleteEmp(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var res = _employee.DeleteEmployee(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPut]
        [Route("UpadteEmp")]
        public IActionResult upadteemployee([FromBody] tbl_employeeData tbl, int id)
        {
            try
            {
                var res = _employee.UpdateEmployee(tbl, id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("SaveFile")]
        public IActionResult SaveFile(IFormFile files)
        {
            try
            {
                _employee.savefile(files);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("SaveEmployee")]
        public IActionResult SaveEmployee([FromForm] EmployeeRegistration employeeRegistration)
        {
            try
            {
                _employee.SignupEmp(employeeRegistration);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    } 
       
}
