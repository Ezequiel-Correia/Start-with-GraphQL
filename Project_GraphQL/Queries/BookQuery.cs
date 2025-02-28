using Domain.Entities.Models;
using System.Reflection;

namespace Project_GraphQL.Queries
{
    public class BookQuery
    {
        public Book GetBook() =>
            new Book
            {
                Title = "Teste Datlo",
                Author = new Author
                {
                    Name = "Ezequiel"
                }
            };

    }
}
