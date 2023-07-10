using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int Salary { get; set; }
        public int Role_id { get; set; }
        public int Department_id { get; set; }
    }
}
