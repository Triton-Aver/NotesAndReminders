using NotesAndReminders.DataBase.Models;

namespace NotesAndReminders.Server.Interfaces
{
    public interface ITageRepository: IRepositoryBase<Tage>
    {
        void Update(Tage obj);
    }
}
