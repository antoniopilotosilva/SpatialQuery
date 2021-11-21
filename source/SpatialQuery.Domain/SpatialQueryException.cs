using System;
using System.Runtime.Serialization;

namespace SpatialQuery.Domain
{
	public class SpatialQueryException : Exception
	{
		public SpatialQueryException()
		{
		}

		public SpatialQueryException(string message)
			: base(message)
		{
		}

		public SpatialQueryException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected SpatialQueryException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
