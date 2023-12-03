namespace TeachersBingoApi.Dtos;

public record GeneralLeaderboardDTO
{
    public required List<LeaderboardPositionDTO> Positions { get; init; }
};