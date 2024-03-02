using System.ComponentModel.DataAnnotations;

namespace NotesAndReminders.DataBase.Models
{
    public class Reminder
    {
        [Key]
        public int ReminderId { get; set; }
        public DateTime DeadLine { get; set; } = DateTime.Now.AddDays(1);    //Дата напоминания
    }
}
