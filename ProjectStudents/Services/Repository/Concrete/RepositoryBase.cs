using Microsoft.EntityFrameworkCore;
using ProjectStudents.DataAccess;
using ProjectStudents.Services.Repository.Interfaces;
using System.Linq.Expressions;

namespace ProjectStudents.Services.Repository.Concrete
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected Context context { get; set; }

        public RepositoryBase(Context context)
        {
            this.context = context;
        }

        public IQueryable<T> FindAll()
        {
            return this.context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
