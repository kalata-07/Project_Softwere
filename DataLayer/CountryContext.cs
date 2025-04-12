using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class CountryContext : IDb<Country, string>
    {
        private readonly DBLibraryContext dbContext;

        public CountryContext(DBLibraryContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Create(Country item)
        {
            if (string.IsNullOrEmpty(item.CountryCode) || string.IsNullOrEmpty(item.CountryName) || string.IsNullOrEmpty(item.ContinentCode))
            {
                throw new ArgumentException("CountryCode, CountryName, and ContinentCode are required.");
            }

            if (dbContext.Countries.Any(c => c.CountryCode == item.CountryCode))
            {
                throw new InvalidOperationException($"A country with code '{item.CountryCode}' already exists.");
            }

            dbContext.Countries.Add(item);
            dbContext.SaveChanges();
        }

        public Country Read(string key, bool useNavigationalProperties = false, bool isReadOnly = true)
        {
            IQueryable<Country> query = dbContext.Countries;

            if (useNavigationalProperties)
            {
                query = query.Include(c => c.ContinentCodeNavigation)
                             .Include(c => c.Footballers)
                             .Include(c => c.Stadium)
                             .Include(c => c.Teams)
                             .Include(c => c.Trophies);
            }

            if (isReadOnly)
            {
                query = query.AsNoTracking();
            }

            Country country = query.FirstOrDefault(c => c.CountryCode == key);

            if (country == null)
            {
                throw new ArgumentException($"Country with CountryCode '{key}' not found!");
            }

            return country;
        }

        public List<Country> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Country> query = dbContext.Countries;

            if (useNavigationalProperties)
            {
                query = query.Include(c => c.ContinentCodeNavigation)
                             .Include(c => c.Footballers)
                             .Include(c => c.Stadium)
                             .Include(c => c.Teams)
                             .Include(c => c.Trophies);
            }

            if (isReadOnly)
            {
                query = query.AsNoTracking();
            }

            return query.ToList();
        }

        public void Update(Country item, bool useNavigationalProperties = false)
        {
            if (string.IsNullOrEmpty(item.CountryCode))
            {
                throw new ArgumentException("CountryCode is required.");
            }

            Country existing = dbContext.Countries.Find(item.CountryCode);
            if (existing == null)
            {
                throw new ArgumentException($"Country with CountryCode '{item.CountryCode}' not found!");
            }

            dbContext.Entry(existing).State = EntityState.Detached;  
            dbContext.Entry(item).State = EntityState.Modified;      

            dbContext.SaveChanges();
        }

        public void Delete(string key)
        {
            Country existing = dbContext.Countries.Find(key);
            if (existing == null)
            {
                throw new ArgumentException($"Country with CountryCode '{key}' not found!");
            }

            dbContext.Countries.Remove(existing);
            dbContext.SaveChanges();
        }
    }
}
