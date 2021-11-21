namespace SpatialQuery.Strategies
{
	public interface IStrategy<T>
		where T : IQueryResult
	{
		T Run(IQuerySpecification<T> specification);
	}
}
