
using System;

namespace BookApi.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? UserId { get; set; }
    }
}
