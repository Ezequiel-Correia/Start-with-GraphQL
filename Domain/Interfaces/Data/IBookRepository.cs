using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Data
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
         Task<Book> GetById(int id);
        Task AddBook(Book book);

    }
}
