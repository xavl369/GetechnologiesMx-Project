using GetechnologiesMx.Domain.Entities;
using GetechnologiesMx.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GetechnologiesMx.Persistence.Repositories {

    public class PersonRepository : BaseRepository<Person>, IPersonRepository {

        public PersonRepository(GetechnologiesMxDbContext context) : base(context) { }

        public async Task<Person?> GetPersonByIdentificationAsync(string identification) {

            var person = await _context.Persons
                                       .Include(x => x.Invoices)
                                       .FirstOrDefaultAsync(x => x.Identification == identification);
            return person;
        }
    }
}
