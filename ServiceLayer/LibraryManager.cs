using DataLayer;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public class LibraryManager<T, K>
    {

        private readonly IDb<T, K> context;     


        public LibraryManager(IDb<T, K> context)
        {
            this.context = context;
        }

       
        public void Create(T item)
        {
            context.Create(item);
        }

        public T Read(K key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return context.Read(key, useNavigationalProperties, isReadOnly);
        }

        public List<T> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return context.ReadAll(useNavigationalProperties, isReadOnly);
        }

        public void Update(T item, bool useNavigationalProperties = false)
        {
            context.Update(item, useNavigationalProperties);
        }

        public void Delete(K key)
        {
            context.Delete(key);
        }


   }
}
