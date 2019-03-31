using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects_Engineers_Data
{
    public interface IDataAccess<T> 
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(int Id);
        T Find(int Id);
        void Insert(T t);
        void Update(T t);
    }
}
