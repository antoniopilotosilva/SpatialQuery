namespace SpatialQuery.Domain.Shapes
{
	public interface IShape
	{
		double Area { get; }

		IPoint Center { get; }

		double Length { get; }
	}
}
