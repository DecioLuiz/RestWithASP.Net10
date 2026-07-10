using FluentAssertions;
using RestWithASPNet10.Data.Converter.Impl;
using RestWithASPNet10.Data.DTO.V2;
using RestWithASPNet10.Model;

namespace RestWithASPNet10.Tests
{
    public class PersonConverterTests
    {
        private readonly PersonConverter _converter;
        public PersonConverterTests()
        {
            _converter = new PersonConverter();
        }
        // PersonDTO to Person conversion test

        [Fact]
        public void Parse_ShouldConvertPersonDTOToPerson()
        {
            // Arrange: prepare the data, objects and dependencies for the test
            var dto = new PersonDTO
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                Address = "123 Main St",
                BirthDate = new DateTime(1980, 1, 1)
            };

            var expectedPerson = new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                Address = "123 Main St",
                // BirthDate = new DateTime(1980, 1, 1)
            };

            // Act: call the method under test
            var person = _converter.Parse(dto);
            // Assert: verify the result matches the expected outcome
            person.Should().NotBeNull();
            person.Id.Should().Be(expectedPerson.Id);
            person.FirstName.Should().Be(expectedPerson.FirstName);
            person.LastName.Should().Be(expectedPerson.LastName);
            person.Gender.Should().Be(expectedPerson.Gender);
            person.Address.Should().Be(expectedPerson.Address);
            person.Should().BeEquivalentTo(expectedPerson);
        }
        [Fact]
        public void Parse_NullPersonDTO_ShouldReturnNull()
        {
            // Arrange
            PersonDTO dto = null;

            // Act
            var person = _converter.Parse(dto);

            // Assert
            person.Should().BeNull();
        }
        // Person to PersonDTO conversion test

        [Fact]
        public void Parse_ShouldConvertPersonToPersonDTO()
        {
            // Arrange: prepare the data, objects and dependencies for the test
            var entity = new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                Address = "123 Main St",
                // BirthDate = new DateTime(1980, 1, 1)
            };

            var expectedPerson = new PersonDTO
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                Address = "123 Main St",
                // BirthDate = new DateTime(1980, 1, 1)
            };

            // Act: call the method under test
            var person = _converter.Parse(entity);
            // Assert: verify the result matches the expected outcome
            person.Should().NotBeNull();
            person.Id.Should().Be(expectedPerson.Id);
            person.FirstName.Should().Be(expectedPerson.FirstName);
            person.LastName.Should().Be(expectedPerson.LastName);
            person.Gender.Should().Be(expectedPerson.Gender);
            person.Address.Should().Be(expectedPerson.Address);
            person.BirthDate.Should().NotBeNull();
            person.Should().BeEquivalentTo(expectedPerson, options => options.Excluding(x => x.BirthDate));
        }
        [Fact]
        public void Parse_NullPerson_ShouldReturnNull()
        {
            // Arrange
            Person entity = null;

            // Act
            var person = _converter.Parse(entity);

            // Assert
            person.Should().BeNull();
        }
        [Fact]
        public void ParseList_ShouldConvertListOfPersonDTOToListOfPerson()
        {
            // Arrange
            var dtos = new List<PersonDTO>
            {
                new PersonDTO
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Gender = "Male",
                    Address = "123 Main St",
                    BirthDate = new DateTime(1980, 1, 1)
                },
                new PersonDTO
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Gender = "Female",
                    Address = "456 Oak Ave",
                    BirthDate = new DateTime(1985, 5, 15)
                }
            };

            // Act
            var persons = _converter.ParseList(dtos);

            // Assert
            persons.Should().NotBeNull();
            persons.Count.Should().Be(2);
            persons[0].Should().BeEquivalentTo(new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                Address = "123 Main St",
                // BirthDate = new DateTime(1980, 1, 1)
            });
            persons[1].Should().BeEquivalentTo(new Person
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Gender = "Female",
                Address = "456 Oak Ave",
                // BirthDate = new DateTime(1985, 5, 15)
            });
            persons[0].FirstName.Should().Be("John");
            persons[1].FirstName.Should().Be("Jane");
            persons[0].LastName.Should().Be("Doe");
        }
        [Fact]
        public void ParseList_NullListPersonDTO_ShouldReturnNull()
        {
            // Arrange
            List<PersonDTO> dtos = null;
            // Act
            var persons = _converter.ParseList(dtos);
            // Assert
            persons.Should().BeNull();
        }
        [Fact]
        public void ParseList_ShouldConvertListOfPersonToListOfPersonDTO()
        {
            // Arrange
            var entities = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Gender = "Male",
                    Address = "123 Main St",
                    //BirthDate = new DateTime(1980, 1, 1)
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Gender = "Female",
                    Address = "456 Oak Ave",
                    // BirthDate = new DateTime(1985, 5, 15)
                }
            };

            // Act
            var dtos = _converter.ParseList(entities);
            //dtos[0].BirthDate = new DateTime(1980, 1, 1);
            //dtos[1].BirthDate = new DateTime(1985, 5, 15);

            // Assert
            dtos.Should().NotBeNull();
            dtos.Count.Should().Be(2);
            dtos[0].Should().BeEquivalentTo(new PersonDTO
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                Address = "123 Main St",
                BirthDate = new DateTime(1980, 1, 1)
            }, options => options.Excluding(x => x.BirthDate));
            dtos[1].Should().BeEquivalentTo(new PersonDTO
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Gender = "Female",
                Address = "456 Oak Ave",
                BirthDate = new DateTime(1985, 5, 15)
            }, options => options.Excluding(x => x.BirthDate));
            dtos[0].FirstName.Should().Be("John");
            dtos[1].FirstName.Should().Be("Jane");
            dtos[0].LastName.Should().Be("Doe");
            dtos[0].BirthDate.Should().NotBeNull();
            dtos[1].BirthDate.Should().NotBeNull();
        }
        [Fact]
        public void ParseList_NullListPerson_ShouldReturnNull()
        {
            // Arrange
            List<Person> entities = null;
            // Act
            var dtos = _converter.ParseList(entities);
            // Assert
            dtos.Should().BeNull();
        }
    }
}
