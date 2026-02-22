using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer
{
    public class ContinentContext : IDb<Continent, string>
    {
        private DBLibraryContext dbContext;

        public ContinentContext(DBLibraryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Continent item)
        {
            dbContext.Continents.Add(item);
            await dbContext.SaveChangesAsync();
        }
        public async Task<Continent> ReadAsync(string key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Continent> query = dbContext.Continents;

            if (useNavigationalProperties)
            {
                query = query.Include(c => c.Countries);
            }

            if (isReadOnly)
            {
                query = query.AsNoTracking();
            }

            Continent continent = query.FirstOrDefault(c => c.ContinentCode == key);

            if (continent == null)
            {
                throw new ArgumentException($"Continent with ContinentCode '{key}' not found!");
            }

            return continent;
        }
        public async Task<IEnumerable<Continent>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Continent> query = dbContext.Continents;

            if (useNavigationalProperties)
            {
                query = query.Include(c => c.Countries);
            }

            if (isReadOnly)
            {
                query = query.AsNoTracking();
            }

            return query.ToList();
        }
        public async Task UpdateAsync(Continent item, bool useNavigationalProperties = false)
        {
            Continent existing = await ReadAsync(item.ContinentCode, useNavigationalProperties);
            if (existing == null)
            {
                throw new ArgumentException("Continent not found!");
            }

            dbContext.Entry(existing).CurrentValues.SetValues(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string key)
        {
            Continent existing = await ReadAsync(key);
            if (existing == null)
            {
                throw new ArgumentException("Continent not found!");
            }

            dbContext.Continents.Remove(existing);
            dbContext.SaveChanges();
        }
    }
}
