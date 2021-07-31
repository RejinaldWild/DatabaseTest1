using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestExc_with_ASPNet_Core_and_SQLite.Converters;
using TestExc_with_ASPNet_Core_and_SQLite.Models;
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
            return Db.EmployeeItems
                .Include(c => c.LTimeShift)
                .ToViewModels();
        }

        public Employee Get(int id) => Db.EmployeeItems.FirstOrDefault(p => p.Id == id);
        public List<Employee> Get(Position position)
        {   
            return Db.EmployeeItems.Where(employee => employee.EmployeePosition == position).ToList();
        }
        public void Add(Employee employee)
        {    
            Db.EmployeeItems.Add(employee);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {   
            Employee employee = Get(id);
            Db.EmployeeItems.Remove(employee);
            Db.SaveChanges();
        }

        public void Update(Employee employee)
        {
            int index = Db.EmployeeItems.FirstOrDefault(p => p.Id == employee.Id).Id;
            if (index == -1) return;
            int minIndex = 0;
            int maxIndex = Db.EmployeeItems.ToList().Count-1;
            while (minIndex <= maxIndex)
            {
                int midIndex = minIndex + maxIndex;
                int rightIndex = Db.EmployeeItems.ToList()[midIndex].Id;
                if (rightIndex == employee.Id)
                {
                    Db.EmployeeItems.ToList()[midIndex] = employee; // не может изменить, словно заблокированно

                    //костыли ниже
                    Db.EmployeeItems.ToList()[midIndex].Id = employee.Id;
                    Db.EmployeeItems.ToList()[midIndex].Name = employee.Name;
                    Db.EmployeeItems.ToList()[midIndex].SecondName = employee.SecondName;
                    Db.EmployeeItems.ToList()[midIndex].Surename = employee.Surename;
                    Db.EmployeeItems.ToList()[midIndex].EmployeePosition = employee.EmployeePosition;
                    Db.EmployeeItems.ToList()[midIndex].LTimeShift = employee.LTimeShift;
                }
                if (rightIndex > employee.Id)
                {
                    maxIndex = midIndex - 1;
                }
                else
                {
                    minIndex = midIndex + 1;
                }
            }
            Db.SaveChanges();
        }
    }
}
