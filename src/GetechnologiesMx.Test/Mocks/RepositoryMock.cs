using Azure.Identity;
using Moq;

namespace GetechnologiesMx.Test.Mocks {

    public class RepositoryMock {

        public static Mock<IBaseRepository<Person>> GetPersonRepository() {

            var persons = Enumerable.Range(1, 5).Select(i => new Person {
                Id = Guid.Parse($"B0788D2F-8003-43C1-92A4-EDC76A7C5DD{i}"),
                Name = $"Name {i}",
                LastName = $"LastName {i}",
                MaternalSurname = $"MaternalSurname {i}",
                Identification = $"Identification {i}"
            }).ToList();


            var mockCategoryRepository = new Mock<IBaseRepository<Person>>();
            mockCategoryRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(persons);
            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny < Person>())).ReturnsAsync(
                (Person person) =>
                {
                    persons.Add(person);
                    return person;
                });

            return mockCategoryRepository;
        }

        public static Person GetTestPerson() => new() {
            Name = $"Test Name",
            LastName = $"Test LastName",
            MaternalSurname = $"Test MaternalSurname",
            Identification = $"Test Identification"
        };
     

    }
}
