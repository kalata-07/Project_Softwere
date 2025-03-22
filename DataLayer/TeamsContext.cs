using DataLayer.BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TeamsContext : IDb<Team, int>
    {
        private FootballteamsContext dbContext;

        public TeamsContext(FootballteamsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Team item)
        {
            dbContext.Teams.Add(item);
            dbContext.SaveChanges();
        }


        public Team Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Team> query = dbContext.Teams;

            if (useNavigationalProperties) query = query.Include(g => g.CountryCode);
            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            Team team = query.FirstOrDefault(g => g.Id == key);

            if (team is null) throw new ArgumentException($"Team with id {key} does not exist!");

            return team;
        }

        public List<Team> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Team> query = dbContext.Teams;

            if (useNavigationalProperties) query = query.Include(g => g.CountryCode);
            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public void Update(Team item, bool useNavigationalProperties = false)
        {
            Team team = Read(item.Id, useNavigationalProperties);
            if (team == null)
            {
                throw new ArgumentException("Team not found!");
            }

            dbContext.Entry(team).CurrentValues.SetValues(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Team teamFromDb = Read(key);
            dbContext.Teams.Remove(teamFromDb);
            dbContext.SaveChanges();
        }
    }
}
