using GetechnologiesMx.Domain.Entities;

namespace GetechnologiesMx.Persistence.Contracts {
    public interface IPersonRepository : IBaseRepository<Person> {
        public Task<Person?> GetPersonByIdentificationAsync(string identification);
    }   
}
