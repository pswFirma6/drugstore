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
        private readonly DbSet<T> table;

        public Repo(DatabaseContext context)
        {
            _context = context;
            table = _context.Set<T>();
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
            return table.ToList();
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
