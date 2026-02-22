using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StadiumContext : IDb<Stadium, int>
    {
        private DBLibraryContext dbContext;

        public StadiumContext(DBLibraryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Stadium item)
        {
            dbContext.Stadiums.Add(item);
            await dbContext.SaveChangesAsync();
        }


        public async Task<Stadium> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Stadium> query = dbContext.Stadiums;

            if (useNavigationalProperties) query = query.Include(g => g.CountryCodeNavigation);
            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            Stadium stadium = query.FirstOrDefault(g => g.Id == key);

            if (stadium is null) throw new ArgumentException($"Stadium with id {key} does not exist!");

            return stadium;
        }

        public async Task <IEnumerable<Stadium>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Stadium> query = dbContext.Stadiums;

            if (useNavigationalProperties) query = query.Include(g => g.CountryCodeNavigation);
            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public async Task UpdateAsync(Stadium item, bool useNavigationalProperties = false)
        {
            Stadium stadium = await ReadAsync(item.Id, useNavigationalProperties);
            if (stadium == null)
            {
                throw new ArgumentException("Stadium not found!");
            }

            dbContext.Entry(stadium).CurrentValues.SetValues(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int key)
        {
            Stadium stadiumFromDb = await ReadAsync(key);
            dbContext.Stadiums.Remove(stadiumFromDb);
            dbContext.SaveChanges();
        }
    }
}
