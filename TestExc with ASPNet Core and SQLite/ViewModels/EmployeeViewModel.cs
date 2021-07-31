using System.Collections.Generic;
using TestExc_with_ASPNet_Core_and_SQLite.Models;

namespace TestExc_with_ASPNet_Core_and_SQLite.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public Position Position { get; set; }
        public ICollection<TimeShiftViewModel> TimeShifts { get; set; }
    }
}
