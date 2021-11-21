using System;

namespace SpatialQuery.Strategies.Distances
{
	public interface IDistanceStrategyFactory
	{
		IStrategy<IDistance> CreateStrategy(string strategyName);

		/// <summary>
		/// Registers the builder for a <see cref="IStrategy<IDistance>"/>.
		/// </summary>
		void RegisterStrategy(string strategyName, Func<IStrategy<IDistance>> builder);
	}
}
