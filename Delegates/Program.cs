using System;
using System.Collections.Generic;

namespace Delegates
{
    public delegate bool GetEmployeeStatusDelegate(Employee employee);
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int YearsWorking { get; set; }
        public double Salary { get; set; }

        public void IsPromotable(List<Employee> employees, GetEmployeeStatusDelegate getEmployeeStatus)
        {
            foreach(var emp in employees)
            {
                if(getEmployeeStatus(emp))
                {
                    Console.WriteLine($"{emp.Name} is eligible for promotion.");
                }
            }
        }
    }
    class Program
    {
        public static bool GetStatus(Employee employee)
        {
            if(employee.Salary > 25000 || employee.YearsWorking >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee { ID = 1, Name = "Atharva", YearsWorking = 1, Salary = 20000 });
            employees.Add(new Employee { ID = 2, Name = "Vinayak", YearsWorking = 2, Salary = 26000 });
            employees.Add(new Employee { ID = 3, Name = "Veena", YearsWorking = 5, Salary = 25000 });
            employees.Add(new Employee { ID = 4, Name = "Tanmay", YearsWorking = 6, Salary = 21000 });

            GetEmployeeStatusDelegate getEmployeeStatusDelegate = new GetEmployeeStatusDelegate(GetStatus);
            Employee e = new Employee();
            e.IsPromotable(employees, getEmployeeStatusDelegate);
        }
    }
}
