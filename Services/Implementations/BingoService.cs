namespace TeachersBingoApi.Services.Implementations;

using Newtonsoft.Json;
using TeachersBingoApi.Models;
using TeachersBingoApi.Repositories.Interfaces;
using TeachersBingoApi.Services.Interfaces;
using TeachersBingoApi.Utils;

public class BingoService : IBingoService
{
    private readonly IBingoRepository _bingoRepository;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public BingoService(IBingoRepository bingoRepository, IWebHostEnvironment hostingEnvironment)
    {
        _bingoRepository = bingoRepository;
        _hostingEnvironment = hostingEnvironment;
    }

    public CurrentBingo? GetCurrentBingo()
    {
        string jsonString = File.ReadAllText($"{_hostingEnvironment.ContentRootPath}/Data/bingoSchedule.json");
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

                Bingo bingo;

                if (_bingoRepository.DoesBingoExistByName(interval.Name))
                {
                    bingo = _bingoRepository.GetBingoByName(interval.Name);
                }
                else
                {
                    bingo = new() { Name = interval.Name };

                    bingo = _bingoRepository.AddBingo(bingo);
                }

                CurrentBingo currentBingo = new() { Bingo = bingo, EndDateTime = endDateTime };

                return currentBingo;
            }
        }

        return null;
    }

    public string[,] GetRandomBingoPhrases(Bingo bingo)
    {
        int bingoSize = 3;
        string[,] randomBingoPhrases = new string[bingoSize, bingoSize];

        List<Phrase> currentBingoPhrases = bingo.Phrases;

        ListUtils.ShuffleList(currentBingoPhrases);

        int index = 0;
        for (int i = 0; i < bingoSize; i++)
        {
            for (int j = 0; j < bingoSize; j++)
            {
                randomBingoPhrases[i, j] = currentBingoPhrases[index].Content;
                index++;
            }
        }

        return randomBingoPhrases;
    }
}
