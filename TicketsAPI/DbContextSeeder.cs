
using System.Collections.Generic;
using System.Linq;
using TicketsAPI.Entities;

namespace TicketsAPI
{
    public class DbContextSeeder
    {
        private readonly AppDbContext dbContext;
        public DbContextSeeder(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Seed()
        {
            if(this.dbContext.Database.CanConnect())
            {
                if(!this.dbContext.Tickets.Any())
                {
                    //Seed initial data
                    //var user = GetUser();
                    //dbContext.Users.Add(user);
                    //dbContext.SaveChanges();
                    //var events = GetEvents();
                    //dbContext.Events.AddRange(events);
                    //dbContext.SaveChanges();
                }
            }
        }
    }
}
