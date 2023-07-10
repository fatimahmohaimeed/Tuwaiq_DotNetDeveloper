using HRSystem.Base_Repository;
using HRSystem.Constants;
using HRSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.BusinessLayer
{
 public class CRUD_Operations : BaseRepository
    {
        /// <summary>
        /// CRUD Operation is business layer maintains business rules.
        /// </summary>
        /// 
        public static readonly CRUD_Operations Instance = new CRUD_Operations();

        # region Check employee role
        public int CheckEmployeeRole(int employeeId)
        {
            var con = GetConnection();
            var cmd = new SqlCommand(ConstantsQuery.SelectEmployeeRole, con);

            cmd.Parameters.AddWithValue("EmployeeID", employeeId);

            var result = GetEmployeeRole(cmd, con);
            return result;
        }
        #endregion

        #region Insert new employee
        public int AddEmployee(Employee employee)
        {
            var con = GetConnection();
            var cmd = new SqlCommand(ConstantsQuery.InsertEmployee, con);

            cmd.Parameters.AddWithValue("EmployeeName", employee.EmployeeName);
            cmd.Parameters.AddWithValue("Salary", employee.Salary);
            cmd.Parameters.AddWithValue("Role_id", employee.Role_id);
            cmd.Parameters.AddWithValue("Department_id", employee.Department_id);

            var result = ExecuteNonQueryEmployee(cmd, con);
            return result;

        }
        #endregion

        #region List all employee in department
        public List<Employee> GetEmployees(int DepartmentId)
        {
            var con = GetConnection();
            var cmd = new SqlCommand(ConstantsQuery.DepartmentEmployees, con);

            cmd.Parameters.AddWithValue("Department_id", DepartmentId);

            var result = GetDepartmentEmployees(cmd, con);
            return result;
        }
        #endregion

        #region List department details
        public Department GetDepartment(int DepartmentId)
        {
            var con = GetConnection();
            var cmd = new SqlCommand(ConstantsQuery.DepartmentDetails, con);

            cmd.Parameters.AddWithValue("DepartmentID", DepartmentId);

            var details = GetDepartmentDetails(cmd, con);
            return details;

        }
        #endregion

        #region Delete employee
        public int DeleteEmployee(int EmployeeId)
        {
            var con = GetConnection();
            var cmd = new SqlCommand(ConstantsQuery.DeleteEmployee, con);

            cmd.Parameters.AddWithValue("EmployeeID", EmployeeId);

            var result = ExecuteNonQueryEmployee(cmd, con);
            return result;

        }
        #endregion

        #region List employee details
        public Employee GetEmployeeDetails(int EmployeeId)
        {
            var con = GetConnection();
            var cmd = new SqlCommand(ConstantsQuery.EmployeeDetails, con);

            cmd.Parameters.AddWithValue("EmployeeID", EmployeeId);

            var result = GetEmployeeDetails(cmd, con);
            return result;

        }
        #endregion

        #region Update employee department
        public int UpdateEmployeeDepartment(int EmployeeId, int Department_id)
        {

            var con = GetConnection();
            var cmd = new SqlCommand(ConstantsQuery.UpdateDepartment, con);

            cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId);
            cmd.Parameters.AddWithValue("@Department_id", Department_id);

            var result = ExecuteNonQueryEmployee(cmd, con);
            return result;
        }
        #endregion
    }
}
