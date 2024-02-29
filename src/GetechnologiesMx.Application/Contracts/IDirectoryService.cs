
using GetechnologiesMx.Domain.Entities;

namespace GetechnologiesMx.Application.Contracts {
    public interface IDirectoryService {

        public Task<Person?> GetPersonByIdentificationAsync(string identification);
        public Task<Person[]> FindPersonsAsync();
        public Task<bool> DeletePersonByIdentificationAsync(string identification);
        public Task<Person> StorePerson(Person person);
       
    }
}
