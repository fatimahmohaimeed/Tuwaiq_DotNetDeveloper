using HRSystem.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Base_Repository
{
    public class BaseRepository
    {
        /// <summary>
        /// BaseRepository is data layer  to manage the physical storage and retrieval of data from DB.
        /// </summary>
        /// 
        private readonly string connectionString;

        #region DB Connection
        protected BaseRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["HRSystem"].ConnectionString;
        }
        protected SqlConnection GetConnection()
        {
            var result = new SqlConnection(connectionString);
            return result;
        }
        #endregion

        #region Check employee role
        public int GetEmployeeRole(SqlCommand command, SqlConnection connection)
        {
            try
            {
                connection.Open();
                var result = (int)command.ExecuteScalar();
                return result;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region Insert new employee, delete employee and update employee department
        public int ExecuteNonQueryEmployee(SqlCommand command, SqlConnection connection)
        {
            try
            {
                connection.Open();
                var result = (int)command.ExecuteNonQuery();
                return result;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region List all employee in department
        public List<Employee> GetDepartmentEmployees(SqlCommand command, SqlConnection connection)
        {
            var list = new List<Employee>();
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var employee = new Employee();
                    employee.EmployeeID = Convert.ToInt32(reader[0]);
                    employee.EmployeeName = reader[1].ToString();
                    employee.Salary = Convert.ToInt32(reader[2]);
                    employee.Role_id = Convert.ToInt32(reader[3]);
                    employee.Department_id = Convert.ToInt32(reader[4]);

                    list.Add(employee);
                }

                return list;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region Department details
        public Department GetDepartmentDetails(SqlCommand command, SqlConnection connection)
        {
            var department = new Department();
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    department.DepartmentEmployeeNum = Convert.ToInt32(reader[0]);
                    department.DepartmentID = Convert.ToInt32(reader[1]);
                    department.DepartmentName = reader[2].ToString();
                }
                return department;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

        #region List employee details
        public Employee GetEmployeeDetails(SqlCommand command, SqlConnection connection)
        {
            var employee = new Employee();

            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employee.EmployeeID = Convert.ToInt32(reader[0]);
                    employee.EmployeeName = reader[1].ToString();
                    employee.Salary = Convert.ToInt32(reader[2]);
                    employee.Role_id = Convert.ToInt32(reader[3]);
                    employee.Department_id = Convert.ToInt32(reader[4]);

                }

                return employee;
            }
            finally
            {
                connection.Close();
            }
        }
        #endregion

    }
}
