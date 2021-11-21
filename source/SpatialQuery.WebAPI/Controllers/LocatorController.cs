using Microsoft.AspNetCore.Mvc;

namespace SpatialQuery.WebAPI.Controllers
{
	// NOTE: This controller is not implemented, it's purpose is to present the eventual
	// layout of the WebAPI regarding the several spatial queries.
	// This locator would be a query of features within specified distance of a given shape (usually
	// called buffers). It would include SQL queries to some repository, like a database, containing
	// the coordinates, category and other attributes of the features to locate.

	[Route("SpatialQuery/[controller]")]
	[ApiController]
	public class LocatorController : ControllerBase
	{
	}
}
