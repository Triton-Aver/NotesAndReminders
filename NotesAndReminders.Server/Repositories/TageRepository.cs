using NotesAndReminders.DataBase.Context;
using NotesAndReminders.DataBase.Models;
using NotesAndReminders.Server.Interfaces;

namespace NotesAndReminders.Server.Repositories
{
    public class TageRepository: RepositoryBase<Tage>, ITageRepository
    {
        private readonly ApplicationContext _db;

        public TageRepository(ApplicationContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Tage obj)
        {
            var objFromDb = base.FirstOrDefault(u => u.TagId == obj.TagId);
            if (objFromDb != null)
            {
                objFromDb.TagName = obj.TagName;
            }
        }
    }
}
