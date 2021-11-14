using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.IRepository
{
        public interface IRepo<T> where T: class
        {
            public List<T> GetAll();

            public T FindById(int id);

            public void Add(T newObject);

            public void Delete(int id);

            public void Update(T obj);

            public void Save();
        }
    }

