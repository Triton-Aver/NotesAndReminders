using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesAndReminders.DataBase.Models
{
    public class NoteTag
    {
        public int NoteId { get; set; }
        public Note Note { get; set; }
        public int TagId { get; set; }
        public Tage Tag { get; set; }
    }
}
