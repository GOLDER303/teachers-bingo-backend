namespace TeachersBingoApi.Dtos;

public record LeaderboardDTO
{
    public required List<LeaderboardPositionDTO> Positions { get; init; }
};