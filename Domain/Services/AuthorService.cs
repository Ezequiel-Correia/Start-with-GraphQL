using Domain.Entities.Models;
using Domain.Interfaces.Data;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authorRepository.GetAll();
        }
        public async Task<Author> GetById(int id)
        {
            return await _authorRepository.GetById(id);
        }
        public async Task AddAuthor(Author author)
        {
            await _authorRepository.AddAuthor(author);
        }
    }
}
