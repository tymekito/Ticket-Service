using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsAPI.Models
{
    public class ResponceAuth
    {
        public int UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
        public double Wallet { get; set; }
    }
}
