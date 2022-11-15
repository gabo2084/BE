using System;
using BE.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace BE.Infra.Interfaces
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly BEContext _context;

        protected DbSet<T> EntitySet
        {
            get
            {
                return _context.Set<T>();
            }
        }

        public RepositoryAsync(BEContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await EntitySet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await EntitySet.FindAsync(id);
        }

        public async Task<T> Insert(T entity)
        {
            EntitySet.Add(entity);

            await Save();

            return entity;
        }

        public async Task<T> Delete(int id)
        {
            T entity = await EntitySet.FindAsync(id);

            EntitySet.Remove(entity);

            await Save();

            return entity;
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}