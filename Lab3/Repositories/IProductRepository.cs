﻿using Lab3.Models;

namespace Lab3.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<int> CountBooksByCategoryAsync(int categoryId);

        //Task<Product> GetByNameAsync(string productName);
    }
}
