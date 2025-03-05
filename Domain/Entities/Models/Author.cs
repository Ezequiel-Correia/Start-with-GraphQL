using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
   public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public string? Cpf { get; set;}
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
