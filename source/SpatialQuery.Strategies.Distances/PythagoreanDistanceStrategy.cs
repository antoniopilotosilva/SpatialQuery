using SpatialQuery.Domain.Measurements;
using System;

namespace SpatialQuery.Strategies.Distances
{
	/// <summary>
	/// Calculates the distance between two points accordingly to the Pythagoreran Theorem method.
	/// Reference: http://www.movable-type.co.uk/scripts/latlong.html
	/// </summary>
	public class PythagoreanDistanceStrategy : BaseDistanceStrategy
	{
		public override string StrategyName => "PythagoreranTheorem";

		protected override IDistance Calculate()
		{
			// Default length unit is Kilometer
			LengthUnit unit = _specification.Unit != LengthUnit.Unknown ? _specification.Unit : LengthUnit.Kilometer;

			double earthRadius = GetEarthRadius(unit);

			double x = (_specification.Destination.CoordinateY - _specification.Origin.CoordinateY)
				* Math.Cos((_specification.Destination.CoordinateX + _specification.Origin.CoordinateX) / 2);

			double y = _specification.Destination.CoordinateX - _specification.Origin.CoordinateX;

			double z = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

			double length = earthRadius * z;

			return new Distance
			{
				Length = length,
				Unit = unit
			};
		}
	}
}
