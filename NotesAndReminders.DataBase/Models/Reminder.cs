using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesAndReminders.DataBase.Models
{
    public class Reminder
    {
        [Key]
        public int ReminderId { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; } = DateTime.Now.AddDays(1);    //Дата напоминания        
        public DateTime DueDate { get; set; }

        [ForeignKey(nameof(ReminderId))]
        public Note? Note { get; set; }
    }
}
