using SpatialQuery.Domain.Measurements;

namespace SpatialQuery.Strategies.Distances
{
	public abstract class BaseDistanceStrategy : IStrategy<IDistance>
	{
		public abstract string StrategyName { get; }

		protected IDistanceSpecification _specification;

		protected abstract IDistance Calculate();

		public IDistance Run(IQuerySpecification<IDistance> specification)
		{
			specification.Validate();

			_specification = (IDistanceSpecification)specification;

			IDistance distance = Calculate();
			return distance;
		}

		protected double GetEarthRadius(LengthUnit unit)
		{
			switch (unit)
			{
				case LengthUnit.Kilometer:
					return 6378.139838271;
				case LengthUnit.Mile:
					return 3963.192355563;
				case LengthUnit.NauticalMile:
					return 3443.919999066;
				default:
					return -1;
			}
		}
	}
}
