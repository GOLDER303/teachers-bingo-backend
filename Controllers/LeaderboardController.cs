using Microsoft.AspNetCore.Mvc;
using TeachersBingoApi.Dtos;
using TeachersBingoApi.Services.Interfaces;

namespace TeachersBingoApi.Controllers;

[Route("api/leaderboard/")]
[ApiController]
public class LeaderboardController : ControllerBase
{
    private readonly ILeaderboardService _leaderboardService;

    public LeaderboardController(ILeaderboardService leaderboardService)
    {
        _leaderboardService = leaderboardService;
    }

    [HttpGet("general")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<GeneralLeaderboardDTO> GetGeneralLeaderboard()
    {
        var generalLeaderboardDTO = _leaderboardService.GetGeneralLeaderboard();
        return Ok(generalLeaderboardDTO);
    }
}
