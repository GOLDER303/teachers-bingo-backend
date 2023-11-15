using System.ComponentModel.DataAnnotations;

namespace TeachersBingoApi.Dtos;

public record JoinCurrentBingoDTO([Required] string PlayerName);