using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExc_with_ASPNet_Core_and_SQLite.Models
{
    public enum Position
    {
        Manager=1,
        Engineer,
        CandleTester
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Surename { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public Position EmployeePosition { get; set; }
        public List<TimeShift> LTimeShift { get; set; }
    }
    public class TimeShift
    {
        public int Id { get; set; }
        public DateTime StartShift { get; set; }
        public DateTime EndShift { get; set; }
        public TimeSpan WorkingHours { get; set; }
        public Employee EmployeeId { get; set; }
    }
}
