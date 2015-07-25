using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IBaseDal<T> where T : class, new()
    {
        T Add(T entity);
        bool Delete(T entity);
        int Deletes(params int[] ids);
        bool Update(T entity);
        IQueryable<T> Select(Func<T, bool> whereLambda);

        IQueryable<T> Pages<Tkey>(int pageSize, int pageIndex, out int Count, Func<T, bool> wherelambda,
            Func<T, Tkey> orderlambda);

        IQueryable<T> PagesbyDes<Tkey>(int pageSize, int pageIndex, out int Count, Func<T, bool> wherelambda,
            Func<T, Tkey> orderlambda);
    }
}
