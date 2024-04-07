using FluentAssertions;
using NSubstitute;
using ProjectMunch.Models;

namespace ProjectMunch.Domain.Tests
{
    public class PointOfInterestServiceTests
    {
        [Fact]
        public void Create_NullRepository_ThrowsException()
        {
            //Arrange
            IPointOfInterestRepository? repository = null;

            //Act
            void action()
            {
                _ = new PointOfInterestService(repository);
            }

            //Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetAll_OnSuccess_ReturnsInstance()
        {
            //Arrange
            var stubRepository = Substitute.For<IPointOfInterestRepository>();
            stubRepository.GetAll().Returns([]);
            var sut = new PointOfInterestService(stubRepository);

            //Act
            var result = await sut.GetAll();

            //Assert
            result.Should().NotBeNull();
        }

        [Theory]
        [InlineData(1)]
        public async Task Get_InvalidKey_ReturnsNull(int id)
        {
            //Arrange
            var stubRepository = Substitute.For<IPointOfInterestRepository>();
            stubRepository.Get(id).Returns(Task.FromResult<PointOfInterest?>(null));
            var sut = new PointOfInterestService(stubRepository);

            //Act
            var result = await sut.GetById(id);

            //Assert
            result.Should().BeNull();
        }

        [Theory]
        [InlineData(1)]
        public async Task Get_ValidKey_ReturnsInstance(int id)
        {
            //Arrange
            var stubRepository = Substitute.For<IPointOfInterestRepository>();
            var stubPointOfInterest = Substitute.For<PointOfInterest>();
            stubRepository.Get(id).Returns(stubPointOfInterest);
            var sut = new PointOfInterestService(stubRepository);

            //Act
            var result = await sut.GetById(id);

            //Assert
            result.Should().NotBeNull();
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 2)]
        [InlineData(3, 3, 3)]
        public async Task GetByDistanceFromCenter_OnSuccess_ReturnsInstance(
            short longitude,
            short latitude,
            int distance
        )
        {
            //Arrange
            var stubRepository = Substitute.For<IPointOfInterestRepository>();
            stubRepository.GetByDistanceFromCenter(default!, default).ReturnsForAnyArgs([]);
            var sut = new PointOfInterestService(stubRepository);

            //Act
            var result = await sut.GetByDistanceFromCenter(longitude, latitude, distance);

            //Assert
            result.Should().NotBeNull();
        }

        [Theory]
        [InlineData(1, 1, "name1", "description1")]
        [InlineData(2, 2, "name2", null)]
        [InlineData(3, 3, "name3", "")]
        public async Task Add_OnSuccess_ReturnsTrue(
            short longitude,
            short latitude,
            string name,
            string? description
        )
        {
            //Arrange
            var stubRepository = Substitute.For<IPointOfInterestRepository>();
            stubRepository.Find(default!).ReturnsForAnyArgs([]);
            stubRepository.Add(default!).ReturnsForAnyArgs(true);
            var sut = new PointOfInterestService(stubRepository);

            //Act
            var result = await sut.Add(longitude, latitude, name, description);

            //Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(1, 1, "name1", "description1")]
        [InlineData(2, 2, "name2", null)]
        [InlineData(3, 3, "name3", "")]
        public async Task Add_OnConflict_ReturnsFalse(
            short longitude,
            short latitude,
            string name,
            string? description
        )
        {
            //Arrange
            var stubPoi = new PointOfInterest()
            {
                Coordinate = new(longitude, latitude),
                Name = name,
            };
            var stubRepository = Substitute.For<IPointOfInterestRepository>();
            stubRepository.Find(default!).ReturnsForAnyArgs([stubPoi]);
            var sut = new PointOfInterestService(stubRepository);

            //Act
            var result = await sut.Add(longitude, latitude, name, description);

            //Assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData(1, 1, "name1", "description1")]
        [InlineData(2, 2, "name2", null)]
        [InlineData(3, 3, "name3", "")]
        public async Task Add_OnFailure_ReturnsFalse(
            short longitude,
            short latitude,
            string name,
            string? description
        )
        {
            //Arrange
            var stubRepository = Substitute.For<IPointOfInterestRepository>();
            stubRepository.Find(default!).ReturnsForAnyArgs([]);
            stubRepository.Add(default!).ReturnsForAnyArgs(false);
            var sut = new PointOfInterestService(stubRepository);

            //Act
            var result = await sut.Add(longitude, latitude, name, description);

            //Assert
            result.Should().BeFalse();
        }
    }
}
