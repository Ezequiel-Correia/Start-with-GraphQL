using Domain.Entities.Models;
using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepostory;

        public BookService(IBookRepository bookRepostory)
        {
            _bookRepostory = bookRepostory;
        }
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookRepostory.GetAll();
        }
        public async Task<Book> GetById(int id)
        {
            return await _bookRepostory.GetById(id);
        }
        public async Task AddBook(Book book)
        {
            await _bookRepostory.AddBook(book);
        }
        public async Task UpdateBook(int id, Book book)
        {
            await _bookRepostory.UpdateBook(id, book);
        }
        public async Task DeleteBook(int id)
        {
            await _bookRepostory.DeleteBook(id);
        }
    }
}
