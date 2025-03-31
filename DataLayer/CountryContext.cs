using BuisnessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal class CountryContext : IDb<Country, string>
    {
        private FootballteamsContext dbContext;

        public CountryContext(FootballteamsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Country item)
        {
            dbContext.Countries.Add(item);
            dbContext.SaveChanges();
        }

        public Country Read(string key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Country> query = dbContext.Countries;

            if (useNavigationalProperties)
            {
                query = query.Include(c => c.ContinentCode);
            }

            if (isReadOnly)
            {
                query = query.AsNoTracking();
            }

            return query.FirstOrDefault(c => c.CountryCode == key);
        }

        public List<Country> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Country> query = dbContext.Countries;

            if (useNavigationalProperties)
            {
                query = query.Include(c => c.ContinentCode);
            }

            if (isReadOnly)
            {
                query = query.AsNoTracking();
            }

            return query.ToList();
        }

        public void Update(Country item, bool useNavigationalProperties = false)
        {
            Country existing = Read(item.CountryCode, useNavigationalProperties);
            if (existing == null)
            {
                throw new ArgumentException("Country not found!");
            }

            dbContext.Entry(existing).CurrentValues.SetValues(item);
            dbContext.SaveChanges();
        }

        public void Delete(string key)
        {
            Country existing = Read(key);
            if (existing == null)
            {
                throw new ArgumentException("Country not found!");
            }

            dbContext.Countries.Remove(existing);
            dbContext.SaveChanges();
        }
    }
}
