using BuisnessLayer;
using DataLayer.BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal class FootballerContext : IDb<Footballer, int>
    {
        private FootballteamsContext dbContext;

        public FootballerContext(FootballteamsContext dbContext)
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

            if (useNavigationalProperties) query = query.Include(g => g.Team);
            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            Footballer footballer = query.FirstOrDefault(g => g.Id == key);

            if (footballer is null) throw new ArgumentException($"Footballer with id {key} does not exist!");

            return footballer;
        }

        public List<Footballer> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Footballer> query = dbContext.Footballers;

            if (useNavigationalProperties) query = query.Include(g => g.Team);
            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public void Update(Footballer item, bool useNavigationalProperties = false)
        {
            Footballer footballer = Read(item.Id, useNavigationalProperties);
            if (footballer == null)
            {
                throw new ArgumentException("Footballer not found!");
            }

            dbContext.Entry(footballer).CurrentValues.SetValues(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Footballer footballerFromDb = Read(key);
            dbContext.Footballers.Remove(footballerFromDb);
            dbContext.SaveChanges();
        }
    }
}
