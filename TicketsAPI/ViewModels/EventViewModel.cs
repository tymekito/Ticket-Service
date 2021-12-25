﻿
using System;
using System.Collections.Generic;

namespace TicketsAPI.Entities
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime EventDate { get; set; }
        public virtual List<TicketViewModel> Tickets { get; set; }
    }
}
