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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.GetCategories();
        }
        public async Task<IEnumerable<Category>> GetCategoriesWithBooks()
        {
            return await _categoryRepository.GetCategoriesWithBooks();
        }
        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }
        public async Task AddCategory(Category category)
        {
            await _categoryRepository.AddCategory(category);
        }
        public async Task UpdateCategory(int id, Category category)
        {
            await _categoryRepository.UpdateCategory(id, category);
        }
        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);
        }
    }
}
