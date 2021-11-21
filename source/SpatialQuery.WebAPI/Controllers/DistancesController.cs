using SpatialQuery.Domain.Shapes;
using SpatialQuery.Strategies;
using SpatialQuery.Strategies.Distances;
using SpatialQuery.WebAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using SpatialQuery.Domain.Measurements;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System;

namespace SpatialQuery.WebAPI.Controllers
{
	[ApiController]
	[Route("SpatialQuery/[controller]")]
	public class DistancesController : ControllerBase
	{
		private readonly ILogger<DistancesController> _logger;

		private readonly IDistanceStrategyFactory _strategiesFactory;

		public DistancesController(
			ILogger<DistancesController> logger,
			IDistanceStrategyFactory strategiesFactory)
		{
			_logger = logger;
			_strategiesFactory = strategiesFactory;
		}

		[HttpGet("GeographicalBetweenTwoPoints")]
		public IDistance GeographicalBetweenTwoPoints(
			double originLatitude,
			double originLongitude,
			double destinationLatitude,
			double destinationLongitude,
			string approach,
			string outputUnit)
		{
			List<string> requestValidationErrors = new();

			if (string.IsNullOrWhiteSpace(approach))
			{
				requestValidationErrors.Add("Strategy name is null, empty or white space.");
			}

			LengthUnit unit = LengthUnit.Unknown;

			if (!string.IsNullOrWhiteSpace(outputUnit))
			{
				unit = outputUnit.ToLengthUnit();
				if (unit == LengthUnit.Unknown)
				{
					requestValidationErrors.Add($"Output unit {outputUnit} is unknown.");
				}
			}

			if (requestValidationErrors.Any())
			{
				throw new SpatialQueryRequestValidationException($"Request Distance.BetweenTwoPoints is not valid. { string.Join(", ", requestValidationErrors) }");
			}

			try
			{
				DistanceSpecification specification = DistanceSpecification
					.Create()
					.From(new Point(originLatitude, originLongitude))
					.To(new Point(destinationLatitude, destinationLongitude));

				if (unit != LengthUnit.Unknown)
				{
					specification.InUnit(unit);
				}

				IStrategy<IDistance> strategy = _strategiesFactory.CreateStrategy(approach);

				IDistance distance = strategy.Run(specification);

				return distance;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Request Distance.BetweenTwoPoints throwed an exception.");
				throw;
			}
		}

		[HttpGet("WalkingBetweenTwoPoints")]
		public IDistance WalkingBetweenTwoPoints(
			double originLatitude,
			double originLongitude,
			double destinationLatitude,
			double destinationLongitude,
			string approach,
			string outputUnit)
		{
			// NOTE: this method could be calling a third-party provider, like Google Maps, to provide
			// the walking distance between two points

			throw new NotImplementedException("WalkingBetweenTwoPoints is not implemented.");
		}
	}
}
