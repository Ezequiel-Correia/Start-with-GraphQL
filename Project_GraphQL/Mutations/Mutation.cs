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
        public async Task<Author> UpdateAuthor([Service] IAuthorService authorService, int id, CreateAuthorInput author)
        {
            var existingAuthor = await authorService.GetById(id);
            if (existingAuthor == null)
            {
                throw new Exception("Autor inexistente !");
            }

            existingAuthor.Name = author.Name;
            existingAuthor.Age = author.Age;
            existingAuthor.Cpf = author.Cpf;

            await authorService.UpdateAuthor(id, existingAuthor);
            return existingAuthor;

        }
        public async Task<bool> DeleteAuthor([Service] IAuthorService authorService, int id)
        {
            var author = authorService.GetById(id);
            if(author == null)
            {
                throw new Exception("Autor inexistente !");
            }
            await authorService.DeleteAuthor(id);
            return true;
        }
        public async Task<Book> UpdateBook([Service] IBookService bookService, int id, CreatebookInput book)
        {
            var existingBook = await bookService.GetById(id);
            if (existingBook == null)
            {
                throw new Exception("Livro inexistente !");
            }
            existingBook.Title = book.Title;
            existingBook.Pages = book.Pages;
            existingBook.AuthorId = book.AuthorId;
            await bookService.UpdateBook(id, existingBook);
            return existingBook;

        }
        public async Task<bool> DeleteBook([Service] IBookService bookService, int id)
        {
            var book = bookService.GetById(id);
            if(book == null)
            {
                throw new Exception("Livro inexistente !");
            }
            await bookService.DeleteBook(id);
            return true;
        }
    }
}



