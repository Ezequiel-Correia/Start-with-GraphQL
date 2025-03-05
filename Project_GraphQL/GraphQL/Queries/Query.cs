using Domain.Entities.Models;
using HotChocolate.Subscriptions;
using System.Reflection;
using Domain.Interfaces.Services;
using Domain.Services;
using Microsoft.AspNetCore.Http.HttpResults;
namespace Project_GraphQL.GraphQL.Queries
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
            var query =  await bookService.GetById(id);
            if(query == null)
            {
                 throw new Exception("A consulta não retornou dados");
            }
            return query;

        }
        [GraphQLName("allAuthors")]
        public Task<IEnumerable<Author>> GetAllAuthors([Service]
        IAuthorService authorService) => authorService.GetAll();
        [GraphQLName("getAuthorById")]
        public async Task<Author> GetAuthorById([Service] IAuthorService authorService, int id)
        {
            return await authorService.GetById(id);
        }
        [GraphQLName("allCategories")]
        public Task<IEnumerable<Category>> GetAllCategories([Service]
        ICategoryService categoryService) => categoryService.GetCategories();

        [GraphQLName("allCategoriesWithBooks")]
        public Task<IEnumerable<Category>> GetAllCategoriesWithBooks([Service]
        ICategoryService categoryService) => categoryService.GetCategoriesWithBooks();

        [GraphQLName("getCategoryById")]
        public async Task<Category> GetCategoryById([Service] ICategoryService categoryService, int id)
        {
            return await categoryService.GetCategoryById(id);
        }


    }
}
