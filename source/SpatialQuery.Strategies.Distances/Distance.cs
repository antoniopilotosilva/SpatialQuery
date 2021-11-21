using SpatialQuery.Domain.Measurements;

namespace SpatialQuery.Strategies.Distances
{
	public struct Distance : IDistance
	{
		public Distance(double length, LengthUnit unit)
		{
			Length = length;
			Unit = unit;
		}

		public double Length { get; set; }

		public LengthUnit Unit { get; set; }

		public override string ToString() => $"Distance ({Length} {Unit})";
	}
}
