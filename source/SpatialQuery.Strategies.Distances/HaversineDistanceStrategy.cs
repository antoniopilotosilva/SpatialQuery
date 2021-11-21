using SpatialQuery.Domain.Measurements;
using System;

namespace SpatialQuery.Strategies.Distances
{
	/// <summary>
	/// Calculates the distance between two points accordingly to the Haversine method.
	/// Reference: http://www.movable-type.co.uk/scripts/latlong.html
	/// </summary>
	public class HaversineDistanceStrategy : BaseDistanceStrategy
	{
		public override string StrategyName => "Haversine";

		protected override IDistance Calculate()
		{
			// Default length unit is Kilometer
			LengthUnit unit = _specification.Unit != LengthUnit.Unknown ? _specification.Unit : LengthUnit.Kilometer;

			double earthRadius = GetEarthRadius(unit);

			double lat = ToRadians(_specification.Destination.CoordinateX - _specification.Origin.CoordinateX);
			double lng = ToRadians(_specification.Destination.CoordinateY - _specification.Origin.CoordinateY);

			double a =
				Math.Sin(lat / 2)
				* Math.Sin(lat / 2) 
				+ Math.Cos(ToRadians(_specification.Origin.CoordinateX)) 
				* Math.Cos(ToRadians(_specification.Destination.CoordinateX)) 
				* Math.Sin(lng / 2)
				* Math.Sin(lng / 2);

			double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

			double length = earthRadius * c;

			return new Distance
			{
				Length = length,
				Unit = unit
			};
		}

		private double ToRadians(double value)
		{
			return (Math.PI / 180) * value;
		}
	}
}
