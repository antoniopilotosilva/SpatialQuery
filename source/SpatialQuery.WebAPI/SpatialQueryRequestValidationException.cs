using SpatialQuery.Domain;
using System;
using System.Runtime.Serialization;

namespace SpatialQuery.WebAPI
{
	public class SpatialQueryRequestValidationException : SpatialQueryException
	{
		public SpatialQueryRequestValidationException()
		{
		}

		public SpatialQueryRequestValidationException(string message)
			: base(message)
		{
		}

		public SpatialQueryRequestValidationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected SpatialQueryRequestValidationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
