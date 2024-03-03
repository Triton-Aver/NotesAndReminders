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
            //foreach(var tag in obj.Tags)
            //{
            //    _db.Database.ExecuteSqlRaw(@$"INSERT INTO public.""NoteTage"" (""NoteId"", ""TagId"") VALUES ({obj.NoteId}, {tag.TagId});");
            //}
        }
    }
}
