using Core.Person.Model.Base;
using Core.Person.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Person.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly MySqlContext _context;
        private DbSet<T> dataSet;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }
        public T Create(T entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public void Delete(long id)
        {
            var result = dataSet.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    dataSet.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindById(long id)
        {
            return dataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T entity)
        {
            try
            {
                if (!Exist(entity.Id)) return null;

                var result = dataSet.SingleOrDefault(p => p.Id.Equals(entity.Id));
                _context.Entry(result).CurrentValues.SetValues(entity);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return entity;
        }

        public bool Exist(long id)
        {
            return dataSet.Any(p => p.Id.Equals(id));
        }
    }
}
