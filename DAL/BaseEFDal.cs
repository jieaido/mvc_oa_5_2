using System;
using System.Data.Entity;
using System.Linq;
using MVCOA_5.Model;

namespace DAL
{
    // ReSharper disable once InconsistentNaming
    public class  BaseEFDal<T> where T:class ,new()
    {
        protected OAModels Oadb = new OAModels();

        public virtual T Add(T entity)
        {
            Oadb.Set<T>().Add(entity);
            Oadb.SaveChanges();

            return entity;
        }

        public virtual bool Delete(T entity)
        {
            Oadb.Set<T>().Attach(entity);
            Oadb.Set<T>().Remove(entity);
            return Oadb.SaveChanges() > 0;
        }

        public virtual  int Deletes(params int[] ids)
        {
            foreach (int id in ids)
            {
                T entity = Oadb.Set<T>().Find(id);
                if (entity == null)
                {
                    return -1;
                }
                Oadb.Set<T>().Attach(entity);
                Oadb.Entry(entity).State = EntityState.Deleted;
            }
            return Oadb.SaveChanges();
        }

        public virtual  bool Update(T entity)
        {
            return false;
        }

        public virtual  IQueryable<T> Select(Func<T, bool> whereLambda)
        {
            return Oadb.Set<T>().Where(whereLambda).AsQueryable();
        }

        public virtual  IQueryable<T> Pages<Tkey>(int pageSize, int pageIndex, out int Count, Func<T, bool> wherelambda,
            Func<T, Tkey> orderlambda)
        {
            Count = Oadb.Set<T>().Where(wherelambda).Count();
            return
                Oadb.Set<T>().Where(wherelambda)
                    .Take(pageSize)
                    .Skip((pageIndex - 1)*pageIndex)
                    .OrderBy(orderlambda)
                    .AsQueryable();
        }

        public virtual  IQueryable<T> PagesbyDes<Tkey>(int pageSize, int pageIndex, out int Count, Func<T, bool> wherelambda,
            Func<T, Tkey> orderlambda)
        {
            Count = Oadb.Set<T>().Where(wherelambda).Count();
            return
                Oadb.Set<T>().Where(wherelambda)
                    .Take(pageSize)
                    .Skip((pageIndex - 1)*pageIndex)
                    .OrderByDescending(orderlambda)
                    .AsQueryable();
        }

      
    }
}