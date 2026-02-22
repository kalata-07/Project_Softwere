using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class TeamsContext : IDb<Team, int>
    {
        private DBLibraryContext dbContext;

        public TeamsContext(DBLibraryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Team item)
        {
            dbContext.Teams.Add(item);
            await dbContext.SaveChangesAsync();
        }


        public async Task <Team> ReadAsync(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Team> query = dbContext.Teams;

            if (useNavigationalProperties) query = query.Include(g => g.CountryCodeNavigation);
            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            Team team = query.FirstOrDefault(g => g.Id == key);

            if (team is null) throw new ArgumentException($"Team with id {key} does not exist!");

            return team;
        }

        public async Task <IEnumerable<Team>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Team> query = dbContext.Teams;

            if (useNavigationalProperties) query = query.Include(g => g.CountryCodeNavigation);
            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public async Task UpdateAsync(Team item, bool useNavigationalProperties = false)
        {
            Team team = await ReadAsync(item.Id, useNavigationalProperties);
            if (team == null)
            {
                throw new ArgumentException("Team not found!");
            }

            dbContext.Entry(team).CurrentValues.SetValues(item);
           await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int key)
        {
            Team teamFromDb =await ReadAsync(key);
            dbContext.Teams.Remove(teamFromDb);
            await dbContext.SaveChangesAsync();
        }
    }
}
