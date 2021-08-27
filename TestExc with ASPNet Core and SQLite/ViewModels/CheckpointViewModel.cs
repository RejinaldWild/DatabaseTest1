using System;

namespace TestExc_with_ASPNet_Core_and_SQLite.ViewModels
{
    public class CheckpointViewModel
    {
        public int Id { get; set; }
        public DateTime CheckpointStart { get; set; }
        public DateTime? CheckpointEnd { get; set; }
        public TimeSpan WorkingHours { get; set; }
    }
}
