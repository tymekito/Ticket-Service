
namespace TicketsAPI.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }    
    }
}
