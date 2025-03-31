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
    public class StadiumContext : IDb<Stadium, int>
    {
        private FootballteamsContext dbContext;

        public StadiumContext(FootballteamsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Stadium item)
        {
            dbContext.Stadiums.Add(item);
            dbContext.SaveChanges();
        }


        public Stadium Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Stadium> query = dbContext.Stadiums;

            if (useNavigationalProperties) query = query.Include(g => g.CountryCode);
            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            Stadium stadium = query.FirstOrDefault(g => g.Id == key);

            if (stadium is null) throw new ArgumentException($"Stadium with id {key} does not exist!");

            return stadium;
        }

        public List<Stadium> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Stadium> query = dbContext.Stadiums;

            if (useNavigationalProperties) query = query.Include(g => g.CountryCode);
            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public void Update(Stadium item, bool useNavigationalProperties = false)
        {
            Stadium stadium = Read(item.Id, useNavigationalProperties);
            if (stadium == null)
            {
                throw new ArgumentException("Stadium not found!");
            }

            dbContext.Entry(stadium).CurrentValues.SetValues(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Stadium stadiumFromDb = Read(key);
            dbContext.Stadiums.Remove(stadiumFromDb);
            dbContext.SaveChanges();
        }
    }
}
