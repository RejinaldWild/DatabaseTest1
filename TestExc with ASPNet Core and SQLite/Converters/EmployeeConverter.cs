using System.Collections.Generic;
using System.Linq;
using TestExc_with_ASPNet_Core_and_SQLite.Models;
using TestExc_with_ASPNet_Core_and_SQLite.ViewModels;

namespace TestExc_with_ASPNet_Core_and_SQLite.Converters
{
    public static class EmployeeConverter
    {
        public static EmployeeViewModel ToViewModel(this Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Position = employee.EmployeePosition,
                SecondName = employee.SecondName,
                Surname = employee.Surename,
                TimeShifts = employee.LTimeShift.ToViewModels()
            };
        }

        public static ICollection<EmployeeViewModel> ToViewModels(this IEnumerable<Employee> employee)
        {
            return employee
                .Select(a => a.ToViewModel())
                .ToList();
        }
    }
}
