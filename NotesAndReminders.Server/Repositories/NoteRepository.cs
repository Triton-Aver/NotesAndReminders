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
            var objFromDb = _db.Notes.Include(u => u.Tags).FirstOrDefault(u => u.NoteId == obj.NoteId);
            if (objFromDb != null)
            {
                objFromDb.Header = obj.Header;
                objFromDb.Description = obj.Description;
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
    }
}
