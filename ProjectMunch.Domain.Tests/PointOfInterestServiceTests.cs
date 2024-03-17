using FluentAssertions;
using NetTopologySuite.Geometries;
using NSubstitute;
using ProjectMunch.Models;
using Xunit.Abstractions;

namespace ProjectMunch.Domain.Tests
{
    public class PointOfInterestServiceTests(ITestOutputHelper output)
    {
        private readonly ITestOutputHelper _output = output;

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
        [MemberData(nameof(GetAllInDistanceFromCenterTestData))]
        public async Task GetAllInDistanceFromCenter_OnSuccess_ReturnsInstance(PointOfInterest center, int distance)
        {
            //Arrange
            var stubRepository = Substitute.For<IPointOfInterestRepository>();
            stubRepository.GetAllInDistanceFromCenter(center, distance).Returns([]);
            var sut = new PointOfInterestService(stubRepository);

            //Act
            var result = await sut.GetAllInDistanceFromCenter(center, distance);

            //Assert
            result.Should().NotBeNull();
        }

        public static TheoryData<PointOfInterest, int> GetAllInDistanceFromCenterTestData
        {
            get
            {
                var data = new TheoryData<PointOfInterest, int>();

                var poi = new PointOfInterest()
                {
                    Name = "Test",
                    Coordinate = new Point(1, 1)
                };
                var distance = 10;

                data.Add(poi, distance);

                return data;
            }
        }
    }
}