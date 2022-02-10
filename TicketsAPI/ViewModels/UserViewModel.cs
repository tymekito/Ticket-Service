
using System.Collections.Generic;

namespace BookApi.Entities
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public virtual List<Book> Books { get; set; }

    }
}
