using System;
using System.Collections.Generic;

namespace SpatialQuery.Strategies.Distances
{
	public class DistanceStrategyFactory : IDistanceStrategyFactory
	{
		private readonly Dictionary<string, Func<IStrategy<IDistance>>> _templates;

		public DistanceStrategyFactory()
		{
			_templates = new Dictionary<string, Func<IStrategy<IDistance>>>();

			InitializeStrategies();
		}

		public IStrategy<IDistance> CreateStrategy(string strategyName)
		{
			if (!_templates.ContainsKey(strategyName.ToLower()))
			{
				throw new SpatialQueryStrategyException($"Strategy {strategyName} is not registered.");
			}

			return _templates[strategyName.ToLower()]();
		}

		/// <summary>
		/// Registers the builder for a <see cref="IStrategy<IDistance>"/>.
		/// </summary>
		public void RegisterStrategy(string strategyName, Func<IStrategy<IDistance>> builder)
		{
			_templates.Add(strategyName.ToLower(), builder);
		}

		private void InitializeStrategies()
		{
			_templates.Add("haversine", () => new HaversineDistanceStrategy());
			_templates.Add("pythagorerantheorem", () => new HaversineDistanceStrategy());
			
			// NOTE: Register more strategies
		}
	}
}
