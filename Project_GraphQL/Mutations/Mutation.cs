using Domain.Entities.Models;
using Domain.Interfaces.Services;
using Project_GraphQL.Inputs;

namespace Project_GraphQL.Mutations
{
    public class Mutation
    {

        public async Task<Author> AddAuthor(
           [Service] IAuthorService authorService, CreateAuthorInput input)
        {
            var author = new Author
            {
                Name = input.Name,
                Age = input.Age,
                Cpf = input.Cpf
            };
            await authorService.AddAuthor(author);
            return author;
        }
        public async Task<Book> AddBook(
          [Service] IBookService bookService, IAuthorService authorservice, CreatebookInput input)
        {
            var author = await authorservice.GetById(input.AuthorId);

            if (author == null)
            {
                throw new Exception("Autor não encontrado !");
            }
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



