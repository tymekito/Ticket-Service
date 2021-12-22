
using System;

namespace TicketsAPI.Entities
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
