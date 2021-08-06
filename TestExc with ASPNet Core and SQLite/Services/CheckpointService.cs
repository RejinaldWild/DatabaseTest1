using System;
using System.Collections.Generic;
using System.Linq;
using TestExc_with_ASPNet_Core_and_SQLite.Models;
using TestExc_with_ASPNet_Core_and_SQLite.ViewModels;
using TestExc_with_ASPNet_Core_and_SQLite.Converters;

namespace TestExc_with_ASPNet_Core_and_SQLite.Services
{
    //КПП сервис
    public class CheckpointService
    {  
        //int Count = 0;
        private readonly TestExcContext Db;
        
        public CheckpointService(TestExcContext db)
        {
            Db = db;
        }

        public ICollection<TimeShiftViewModel> GetAll()
        {
            return Db.TimeShifts
                .ToViewModels()
                .ToList();
        }
        
        public void AddStartShift(DateTime employeeShift, int id)
        {   
            Db.TimeShifts
                .ToViewModels()
                .ToList()
                .Find(p => p.Id == id);

            Db.TimeShifts
                .ToViewModels()
                .ToList()
                .Find(p => p.StartShift != null)
                .StartShift.Add(employeeShift.TimeOfDay);

            Db.SaveChanges();

            //employeeShift.Employee = employee;
            //Count++;

            //int ShiftCount = Count % 2;
            //if (ShiftCount == 1)
            //{
            //    employeeShift.StartShift = DateTime.Now;
            //}
            //else
            //{
            //    employeeShift.EndShift = DateTime.Now;
            //    employeeShift.WorkingHours = employeeShift.EndShift - employeeShift.StartShift;
            //}
            //Db.TimeShifts.Add(employeeShift);
            //employee.TimeShifts.Add(employeeShift);

        }

        public void AddEndShift(DateTime employeeShift, int id)
        {

            Db.TimeShifts
                .ToViewModels()
                .ToList()
                .Find(p => p.Id == id);

            Db.TimeShifts
                .ToViewModels()
                .ToList()
                .Find(p => p.StartShift != null)
                .StartShift.Add(employeeShift.TimeOfDay);

            Db.SaveChanges();

            //employeeShift.Employee = employee;
            //Count++;

            //int ShiftCount = Count % 2;
            //if (ShiftCount == 1)
            //{
            //    employeeShift.StartShift = DateTime.Now;
            //}
            //else
            //{
            //    employeeShift.EndShift = DateTime.Now;
            //    employeeShift.WorkingHours = employeeShift.EndShift - employeeShift.StartShift;
            //}
            //Db.TimeShifts.Add(employeeShift);
            //employee.TimeShifts.Add(employeeShift);
            //Db.SaveChanges();
        }
    }
}
