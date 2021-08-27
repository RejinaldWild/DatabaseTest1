using System;

namespace TestExc_with_ASPNet_Core_and_SQLite.Models
{
    public class TimeShift
    {
        public int Id { get; set; }
        public DateTime StartShift { get; set; }
        public DateTime? EndShift { get; set; }
        public TimeSpan WorkingHours { get; set; }
        public Employee Employee { get; set; }
    }
}
