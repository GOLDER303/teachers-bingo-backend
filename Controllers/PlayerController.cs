using Microsoft.AspNetCore.Mvc;
using TeachersBingoApi.Dtos;
using TeachersBingoApi.Services.Interfaces;

namespace TeachersBingoApi.Controllers;

[Route("api/player/")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _playerService;

    public PlayerController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet("{playerName}/info")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<PlayerInfoResponseDTO> GetPlayerInfo(string playerName)
    {
        var player = _playerService.GetPlayerByName(playerName);

        PlayerInfoResponseDTO playerInfoResponseDTO =
            new()
            {
                PlayerName = player.Name,
                CurrentBingoId = player.CurrentBingoGame?.Id,
                CurrentPhrases = player.CurrentBingoPhrasesStrings,
                CurrentChoices = player.CurrentBingoChoices
            };

        return playerInfoResponseDTO;
    }
}
