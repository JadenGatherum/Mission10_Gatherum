using Api10.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;

namespace Api10.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private readonly IBowlerRepository _bowlerRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ILogger<BowlingController> _logger;

        public BowlingController(IBowlerRepository bowlerRepository, ITeamRepository teamRepository, ILogger<BowlingController> logger)
        {
            _bowlerRepository = bowlerRepository;
            _teamRepository = teamRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var joinedData = (from bowler in _bowlerRepository.Bowlers
                                  join team in _teamRepository.Teams
                                  on bowler.TeamId equals team.TeamId
                                  where team.TeamId == 1 || team.TeamId == 2
                                  select new
                                  {
                                      BowlerFirstName = bowler.BowlerFirstName,
                                      BowlerLastName = bowler.BowlerLastName,
                                      BowlerMiddleInit = bowler.BowlerMiddleInit,
                                      TeamName = team.TeamName,
                                      BowlerAddress = bowler.BowlerAddress,
                                      BowlerCity = bowler.BowlerCity,
                                      BowlerState = bowler.BowlerState,
                                      BowlerZip = bowler.BowlerZip,
                                      BowlerPhoneNumber = bowler.BowlerPhoneNumber
                                  }).ToArray();

                if (joinedData == null || !joinedData.Any())
                {
                    return NotFound("No data found.");
                }

                return Ok(joinedData);
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while retrieving data.");

                // Optionally, you can include additional details from the exception
                var errorMessage = $"An error occurred while processing the request: {ex.Message}";

                // Return a 500 Internal Server Error response with the error message
                return StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
            }
        }
    }
}