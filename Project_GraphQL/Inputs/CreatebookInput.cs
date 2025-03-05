using Domain.Entities.Models;

namespace Project_GraphQL.Inputs
{
    public class CreatebookInput
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public int AuthorId { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
