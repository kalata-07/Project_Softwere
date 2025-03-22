using DataLayer.BusinessLayer;
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
        private FootballteamsContext dbContext;

        public TrophiesContext(FootballteamsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Trophy item)
        {
            dbContext.Trophies.Add(item);
            dbContext.SaveChanges();
        }

        public Trophy Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Trophy> query = dbContext.Trophies;

            if (useNavigationalProperties) query = query.Include(g => g.CountryCode).Include(g => g.ContinentCode);

            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            Trophy trophy = query.FirstOrDefault(g => g.Id == key);

            if (trophy is null) throw new ArgumentException($"Trophy with id {key} does not exist!");

            return trophy;
        }

        public List<Trophy> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Trophy> query = dbContext.Trophies;

            if (useNavigationalProperties) query = query.Include(g => g.CountryCode).Include(g => g.ContinentCode);
            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public void Update(Trophy item, bool useNavigationalProperties = false)
        {
            Trophy trophy = Read(item.Id, useNavigationalProperties);
            if (trophy == null)
            {
                throw new ArgumentException("Trophy not found!");
            }

            dbContext.Entry(trophy).CurrentValues.SetValues(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Trophy trophyFromDb = Read(key);
            dbContext.Trophies.Remove(trophyFromDb);
            dbContext.SaveChanges();
        }
    }
}
