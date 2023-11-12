using Microsoft.AspNetCore.Mvc;
using TeachersBingoApi.Dots;
using TeachersBingoApi.Dtos;
using TeachersBingoApi.Services;

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
    public ActionResult<BingoDTO> GetRandomBingo()
    {
        var bingo = _bingoService.GetRandomBingo();

        var phrases = bingo.Phrases.Select(p => new PhraseDTO(p.Content)).ToList();
        var bingoDTO = new BingoDTO(bingo.Id, bingo.Name, phrases);

        return Ok(bingoDTO);
    }
}