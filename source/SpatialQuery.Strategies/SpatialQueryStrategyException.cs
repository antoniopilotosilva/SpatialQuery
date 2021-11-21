using SpatialQuery.Domain;
using System;
using System.Runtime.Serialization;

namespace SpatialQuery.Strategies
{
	public class SpatialQueryStrategyException : SpatialQueryException
	{
		public SpatialQueryStrategyException()
		{
		}

		public SpatialQueryStrategyException(string message)
			: base(message)
		{
		}

		public SpatialQueryStrategyException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected SpatialQueryStrategyException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
