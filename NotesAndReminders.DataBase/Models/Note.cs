using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesAndReminders.DataBase.Models
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }
        public string Header { get; set; } = string.Empty;       //заголовок
        public string Description { get; set; } = string.Empty;  //содержание заметки
        public DateTimeOffset DateCreate { get; set; } = DateTimeOffset.Now; //Дата создания заметка
        [ForeignKey(nameof(NoteId))]
        public ICollection<Tage>? Tags { get; set; } = new List<Tage>();
    }
}
