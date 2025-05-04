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

        public void Create(Continent item)
        {
            dbContext.Continents.Add(item);
            dbContext.SaveChanges();
        }
        public Continent Read(string key, bool useNavigationalProperties = false, bool isReadOnly = false)
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
        public List<Continent> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
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
        public void Update(Continent item, bool useNavigationalProperties = false)
        {
            Continent existing = Read(item.ContinentCode, useNavigationalProperties);
            if (existing == null)
            {
                throw new ArgumentException("Continent not found!");
            }

            dbContext.Entry(existing).CurrentValues.SetValues(item);
            dbContext.SaveChanges();
        }

        public void Delete(string key)
        {
            Continent existing = Read(key);
            if (existing == null)
            {
                throw new ArgumentException("Continent not found!");
            }

            dbContext.Continents.Remove(existing);
            dbContext.SaveChanges();
        }
    }
}
