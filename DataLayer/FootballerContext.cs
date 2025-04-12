
using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class FootballerContext : IDb<Footballer, int>
    {
        private DBLibraryContext dbContext;

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
                query = query.Include(g => g.Team)
                            .Include(g => g.CountryCodeNavigation);
            }

            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }

            Footballer footballer = query.FirstOrDefault(g => g.Id == key);

            if (footballer == null)
            {
                throw new ArgumentException($"Footballer with id {key} does not exist!");
            }

            return footballer;
        }

        public List<Footballer> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Footballer> query = dbContext.Footballers;

            if (useNavigationalProperties)
            {
                query = query.Include(g => g.Team)
                            .Include(g => g.CountryCodeNavigation);
            }

            if (isReadOnly)
            {
                query = query.AsNoTrackingWithIdentityResolution();
            }

            return query.ToList();
        }

        public void Update(Footballer item, bool useNavigationalProperties = false)
        {
            try
            {
                Footballer footballer = Read(item.Id, useNavigationalProperties);

                dbContext.Entry(footballer).CurrentValues.SetValues(item);
                dbContext.SaveChanges();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Footballer with id {item.Id} does not exist!");
            }
        }

        public void Delete(int key)
        {
            try
            {
                Footballer footballerFromDb = Read(key);

                dbContext.Footballers.Remove(footballerFromDb);
                dbContext.SaveChanges();
            }
            catch (ArgumentException)
            {
                throw new ArgumentException($"Footballer with id {key} does not exist!");
            }
        }
    }
}