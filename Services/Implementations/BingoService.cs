namespace TeachersBingoApi.Services.Implementations;

using Newtonsoft.Json;
using TeachersBingoApi.Models;
using TeachersBingoApi.Repositories.Interfaces;
using TeachersBingoApi.Services.Interfaces;

public class BingoService : IBingoService
{
    private readonly IBingoRepository _bingoRepository;

    public BingoService(IBingoRepository bingoRepository)
    {
        _bingoRepository = bingoRepository;
    }

    public CurrentBingo? GetCurrentBingo()
    {
        string jsonString = File.ReadAllText("bingoSchedule.json");
        var schedule = JsonConvert.DeserializeObject<BingoSchedule>(jsonString);

        if (schedule == null)
        {
            throw new JsonException("Failed to deserialize the bingo schedule from the JSON file.");
        }

        TimeSpan currentTime = DateTime.Now.TimeOfDay;

        foreach (var interval in schedule.Schedule)
        {
            var startTime = TimeSpan.Parse(interval.Start);
            var endTime = TimeSpan.Parse(interval.End);


            if (currentTime >= startTime && currentTime < endTime)
            {
                DateTime currentDate = DateTime.Now.Date;
                DateTime endDateTime = currentDate + endTime;

                CurrentBingo currentBingo = new()
                {
                    Bingo = _bingoRepository.GetBingoByName(interval.Name),
                    EndDateTime = endDateTime
                };

                return currentBingo;
            }
        }

        return null;
    }
}