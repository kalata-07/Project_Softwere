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

       
        public async Task CreateAsync(T item)
        {
            await context.CreateAsync(item);
        }

        public async Task<T> ReadAsync(K key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return await context.ReadAsync(key, useNavigationalProperties, isReadOnly);
        }

        public async Task<IEnumerable<T>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return await context.ReadAllAsync(useNavigationalProperties, isReadOnly);
        }

        public async Task UpdateAsync(T item, bool useNavigationalProperties = false)
        {
           await context.UpdateAsync(item, useNavigationalProperties);
        }

        public async Task DeleteAsync(K key)
        {
            await context.DeleteAsync(key);
        }


   }
}
