
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
                    //var user = GetUser();
                    //dbContext.Users.Add(user);
                    //dbContext.SaveChanges();
                    //var events = GetEvents();
                    //dbContext.Events.AddRange(events);
                    //dbContext.SaveChanges();
                }
            }
        }
        private User GetUser()
        {
            var user = new User()
            {
                Name = "Jan",
                LastName = "Kapela",
                EMail = "jankapel@mail.pl"

            };
            return user;
        }
        private IEnumerable<Event> GetEvents()
        {

            var tickets = new List<Event>()
            {
                new Event()
                {
                    Name="Pyrkon",
                    Category="Fantasy",
                    Description="Pyrkon Fantasy Festival - a nationwide festival whose theme revolves around broadly understood fantasy, held every year in Poznan",
                    Tickets = new List<Ticket>()
                    {
                        new Ticket()
                        {
                            Name = "Bilet na Pyrkon",
                            Category = "Basic",
                            UserId = 1
                        }
                    }
                }
            };
            return tickets;
        }
    }
}
