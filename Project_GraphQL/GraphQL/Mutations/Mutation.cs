using Domain.Entities.Models;
using Domain.Interfaces.Services;
using Project_GraphQL.GraphQL.Inputs;

namespace Project_GraphQL.GraphQL.Mutations
{
    public class Mutation
    {

        public async Task<Author> AddAuthor(
           [Service] IAuthorService authorService, CreateAuthorInput input)
        {
            var author = new Author
            {
                Name = input.Name,
                BirthDate = input.BirthDate,
                Cpf = input.Cpf
            };
            await authorService.AddAuthor(author);
            return author;
        }
        public async Task<Book> AddBook(
          [Service] IBookService bookService, IAuthorService authorservice, CreatebookInput input)
        {
            var book = new Book
            {
                Title = input.Title,
                Pages = input.Pages,
                AuthorId = input.AuthorId,
                DateCreated = input.DateCreated,
                CategoryId = input.CategoryId
                
            };

            await bookService.AddBook(book);
            return book; 
        }
        public async Task<Category> AddCategory(
            [Service] ICategoryService categoryService, CreateCategoryInput categoryInput)
        {
            var category = new Category
            {
                Description = categoryInput.Description,

            };
            await categoryService.AddCategory(category);
            return category;
        }
        
        public async Task<Author> UpdateAuthor([Service] IAuthorService authorService, int id, UpdateAuthorInput author)
        {
            var existingAuthor = await authorService.GetById(id);
            if (existingAuthor == null)
            {
                throw new Exception("Autor inexistente !");
            }

            existingAuthor.Name = author.Name ?? existingAuthor.Name;
            existingAuthor.BirthDate = author.BirthDate ?? existingAuthor.BirthDate;
            existingAuthor.Cpf = author.Cpf ?? existingAuthor.Cpf;

            await authorService.UpdateAuthor(id, existingAuthor);
            return existingAuthor;

        }
        public async Task<Category> UpdateCategory([Service] ICategoryService categoryService, int id, UpdateCategoryInput categoryInput)
        {
            var existingCategory = await categoryService.GetCategoryById(id);
            if(existingCategory == null)
            {
                throw new Exception("Categoria Inexistente !");

            }
            existingCategory.Description = categoryInput.Description ?? existingCategory.Description;
            await categoryService.UpdateCategory(id, existingCategory);
            return existingCategory;
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
        public async Task<bool> DeleteCategory([Service] ICategoryService categoryService, int id)
        {
            var category = categoryService.GetCategoryById(id);
            if(category == null)
            {
                throw new Exception("Categoria inexistente !");
            }
            await categoryService.DeleteCategory(id);
            return true;
        }
        public async Task<Book> UpdateBook([Service] IBookService bookService, int id, UpdateBookInput book)
        {
            var existingBook = await bookService.GetById(id);
            if (existingBook == null)
            {
                throw new Exception("Livro inexistente !");
            }
            existingBook.Title = book.Title ?? existingBook.Title; 
            existingBook.Pages = book.Pages ?? existingBook.Pages; 
            existingBook.AuthorId = book.AuthorId ?? existingBook.AuthorId; 
            existingBook.DateCreated = book.DateCreated ?? existingBook.DateCreated;
            existingBook.CategoryId = book.CategoryId ?? existingBook.CategoryId;
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



