using TestExc_with_ASPNet_Core_and_SQLite.Models;
using TestExc_with_ASPNet_Core_and_SQLite.ViewModels;


namespace TestExc_with_ASPNet_Core_and_SQLite.Converters
{
    public static class CheckpointConverter
    {
        public static CheckpointViewModel ToViewModel(this Employee employee, TimeShift timeShift)
        {
            return new CheckpointViewModel
            {
                Id = employee.Id,
                CheckpointStart = timeShift.StartShift,
                CheckpointEnd = timeShift.EndShift,
                WorkingHours = timeShift.WorkingHours
            };
        }
    }
}
