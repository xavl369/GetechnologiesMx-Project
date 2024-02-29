
using GetechnologiesMx.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GetechnologiesMx.Persistence.Repositories {
    public class BaseRepository<T> : IBaseRepository<T> where T : class {

        protected readonly GetechnologiesMxDbContext _context;

        public BaseRepository(GetechnologiesMxDbContext context){
            _context = context;
        }

        public async Task<T> AddAsync(T entity){

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity){

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(){
       
            return await _context.Set<T>().ToArrayAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id){

            T? t = await _context.Set<T>().FindAsync(id);
            return t;
        }

    }
}
