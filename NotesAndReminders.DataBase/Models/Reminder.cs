﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesAndReminders.DataBase.Models
{
    public class Reminder
    {
        [Key]
        public int ReminderId { get; set; }             
        public DateTimeOffset DeadLine { get; set; }   //Дата напоминания        
        public Note? Note { get; set; }
    }
}
