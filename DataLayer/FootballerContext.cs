using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class FootballerContext : IDb<Footballer, int>
    {
        private readonly DBLibraryContext dbContext;

        public FootballerContext(DBLibraryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Footballer item)
        {
            dbContext.Footballers.Add(item);
            dbContext.SaveChanges();
        }
        

        public Footballer Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Footballer> query = dbContext.Footballers;

            if (useNavigationalProperties)
            {
                query = query
                    .Include(f => f.Team)
                    .Include(f => f.CountryCodeNavigation)
                    .Include(f => f.Footballerstrophies)
                        .ThenInclude(ft => ft.Trophy);
            }

            if (isReadOnly)
                query = query.AsNoTracking();

            Footballer footballer = query.FirstOrDefault(f => f.Id == key);
            if (footballer == null)
                throw new KeyNotFoundException("Footballer not found");


            return query.FirstOrDefault(f => f.Id == key);
        }

        public List<Footballer> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Footballer> query = dbContext.Footballers;

            if (useNavigationalProperties)
            {
                query = query
                    .Include(f => f.Team)
                    .Include(f => f.CountryCodeNavigation)
                    .Include(f => f.Footballerstrophies)
                        .ThenInclude(ft => ft.Trophy);
            }

            if (isReadOnly)
                if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

       
        public void Update(Footballer item, bool useNavigationalProperties = false)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Footballer existing = dbContext.Footballers
                .Include(f => f.Footballerstrophies)
                .FirstOrDefault(f => f.Id == item.Id);

            if (existing == null)
                throw new KeyNotFoundException("Footballer not found");

            dbContext.Entry(existing).CurrentValues.SetValues(item);

            if (useNavigationalProperties)
            {
                dbContext.Entry(existing).Collection(f => f.Footballerstrophies).Load();
                existing.Footballerstrophies = item.Footballerstrophies;
            }

            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Footballer footballersFromDb = Read(key);
            dbContext.Footballers.Remove(footballersFromDb);
            dbContext.SaveChanges();
        }
    }
}