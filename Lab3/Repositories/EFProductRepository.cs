﻿using Lab3.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab3.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public EFProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            // return await _context.Products.ToListAsync();
            return await _context.Products
            .Include(p => p.Category) // Include thông tin về category
            .ToListAsync();
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            // return await _context.Products.FindAsync(id);
            // lấy thông tin kèm theo category
            return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountBooksByCategoryAsync(int categoryId)
        {
            // Sử dụng LINQ để đếm số lượng sách có categoryId tương ứng
            return await _context.Products.CountAsync(b => b.CategoryId == categoryId);
        }
        //public async Task<Product> GetByNameAsync(string productName)
        //{
        //    // return await _context.Products.FindAsync(id);
        //    // lấy thông tin kèm theo category
        //    return await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Name.Contains(productName));
        //}
    }
}
