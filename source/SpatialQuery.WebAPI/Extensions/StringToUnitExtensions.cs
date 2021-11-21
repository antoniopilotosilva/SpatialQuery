using SpatialQuery.Domain.Measurements;
using System;

namespace SpatialQuery.WebAPI.Extensions
{
	public static class StringToUnitExtensions
	{
		public static LengthUnit ToLengthUnit(this string value)
		{
			if (Enum.TryParse<LengthUnit>(value, true, out LengthUnit unit))
			{
				return unit;
			}
			else
			{
				return LengthUnit.Unknown;
			}
		}
	}
}
