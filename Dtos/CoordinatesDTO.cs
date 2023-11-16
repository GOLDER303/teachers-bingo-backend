using System.ComponentModel.DataAnnotations;

namespace TeachersBingoApi.Dtos;

public record CoordinatesDTO([Required] int X, [Required] int Y);