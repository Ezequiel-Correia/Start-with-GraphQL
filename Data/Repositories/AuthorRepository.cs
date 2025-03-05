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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _context.Authors.Include(x => x.Books).ThenInclude(x => x.Category).ToListAsync();
        }
        public async Task<Author> GetById(int id)
        {
            return await _context.Authors.Include(x => x.Books).ThenInclude(x => x.Category).FirstOrDefaultAsync(x => x.AuthorId == id);
        }
        public async Task AddAuthor(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAuthor(int id, Author author)
        {
            var existingAuthor = await _context.Authors.FindAsync(id);
            if (existingAuthor == null)
            {
                throw new Exception("Autor inexistente !");
            }
            existingAuthor.Name = author.Name;
            existingAuthor.BirthDate = author.BirthDate;
            existingAuthor.Cpf = author.Cpf;

            await _context.SaveChangesAsync();

        }
        public async Task DeleteAuthor(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                throw new Exception("Autor inexistente !");

            }
             _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
