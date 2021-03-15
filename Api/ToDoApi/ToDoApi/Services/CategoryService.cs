using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApi.Data;
using ToDoApi.Data.Entities;
using ToDoApi.Infrasturcture.Exceptions;

namespace ToDoApi.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Categories>> GetCategories();
        Task<Categories> CreateCategory(Categories category);
        Task<Categories> GetCategoryById(int id);
        Task UpdateCategory(Categories category);
        Task RemoveCategory(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Categories> CreateCategory(Categories category)
        {
            bool check = await _context.Categories.AnyAsync(c => c.Name == category.Name);
            if (check) throw new HttpException(409, "Bu adda kateqoriya artıq mövcuddur.");
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Categories>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Categories> GetCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) throw new HttpException(404, "Kateqoriya tapılmadı");
            return category;
        }

        public async Task RemoveCategory(int id)
        {

            var category = await this.GetCategoryById(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(Categories category)
        {
            bool check = _context.Categories.Any(t => t.Name == category.Name);
            if (check) throw new HttpException(409, "Bu adda kateqoriya artıq mövcuddur");
            await _context.SaveChangesAsync();
        }

    }
}
