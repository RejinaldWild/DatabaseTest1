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
        private readonly TestExcContext Db;
        
        public CheckpointService(TestExcContext db)
        {
            Db = db;
        }

        public ICollection<TimeShiftViewModel> GetAll()
        {
            return Db.TimeShifts
                .ToViewModels();
        }
        
        public void AddShiftPoint(int id,CheckpointViewModel checkpoint)
        {            
            if (checkpoint.Id != id) return;

            if (checkpoint.CheckpointStart == DateTime.Today &&
                checkpoint.CheckpointEnd != DateTime.Today) return;
            else if (checkpoint.CheckpointStart.Date != DateTime.Today &&
                checkpoint.CheckpointEnd == DateTime.Today) return;

            if (checkpoint.CheckpointStart == DateTime.Today && checkpoint.CheckpointEnd == null)
            {   
                checkpoint.CheckpointEnd = DateTime.Now;
                Db.TimeShifts
                    .FirstOrDefault(p => p.Id == id)
                    .EndShift.HasValue.ToString();

                checkpoint.WorkingHours = checkpoint.CheckpointEnd.Value - checkpoint.CheckpointStart;

                Db.TimeShifts
                    .FirstOrDefault(p => p.Id == id)
                    .WorkingHours.Add(checkpoint.WorkingHours);                
            }
            else
            {
                checkpoint.CheckpointStart = DateTime.Now;
                Db.TimeShifts
                .FirstOrDefault(p => p.Id == id)
                .StartShift.Add(checkpoint.CheckpointStart.TimeOfDay);
            }
            
            Db.SaveChanges();
        }
    }
}
