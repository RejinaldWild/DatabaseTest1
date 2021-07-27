using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExc_with_ASPNet_Core_and_SQLite.Models
{
    // One file per class or structure
    public enum Position
    {
        Manager=1,
        Engineer,
        CandleTester
    }
    public class Employee
    {
        public int Id { get; set; }
        // Surname
        // it would be nice to add a limit on the size of the stored information in the database for string fields
        public string Surename { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        // Could be named "Position"
        public Position EmployeePosition { get; set; }
        // Could be named "TimeShifts"
        public List<TimeShift> LTimeShift { get; set; }
    }
    public class TimeShift
    {
        public int Id { get; set; }
        public DateTime StartShift { get; set; }
        public DateTime EndShift { get; set; }
        public TimeSpan WorkingHours { get; set; }
        // Could be named "Employee"
        public Employee EmployeeId { get; set; }
    }
}
