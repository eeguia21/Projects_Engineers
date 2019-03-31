using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Projects_Engineers_Data
{
    public class DataAccessSQL<T> : IDataAccess<T> where T: BaseEntity
    {
        internal Projects_Engineers context;
        internal DbSet dbSet;

        public DataAccessSQL(Projects_Engineers context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public IQueryable<T> Collection()
        {
            return (IQueryable<T>)dbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var t = Find(Id);

            if (context.Entry(t).State == EntityState.Detached)
                dbSet.Attach(t);

            dbSet.Remove(t);

        }

        public T Find(int Id)
        {
            var t = dbSet.Find(Id);

            return (T)t;
        }

        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        public void Update(T t)
        {
            dbSet.Attach(t);
            context.Entry(t).State = EntityState.Modified;
        }
    }
}
