namespace TeachersBingoApi.Dtos;

public record GeneralLeaderboardDTO
{
    public required List<GeneralLeaderboardPositionDTO> Positions { get; init; }
};
