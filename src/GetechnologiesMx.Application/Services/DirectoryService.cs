using Azure.Core;
using GetechnologiesMx.Application.Contracts;
using GetechnologiesMx.Application.Exceptions;
using GetechnologiesMx.Domain.Entities;
using GetechnologiesMx.Persistence.Contracts;

namespace GetechnologiesMx.Application.Services {
    public class DirectoryService : IDirectoryService {

        private readonly IPersonRepository _repository;

        public DirectoryService(IPersonRepository repository) {
            _repository = repository;
        }

        public async Task<Person?> GetPersonByIdentificationAsync(string identification) {
            return await _repository.GetPersonByIdentificationAsync(identification);
          
        }

        public async Task<Person[]> FindPersonsAsync() {
            var result = await _repository.GetAllAsync();
            return result.ToArray();
        }

        public async Task<bool> DeletePersonByIdentificationAsync(string identification) {
            var person = await GetPersonByIdentificationAsync(identification) 
                ?? throw new NotFoundException(nameof(Person), identification);

            await _repository.DeleteAsync(person);

            return true;
        }

        public async Task<Person> StorePerson(Person person) {
            person = await _repository.AddAsync(person);
            return person;
        }
    }
}
