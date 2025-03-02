using Domain.Entities.Models;

namespace Project_GraphQL.Inputs
{
    public class BookInput
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
