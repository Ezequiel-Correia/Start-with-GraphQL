﻿using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int id);
        Task AddBook(Book book);
        Task UpdateBook(int id,Book book);
        Task DeleteBook(int id);
    }
}
