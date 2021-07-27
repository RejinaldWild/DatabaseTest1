using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestExc_with_ASPNet_Core_and_SQLite.Models;

namespace TestExc_with_ASPNet_Core_and_SQLite.Services
{
    //КПП сервис
    public class EmployeeService
    {  
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

        public List<TimeShift> Get(int id) 
        {
            return Db.TimeShifts.ToList().FindAll(p => p.EmployeeId == Db.EmployeeItems.FirstOrDefault(p => p.Id == id));
        } 
        public void Add(TimeShift employeeShift, Employee employee)
        {   
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
