namespace SpatialQuery.Strategies
{
	public interface IQuerySpecification<T>
		where T : IQueryResult
	{
		string StrategyName { get; }

		void Validate();
	}
}
