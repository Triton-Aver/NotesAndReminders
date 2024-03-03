using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesAndReminders.DataBase.Models
{
    public class Tage
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; } = string.Empty;    //название тэга        
    }
}
