using SpatialQuery.Domain.Measurements;

namespace SpatialQuery.Strategies.Distances
{
	public interface IDistance : IQueryResult
	{
		double Length { get; set; }

		LengthUnit Unit { get; set; }
	}
}
