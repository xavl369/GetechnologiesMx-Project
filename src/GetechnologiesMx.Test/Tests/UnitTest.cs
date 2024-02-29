using GetechnologiesMx.Test.Mocks;
using Moq;

namespace GetechnologiesMx.Test.Test {
    public class Tests
    {
        private Mock<IBaseRepository<Person>> _mockDirectotyRepository;

        [SetUp]
        public void Setup() {
            _mockDirectotyRepository = RepositoryMock.GetPersonRepository();
        }

        [Test]
        public async Task StorePersonTest()
        {

            //Arrange: setup test objects, initialize data
            var repository = _mockDirectotyRepository.Object;
            var person = RepositoryMock.GetTestPerson();

            //Act: call method, set property
            await repository.AddAsync(person);

            //Assert: compare returned values/end state with expected
            var persons = await repository.GetAllAsync();
            Assert.That(persons, Has.Exactly(6).Items);
        }
    }
}