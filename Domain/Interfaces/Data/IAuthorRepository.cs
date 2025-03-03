using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Data
{
   public  interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author> GetById(int id);
        Task AddAuthor(Author author);
        Task UpdateAuthor (int id, Author author);
        Task DeleteAuthor (int id);

    }
}
