using System;

namespace TestExc_with_ASPNet_Core_and_SQLite.ViewModels
{
    public class TimeShiftViewModel
    {
        public int Id { get; set; }
        public DateTime StartShift { get; set; }
        public DateTime? EndShift { get; set; }
        public TimeSpan WorkingHours { get; set; }
    }
}
