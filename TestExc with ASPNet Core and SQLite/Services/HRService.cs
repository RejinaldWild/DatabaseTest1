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
        private readonly TestExcContext Db;

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
                .ToViewModels();                
        }
        public void Add(EmployeeViewModel employee)
        {    
            Db.Employees
                .ToViewModels()
                .Add(employee);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {   
            EmployeeViewModel employee = Get(id);
            if (employee.Id != id) return;
            Db.Employees
                .ToViewModels()
                .Remove(employee);
            Db.SaveChanges();
        }

        public void Update(int id, EmployeeViewModel employee)
        {
            employee = Get(id);
            if (id != employee.Id) return;
            Db.Employees
                .ToViewModels()
                .Add(employee); //???
            Db.SaveChanges();
        }
    }
}