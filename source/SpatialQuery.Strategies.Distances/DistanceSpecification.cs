using SpatialQuery.Domain.Measurements;
using SpatialQuery.Domain.Shapes;

namespace SpatialQuery.Strategies.Distances
{
	public class DistanceSpecification : IDistanceSpecification
	{
		private Point _destination;
		private Point _origin;
		private LengthUnit _unit = LengthUnit.Unknown;

		private bool _hasDestination;
		private bool _hasOrigin;

		public IPoint Destination => _destination;

		public IPoint Origin => _origin;

		public string StrategyName { get; }

		public LengthUnit Unit => _unit;

		public static DistanceSpecification Create()
		{
			return new DistanceSpecification();
		}

		public DistanceSpecification From(Point origin)
		{
			_origin = origin;
			_hasOrigin = true;
			return this;
		}

		public DistanceSpecification InUnit(LengthUnit unit)
		{
			_unit = unit;
			return this;
		}

		public DistanceSpecification To(Point destination)
		{
			_destination = destination;
			_hasDestination = true;
			return this;
		}

		public void Validate()
		{
			if (!_hasOrigin || !_hasDestination)
			{
				throw new SpatialQueryStrategyException($"Missing parameter{ (!_hasOrigin && !_hasDestination ? "s" : "") } { (!_hasOrigin ? "Origin" : "") }{ (!_hasOrigin && !_hasDestination ? " and " : "") }{ (!_hasDestination ? "Destination" : "") }.");
			}
		}
	}
}
