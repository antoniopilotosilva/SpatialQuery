namespace SpatialQuery.Domain.Shapes
{
	public interface IPoint : IShape
	{
		double CoordinateX { get; }
		double CoordinateY { get; }
	}
}
