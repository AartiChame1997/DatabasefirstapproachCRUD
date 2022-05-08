using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DatabasefirstapproachCRUD.Model
{
    public class tbl_employeeData
    {

        [Key]
        public int Employeeid { get; set; }
        public int EmployeeNo { get; set; }

        public string EmployeeName { get; set; }

        public string MobileNo { get; set; }

        public string Emailid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string SpouseName { get; set; }
        public string Child1Name { get; set; }
        public string Child2Name { get; set; }
        public string PAddressLine1 { get; set; }
        public string PAddressLine2 { get; set; }
        public string Pcity { get; set; }
        public string Pstate { get; set; }
        public string Pincode { get; set; }
        public bool IsSameAddress { get; set; }
        public string CAddressLine1 { get; set; }
        public string CAddressLine2 { get; set; }
        public string Ccity { get; set; }
        public string CpState { get; set; }
        public string CPpincode { get; set; }
        public DateTime? joiningDate { get; set; }
        public string Division { get; set; }
        public string Department { get; set; }
        public string ProfilePhotoPath { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public string EmergencyNo { get; set; }

       
    }
}
