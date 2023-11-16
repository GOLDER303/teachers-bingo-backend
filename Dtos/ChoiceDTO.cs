namespace TeachersBingoApi.Dtos;

public record ChoiceDTO
{
    public required string PlayerName { get; init; }
    public required CoordinatesDTO Coordinates { get; init; }
};