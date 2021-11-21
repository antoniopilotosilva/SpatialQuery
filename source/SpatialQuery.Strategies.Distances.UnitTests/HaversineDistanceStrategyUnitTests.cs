using SpatialQuery.Domain.Measurements;
using SpatialQuery.Domain.Shapes;
using Xunit;

namespace SpatialQuery.Strategies.Distances.UnitTests
{
	public class HaversineDistanceStrategyUnitTests
	{
		[Fact]
		public void HappyPathWorks()
		{
			// Arrange
			HaversineDistanceStrategy sut = new();
			Point origin = new(40.7486, -73.9864);
			Point destination = new(24.7486, -72.9864);
			DistanceSpecification distanceSpecification = DistanceSpecification
				.Create()
				.From(origin)
				.To(destination)
				.InUnit(LengthUnit.Kilometer);

			// Act
			IDistance actual = sut.Run(distanceSpecification);

			// Assert
			Assert.Equal(1783.5357397059595, actual.Length);
			Assert.Equal(LengthUnit.Kilometer, actual.Unit);
		}

		[Fact]
		public void DefaultLengthUnitIsKilometer()
		{
			// Arrange
			HaversineDistanceStrategy sut = new();
			Point origin = new(40.7486, -73.9864);
			Point destination = new(24.7486, -72.9864);
			DistanceSpecification distanceSpecification = DistanceSpecification
				.Create()
				.From(origin)
				.To(destination);

			// Act
			IDistance actual = sut.Run(distanceSpecification);

			// Assert
			Assert.Equal(1783.5357397059595, actual.Length);
			Assert.Equal(LengthUnit.Kilometer, actual.Unit);
		}
	}
}
