using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Pages { get; set; }
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}