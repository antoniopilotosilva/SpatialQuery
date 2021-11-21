using SpatialQuery.Domain.Shapes;
using SpatialQuery.Strategies;
using SpatialQuery.Strategies.Distances;
using Xunit;

namespace SpatialQuery.UnitTests
{
	public class BaseDistanceStrategyUnitTests
	{
		[Fact]
		public void MissingDestinationThrowsException()
		{
			// Arrange
			// Using HaversineDistanceStrategy as BaseDistanceStrategy is abstract.
			HaversineDistanceStrategy sut = new();
			Point origin = new();
			DistanceSpecification distanceSpecification = DistanceSpecification
				.Create()
				.From(origin);

			// Act
			SpatialQueryStrategyException actual =
				Assert.Throws<SpatialQueryStrategyException>(() => sut.Run(distanceSpecification));

			// Assert
			Assert.Equal("Missing parameter Destination.", actual.Message);
		}

		[Fact]
		public void MissingDestinationAndOriginThrowsException()
		{
			// Arrange
			// Using HaversineDistanceMeasurer as BaseDistanceMeasurer is abstract.
			HaversineDistanceStrategy sut = new();
			DistanceSpecification distanceSpecification = DistanceSpecification
				.Create();

			// Act
			SpatialQueryStrategyException actual =
				Assert.Throws<SpatialQueryStrategyException>(() => sut.Run(distanceSpecification));

			// Assert
			Assert.Equal("Missing parameters Origin and Destination.", actual.Message);
		}

		[Fact]
		public void MissingOriginThrowsException()
		{
			// Arrange
			// Using HaversineDistanceMeasurer as BaseDistanceMeasurer is abstract.
			HaversineDistanceStrategy sut = new();
			Point destination = new();
			DistanceSpecification distanceSpecification = DistanceSpecification
				.Create()
				.To(destination);

			// Act
			SpatialQueryStrategyException actual =
				Assert.Throws<SpatialQueryStrategyException>(() => sut.Run(distanceSpecification));

			// Assert
			Assert.Equal("Missing parameter Origin.", actual.Message);
		}
	}
}
