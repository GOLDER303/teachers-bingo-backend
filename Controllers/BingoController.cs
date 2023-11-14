using Microsoft.AspNetCore.Mvc;
using TeachersBingoApi.Dots;
using TeachersBingoApi.Dtos;
using TeachersBingoApi.Services.Interfaces;

namespace TeachersBingoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BingoController : ControllerBase
{
    private readonly IBingoService _bingoService;

    public BingoController(IBingoService bingoService)
    {
        _bingoService = bingoService;
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
}