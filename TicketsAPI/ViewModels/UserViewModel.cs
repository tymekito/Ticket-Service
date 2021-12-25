
using System.Collections.Generic;

namespace TicketsAPI.Entities
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public double Wallet { get; set; }
        public virtual List<Ticket> Tickets { get; set; }

    }
}
