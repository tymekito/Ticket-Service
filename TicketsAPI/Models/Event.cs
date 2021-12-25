using System;
using System.Collections.Generic;

namespace TicketsAPI.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public DateTime EventDate { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
    }
}
