using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using Library.DataAccess.Interface;

namespace Library.DataAccess
{
    public abstract class RepositoryConstructor<T> : IRepository<T> where T : class
    {
        protected DbContext Context {get; set;}

        public void Add(T entity) 
        {
                Context.Set<T>().Add(entity);
        }

        public void Remove(T entity){
                Context.Set<T>().Remove(entity);

        }

        public void Update(T entity){
                Context.Entry(entity).State = EntityState.Modified;
        }

        public abstract List<T> GetAll();

        public abstract T Get(int id);

        public abstract T GetByToken(Guid guid);

        public void Save() 
        {
            try {
                Context.SaveChanges();
            }
            catch (Exception e){
                new DbUpdateException("No se ha podido realizar la operacion",e);
            }

        }
    }
}