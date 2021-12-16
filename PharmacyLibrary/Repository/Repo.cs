using PhramacyLibrary.Model;
using Microsoft.EntityFrameworkCore;
using PharmacyLibrary.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using PharmacyLibrary.Model;

namespace PharmacyLibrary.Repository
{
    public class Repo<T> : IRepo<T> where T: class
    {
        private readonly DatabaseContext _context;
        protected readonly DatabaseEventContext _eventContext;
        private readonly DbSet<T> table;

        public Repo(DatabaseContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public Repo(DatabaseEventContext context)
        {
            _eventContext = context;
            table = _eventContext.Set<T>();
        }

        public void Add(T newObject)
        {
            table.Add(newObject);
        }

        public void Delete(int id)
        {
            T exists = table.Find(id);
            table.Remove(exists);
        }

        public T FindById(int id)
        {
          return table.Find(id);
        }

        public List<T> GetAll()
        {
            try
            {
                return table.ToList();
            }
            catch
            {
                return new List<T>();
            }
            
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
