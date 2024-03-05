using Microsoft.EntityFrameworkCore;
using NotesAndReminders.DataBase.Context;
using NotesAndReminders.DataBase.Models;
using NotesAndReminders.Server.Interfaces;

namespace NotesAndReminders.Server.Repositories
{
    public class NoteRepository: RepositoryBase<Note>, INoteRepository
    {
        private readonly ApplicationContext _db;

        public NoteRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Note obj)
        {
            //TODO нужно обработать удаление тэгов
            var objFromDb = _db.Notes.Include(u => u.Tags).FirstOrDefault(u => u.NoteId == obj.NoteId);

            if (objFromDb != null)
            {
                objFromDb.Header = obj.Header;
                objFromDb.Description = obj.Description;
                objFromDb.ReminderNote = obj.ReminderNote;

                foreach (var tags in obj.Tags)
                {
                    Tage tag = _db.Tages.Find(tags.TagId);
                    if (objFromDb.Tags.Where(u => u.TagId == tag.TagId).Count() == 0)
                    {
                        objFromDb.Tags.Add(tag);
                    }
                    else
                    {
                        objFromDb.Tags.Remove(tag);
                        _db.SaveChanges();
                        objFromDb.Tags.Add(tag);
                    }
                }
            }            
        }
        public void CreateNote(Note obj) 
        {
            Note note = new Note
            {
                Header = obj.Header,
                Description = obj.Description,
                DateCreate = obj.DateCreate
            };
            foreach (var tags in obj.Tags)
            {
                Tage tag = _db.Tages.Find(tags.TagId);                
                note.Tags.Add(tag);
            }
            _db.Notes.Add(note);
            _db.SaveChanges();
            //foreach(var tag in obj.Tags)
            //{
            //    _db.Database.ExecuteSqlRaw(@$"INSERT INTO public.""NoteTage"" (""NoteId"", ""TagId"") VALUES ({obj.NoteId}, {tag.TagId});");
            //}
        }

        public void RemoveNote(Note obj)
        {
            Note chekReminder = _db.Notes.Include(u => u.ReminderNote).FirstOrDefault(u => u.NoteId == obj.NoteId);
            _db.Notes.Remove(obj);
            if (chekReminder.ReminderNote != null)
            {
                Reminder reminder = _db.Reminders.Find(chekReminder.ReminderNote.ReminderId);
                _db.Reminders.Remove(reminder);
            }
            _db.SaveChanges();
        }
    }
}
