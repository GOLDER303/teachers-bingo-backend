using Microsoft.AspNetCore.Mvc;
using TeachersBingoApi.Dots;
using TeachersBingoApi.Dtos;
using TeachersBingoApi.Services.Interfaces;
using TeachersBingoApi.Models;

namespace TeachersBingoApi.Controllers;

[Route("api/bingo/")]
[ApiController]
public class BingoController : ControllerBase
{
    private readonly IBingoService _bingoService;
    private readonly IPlayerService _playerService;

    public BingoController(IBingoService bingoService, IPlayerService playerService)
    {
        _bingoService = bingoService;
        _playerService = playerService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult GetCurrentBingo()
    {
        var currentBingo = _bingoService.GetCurrentBingo();

        if (currentBingo == null)
        {
            //TODO: add a proper DTO
            return Ok("No bingo currently active");
        }

        var phrases = currentBingo.Bingo.Phrases.Select(p => new PhraseDTO(p.Content)).ToList();
        var bingoDTO = new BingoDTO(currentBingo.Bingo.Id, currentBingo.Bingo.Name, phrases);

        return Ok(bingoDTO);
    }

    [HttpPost("join")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult JoinCurrentBingoGame([FromBody] JoinCurrentBingoDTO joinCurrentBingoDTO)
    {
        var playerName = joinCurrentBingoDTO.PlayerName;

        var doesPlayerExist = _playerService.DoesPlayerExistByName(playerName);

        if (!doesPlayerExist)
        {
            _playerService.CreatePlayer(playerName);
        }

        int currentBingoGameId = _playerService.AddPlayerToCurrentBingoGame(playerName);

        return Ok(currentBingoGameId);
    }

    [HttpPost("{bingoGameId:int}/choice")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<PlayerChoiceResponseDTO> MakeAChoice(int bingoGameId, [FromBody] ChoiceDTO choiceDTO)
    {
        string playerName = choiceDTO.PlayerName;

        _playerService.TogglePlayerChoice(playerName, bingoGameId, choiceDTO.Coordinates);

        bool playerHasWon = _playerService.CheckIfPlayerWon(playerName);

        Player player = _playerService.GetPlayerByName(playerName);

        PlayerChoiceResponseDTO playerChoiceResponseDTO = new()
        {
            CurrentChoices = player.CurrentBingoChoices,
            PlayerHasWon = playerHasWon
        };

        return Ok(playerChoiceResponseDTO);
    }
}