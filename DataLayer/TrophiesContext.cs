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
    public class TrophiesContext : IDb<Trophy, int>
    {
        private DBLibraryContext dbContext;

        public TrophiesContext(DBLibraryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Trophy item)
        {
            dbContext.Trophies.Add(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task <Trophy> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Trophy> query = dbContext.Trophies;

            if (useNavigationalProperties) query = query.Include(g => g.CountryCodeNavigation);

            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            Trophy trophy = query.FirstOrDefault(g => g.Id == key);

            if (trophy is null) throw new ArgumentException($"Trophy with id {key} does not exist!");

            return trophy;
        }

        public async Task <IEnumerable<Trophy>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Trophy> query = dbContext.Trophies;

            if (useNavigationalProperties) query = query.Include(g => g.CountryCodeNavigation);
            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public async Task UpdateAsync(Trophy item, bool useNavigationalProperties = false)
        {
            Trophy trophy = await ReadAsync(item.Id, useNavigationalProperties);
            if (trophy == null)
            {
                throw new ArgumentException("Trophy not found!");
            }

            dbContext.Entry(trophy).CurrentValues.SetValues(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int key)
        {
            Trophy trophyFromDb =await ReadAsync(key);
            dbContext.Trophies.Remove(trophyFromDb);
           await  dbContext.SaveChangesAsync();
        }
    }
}
