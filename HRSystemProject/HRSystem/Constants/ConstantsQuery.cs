using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Constants
{
    public class ConstantsQuery
    {
        /// <summary>
        /// use ConstantsQuery for get data from Database and use it with Action to desplay them
        /// </summary>

        public const string InsertEmployee = "INSERT INTO Employee (EmployeeName, Salary, Role_id, Department_id)" +
            "VALUES (@EmployeeName, @Salary, @Role_id, @Department_id)";

        public const string DepartmentDetails = "SELECT A.NUM, B.ID, B.DEPT_NM FROM" +
            "(SELECT COUNT(EmployeeID) NUM FROM Employee WHERE Department_id = @DepartmentID) A, " +
            "(SELECT DepartmentID ID, DepartmentName DEPT_NM FROM Department WHERE DepartmentID = @DepartmentID)B";

        public const string DepartmentEmployees = "SELECT * FROM Employee WHERE Department_id = @Department_id";

        public const string SelectEmployeeRole = "SELECT Role_Id FROM Employee WHERE EmployeeID = @EmployeeID";

        public const string DeleteEmployee = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";

        public const string EmployeeDetails = "SELECT * FROM Employee WHERE EmployeeID = @EmployeeID";

        public const string UpdateDepartment = "UPDATE Employee SET Department_id = @Department_id WHERE EmployeeID = @EmployeeID";

        //public const string EmployeeDetails = "SELECT Employee.EmployeeName, Employee.Salary, Department.DepartmentName, Role.RoleName FROM Employee ,Department,Role" +
        //"WHERE Employee.Department_id = Department.DepartmentID AND Employee.Role_id  = Role.RoleId AND EmployeeID = @EmployeeID;";

    }
}
