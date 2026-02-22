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

        public async Task CreateAsync(Country item)
        {
            var existingCountry = dbContext.Countries.FirstOrDefault(c => c.CountryCode == item.CountryCode);

            if (existingCountry != null)
            {
                throw new ArgumentException($"Country with code '{item.CountryCode}' already exists.");
            }

            dbContext.Countries.Add(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Country> ReadAsync(string key, bool useNavigationalProperties = false, bool isReadOnly = true)
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

        public async Task<IEnumerable<Country>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = false)
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

        public async Task UpdateAsync(Country item, bool useNavigationalProperties = false)
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

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string key)
        {
            Country existing = dbContext.Countries.Find(key);
            if (existing == null)
            {
                throw new ArgumentException($"Country with CountryCode '{key}' not found!");
            }

            dbContext.Countries.Remove(existing);
            await dbContext.SaveChangesAsync();
        }
    }
}
