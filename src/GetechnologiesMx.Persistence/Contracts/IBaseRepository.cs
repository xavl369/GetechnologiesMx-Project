namespace GetechnologiesMx.Persistence.Contracts {

    public interface IBaseRepository<T> where T : class {
        Task<T?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
