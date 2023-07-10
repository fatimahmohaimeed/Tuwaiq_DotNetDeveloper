using HRSystem.BusinessLayer;
using HRSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem
{
    public class Program
    {
        public static readonly CRUD_Operations operation = CRUD_Operations.Instance;
        static void Main(string[] args)
        {
            string employeeId;
            string choice;

            while (true)
            {
                Console.WriteLine("PLease enter your ID to proceed or press enter to exit: ");
                employeeId = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(employeeId))
                {
                    break;
                }

                var employeeRole = operation.CheckEmployeeRole(Convert.ToInt32(employeeId));

                if (employeeRole == 1)
                {
                    do
                    {
                        var stringBuilder = new StringBuilder();
                        stringBuilder.Append('-', 20);

                        Console.WriteLine("Please select an option from the below menu or press enter to logout: \n" + stringBuilder);
                        Console.WriteLine("1- Create a new employee\n2- List department employees\n3- List Department details\n4- Delete an employee\n" + stringBuilder);
                        choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                Employee employee = new Employee();

                                Console.WriteLine("Enter employee name: ");
                                employee.EmployeeName = Console.ReadLine();

                                Console.WriteLine("Enter employee salary: ");
                                employee.Salary = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Enter employee role (1- manager, 2- employee): ");
                                employee.Role_id = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Enter employee department Id (1- IT, 2- Human Resources, 3- Accounting, 4- Business): ");
                                employee.Department_id = Convert.ToInt32(Console.ReadLine());

                                var result = operation.AddEmployee(employee);
                                if (result > 0)
                                {
                                    Console.WriteLine("Employee added successfully!\n");
                                }
                                else
                                {
                                    Console.WriteLine("Employee couldn't be inserted\n");
                                }
                                break;
                            case "2":
                                Console.WriteLine("Enter department Id to list its employees (1- IT, 2- Human Resources, 3- Accounting, 4- Business):");
                                var deptId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(stringBuilder + "\nEmployee ID\tEmployee Name\t\tEmployee Salary\t\tRole ID\t\tDepartment ID");
                                var employees = operation.GetEmployees(deptId);
                                foreach (var emp in employees)
                                {
                                    Console.WriteLine(emp.EmployeeID + "\t\t" + emp.EmployeeName + (emp.EmployeeName.Length < 7 ? "\t\t\t" : "\t\t") + emp.Salary + "\t\t\t" + emp.Role_id + "\t\t" + emp.Department_id);
                                }
                                break;
                            case "3":
                                Console.WriteLine("Enter department Id to list its details (1- IT, 2- Human Resources, 3- Accounting, 4- Business):");
                                deptId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine(stringBuilder + "\nDepartment ID\tDepartment Name\t\tNumber of employees");
                                var department = operation.GetDepartment(deptId);
                                Console.WriteLine(department.DepartmentID + "\t\t" + department.DepartmentName + (department.DepartmentName.Length < 7 ? "\t\t\t" : "\t\t") + department.DepartmentEmployeeNum);
                                break;
                            case "4":
                                Console.WriteLine("Enter the employee ID to delete it: ");
                                var empid = Convert.ToInt32(Console.ReadLine());
                                result = operation.DeleteEmployee(empid);
                                if (result > 0)
                                {
                                    Console.WriteLine("Employee deleted successfully!\n");
                                }
                                else
                                {
                                    Console.WriteLine("Employee couldn't be deleted\n");
                                }
                                break;
                        }
                    } while (!string.IsNullOrWhiteSpace(choice));


                }
                else
                {
                    do
                    {

                        var stringBuilder = new StringBuilder();
                        stringBuilder.Append('-', 20);

                        Console.WriteLine("Please select an option from the below menu or press enter to logout: \n" + stringBuilder);
                        Console.WriteLine("1- List your details\n2- Change your department\n" + stringBuilder);
                        choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                Console.WriteLine(stringBuilder + "\nEmployee ID\tEmployee Name\t\tEmployee Salary\t\tRole ID\t\tDepartment ID");
                                var employee = operation.GetEmployeeDetails(Convert.ToInt32(employeeId));
                                Console.WriteLine(employee.EmployeeID + "\t\t" + employee.EmployeeName + (employee.EmployeeName.Length < 7 ? "\t\t\t" : "\t\t") + employee.Salary + "\t\t\t" + employee.Role_id + "\t\t" + employee.Department_id);
                                break;
                            case "2":
                                Console.WriteLine("Enter department Id to change your department (1- IT, 2- Human Resources, 3- Accounting, 4- Business):");
                                var deptId = Convert.ToInt32(Console.ReadLine());
                                var result = operation.UpdateEmployeeDepartment(Convert.ToInt32(employeeId), deptId);
                                if (result > 0)
                                {
                                    Console.WriteLine("Department updated successfully!\n");
                                }
                                else
                                {
                                    Console.WriteLine("Department couldn't be updated\n");
                                }
                                break;
                        }
                    } while (!string.IsNullOrWhiteSpace(choice));
                }

            }
        }
    }
}
