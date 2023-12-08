namespace TeachersBingoApi.Dtos;

using TeachersBingoApi.Dots;

public record BingoDTO(int Id, string Name, IEnumerable<PhraseDTO> Phrases);
