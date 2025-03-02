using Domain.Entities.Models;
using Domain.Interfaces.Services;
using Project_GraphQL.Inputs;

namespace Project_GraphQL.Mutations
{
    public class Mutation
    {
        public async Task<Book> AddBook(
          [Service] IBookService bookService,BookInput input)
        {
            var book = new Book
            {
                Title = input.Title,
                Pages = input.Pages,
                AuthorId = input.AuthorId
            };

            await bookService.AddBook(book);
            return book; 
        }

    }
}



