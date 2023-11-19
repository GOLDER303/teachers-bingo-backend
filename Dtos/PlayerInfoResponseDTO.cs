using TeachersBingoApi.Dots;

namespace TeachersBingoApi.Dtos;

public record PlayerInfoResponseDTO
{
    public required string PlayerName { get; init; }
    public required int? CurrentBingoId { get; init; }
    public required string[,]? CurrentPhrases { get; init; }
    public required bool[,] CurrentChoices { get; init; }
};