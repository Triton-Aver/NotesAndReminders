using System.Linq.Expressions;

namespace NotesAndReminders.Server.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        T Find(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filtr = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            bool isTracking = true
            );

        T FirstOrDefault(
            Expression<Func<T, bool>> filtr = null,
            string includeProperties = null,
            bool isTracking = true
            );

        void Add(T entity);
        void Remove(T entity);
        void Save();

    }
}
