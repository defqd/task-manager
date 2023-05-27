﻿using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Contracts.Persistence;

namespace TaskManager.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TaskManagerDbContext _dbContext;

        public GenericRepository(TaskManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}