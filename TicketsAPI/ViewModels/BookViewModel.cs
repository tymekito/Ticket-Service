
using System;

namespace BookApi.Entities
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime? ExpirationDate { get; set; }

    }
}
