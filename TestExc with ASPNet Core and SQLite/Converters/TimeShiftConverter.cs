using System;
using System.Collections.Generic;
using System.Linq;
using TestExc_with_ASPNet_Core_and_SQLite.Models;
using TestExc_with_ASPNet_Core_and_SQLite.ViewModels;

namespace TestExc_with_ASPNet_Core_and_SQLite.Converters
{
    public static class TimeShiftConverter
    {
        public static TimeShiftViewModel ToViewModel(this TimeShift timeShift)
        {
            return new TimeShiftViewModel
            {
                Id = timeShift.Id,
                StartShift = timeShift.StartShift,
                EndShift = timeShift.EndShift,
                WorkingHours = timeShift.WorkingHours
            };
        }

        public static ICollection<TimeShiftViewModel> ToViewModels(this IEnumerable<TimeShift> timeShifts)
        {
            return timeShifts
                .Select(a => a.ToViewModel())
                .ToList();
        }
    }
}
