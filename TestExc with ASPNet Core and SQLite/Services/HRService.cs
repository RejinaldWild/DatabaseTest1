using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestExc_with_ASPNet_Core_and_SQLite.Models;
using TestExc_with_ASPNet_Core_and_SQLite.Converters;
using TestExc_with_ASPNet_Core_and_SQLite.ViewModels;

namespace TestExc_with_ASPNet_Core_and_SQLite.Services
{
    public class HRService
    {        
        TestExcContext Db;

        public HRService(TestExcContext db)
        {
            Db = db;
        }

        public ICollection<EmployeeViewModel> GetAll()
        {
            return Db.Employees
                .Include(f => f.TimeShifts)
                .ToViewModels();
        }

        public EmployeeViewModel Get(int id) => Db.Employees.ToViewModels().FirstOrDefault(p => p.Id == id);
        public ICollection<EmployeeViewModel> Get(Position position)
        {   
            return Db.Employees
                .Where(employee => employee.Position == position)
                .ToViewModels()
                .ToList();
        }
        public void Add(EmployeeViewModel employee)
        {    
            Db.Employees.ToViewModels().Add(employee);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {   
            EmployeeViewModel employee = Get(id);
            Db.Employees.ToViewModels().Remove(employee);
            Db.SaveChanges();
        }

        public void Update(int id, EmployeeViewModel employee, EmployeeViewModel existEmployee)
        {
            if (id != employee.Id) return;
            Db.Employees.ToViewModels().ToList(); // - ???
            Db.SaveChanges();

            //int index = Db.Employees.ToViewModels().FirstOrDefault(p => p.Id == employee.Id).Id;
            //if (index == -1) return;
            //int minIndex = 0;
            //int maxIndex = Db.Employees.ToList().Count-1;
            //while (minIndex <= maxIndex)
            //{
            //    int midIndex = minIndex + maxIndex;
            //    int rightIndex = Db.Employees.ToList()[midIndex].Id;
            //    if (rightIndex == employee.Id)
            //    {
            //        Db.Employees.ToList()[midIndex] = employee; // не может изменить, словно заблокированно

            //        //костыли ниже
            //        Db.Employees.ToList()[midIndex].Id = employee.Id;
            //        Db.Employees.ToList()[midIndex].Name = employee.Name;
            //        Db.Employees.ToList()[midIndex].SecondName = employee.SecondName;
            //        Db.Employees.ToList()[midIndex].Surname = employee.Surname;
            //        Db.Employees.ToList()[midIndex].Position = employee.Position;
            //        Db.Employees.ToList()[midIndex].TimeShifts = employee.TimeShifts;
            //    }
            //    if (rightIndex > employee.Id)
            //    {
            //        maxIndex = midIndex - 1;
            //    }
            //    else
            //    {
            //        minIndex = midIndex + 1;
            //    }
            //}

        }
    }
}
