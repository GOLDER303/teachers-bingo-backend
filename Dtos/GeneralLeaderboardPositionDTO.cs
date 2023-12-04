namespace TeachersBingoApi.Dtos;

public record GeneralLeaderboardPositionDTO
{
    public required string PlayerName { get; init; }
    public required int Position { get; init; }
    public required int BingoWinsCount { get; init; }
};