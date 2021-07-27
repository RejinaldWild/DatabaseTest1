using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestExc_with_ASPNet_Core_and_SQLite.Models;

namespace TestExc_with_ASPNet_Core_and_SQLite.Services
{
    //КПП сервис
    // Your service is called "employee" but work is carried out with shifts
    public class EmployeeService
    {
        // using variables in a class that can be cleaned up is not very cool
        int Count = 0;
        TestExcContext Db;
        
        public EmployeeService(TestExcContext db)
        {
            Db = db;
        }

        public List<Employee> GetAll() 
        {
            return Db.EmployeeItems.ToList();
        }

        // variable names should speak for themselves. It would be clear here if the variable were called "employee id"
        public List<TimeShift> Get(int id)
        {
            //return Db.TimeShifts.Where(a => a.EmployeeId.Id == id).ToList()
            // Read how the ToList method works
            // + the request in the request is not very good when it can be avoided
            return Db.TimeShifts.ToList().FindAll(p => p.EmployeeId == Db.EmployeeItems.FirstOrDefault(p => p.Id == id));
        } 
        public void Add(TimeShift employeeShift, Employee employee)
        {
            // here it is better to get the employee ID and the offset date at the entrance and work from this already
            employeeShift.EmployeeId = employee;
            Count++;

            int ShiftCount = Count % 2;
            if (ShiftCount == 1)
            {
                employeeShift.StartShift = DateTime.Now;
            }
            else
            {
                employeeShift.EndShift = DateTime.Now;
                employeeShift.WorkingHours = employeeShift.EndShift - employeeShift.StartShift;
            }
            Db.TimeShifts.Add(employeeShift);
            employee.LTimeShift.Add(employeeShift);
            Db.SaveChanges();
        }
    }
}
