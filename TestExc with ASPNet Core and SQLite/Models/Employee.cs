using System.Collections.Generic;

namespace TestExc_with_ASPNet_Core_and_SQLite.Models
{   
    public class Employee
    {
        public int Id { get; set; }
        public string Surename { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public Position Position { get; set; }
        public ICollection<TimeShift> TimeShifts { get; set; }
    }    
}
