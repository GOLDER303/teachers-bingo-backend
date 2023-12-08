namespace TeachersBingoApi.Dtos;

public record LeaderboardPositionDTO
{
    public required string PlayerName { get; init; }
    public required int Position { get; init; }
};
