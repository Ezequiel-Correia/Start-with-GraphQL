using Domain.Entities.Models;
using HotChocolate.Subscriptions;
using System.Reflection;
using Domain.Interfaces.Services;
namespace Project_GraphQL.Queries
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class Query
    {
        [GraphQLName("allBooks")]
        public Task<IEnumerable<Book>> GetAllBooks([Service]
        IBookService bookService) => bookService.GetAll();

        [GraphQLName("getBookById")]
        public async Task<Book> GetBookById([Service] IBookService bookService, int id)
        {
            return await bookService.GetById(id);
        }
        [GraphQLName("allAuthors")]
        public Task<IEnumerable<Author>> GetAllAuthors([Service]
        IAuthorService authorService) => authorService.GetAll();
        [GraphQLName("getAuthorById")]
        public async Task<Author> GetAuthorById([Service] IAuthorService authorService, int id)
        {
            return await authorService.GetById(id);
        }

    }
}
