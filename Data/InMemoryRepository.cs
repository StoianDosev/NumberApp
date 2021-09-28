using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Context;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class InMemoryRepository : IRepository
    {
        private readonly InMemoryDbContext _context;

        public InMemoryRepository(InMemoryDbContext context)
        {
            _context = context;
        }

        public async Task<Number> Create(Number number)
        {
            var entity = _context.Numbers.Add(number);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task Delete(int id)
        {
            var entity = _context.Numbers.Find(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAll()
        {
            _context.Numbers.RemoveRange(_context.Numbers);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Number>> GetAll()
        {
            return await _context.Numbers.ToListAsync();
        }

        public async Task<Number> Get(int id)
        {
            return await _context.Numbers.FindAsync(id);
        }
    }
}