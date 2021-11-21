using SpatialQuery.Domain.Measurements;
using SpatialQuery.Domain.Shapes;

namespace SpatialQuery.Strategies.Distances
{
	public interface IDistanceSpecification : IQuerySpecification<IDistance>
	{
		IPoint Destination { get; }

		IPoint Origin { get; }

		LengthUnit Unit { get; }
	}
}
