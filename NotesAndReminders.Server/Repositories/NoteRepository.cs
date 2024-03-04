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
            var objFromDb = base.FirstOrDefault(u => u.NoteId == obj.NoteId);
            if (objFromDb != null)
            {
                objFromDb.Header = obj.Header;
                objFromDb.Description = obj.Description;
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
