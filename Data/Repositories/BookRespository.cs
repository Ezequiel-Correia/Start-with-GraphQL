using Data.DataContext;
using Domain.Entities.Models;
using Domain.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BookRespository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRespository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.Include(b => b.Author).Include(b => b.Category).ToListAsync();
        }
        public async Task<Book> GetById(int id)
        {
            return await _context.Books.Include(b => b.Author).Include(b => b.Category).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateBook(int id,Book book)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
            {
                throw new Exception("Livro inexistente !");
            } 
            
            existingBook.Title = book.Title;
            existingBook.Pages = book.Pages;
            existingBook.AuthorId = book.AuthorId;
            existingBook.DateCreated = book.DateCreated;
            
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBook(int id)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
            {
                throw new Exception("Livro inexistente !");

            }
            _context.Books.Remove(existingBook);
            await _context.SaveChangesAsync();
        }
    }
}
