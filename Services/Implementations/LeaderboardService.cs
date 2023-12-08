using TeachersBingoApi.Dtos;
using TeachersBingoApi.Models;
using TeachersBingoApi.Repositories.Interfaces;
using TeachersBingoApi.Services.Interfaces;

namespace TeachersBingoApi.Services.Implementations;

public class LeaderboardService : ILeaderboardService
{
    private readonly ILeaderboardRepository _leaderboardRepository;
    private readonly ILeaderboardPositionRepository _leaderboardPositionRepository;
    private readonly IBingoGameService _bingoGameService;

    public LeaderboardService(
        ILeaderboardRepository leaderboardRepository,
        ILeaderboardPositionRepository leaderboardPositionRepository,
        IBingoGameService bingoGameService
    )
    {
        _leaderboardRepository = leaderboardRepository;
        _leaderboardPositionRepository = leaderboardPositionRepository;
        _bingoGameService = bingoGameService;
    }

    public void AddPlayerToLeaderboard(Player player, int leaderboardId)
    {
        var leaderboard = _leaderboardRepository.GetLeaderboardById(leaderboardId);

        if (IsPlayerInLeaderboard(player, leaderboard.Id))
        {
            return;
        }

        int position = leaderboard.Positions.Count + 1;

        LeaderboardPosition newLeaderboardPosition =
            new()
            {
                Position = position,
                Player = player,
                Leaderboard = leaderboard,
            };

        _leaderboardPositionRepository.AddLeaderboardPosition(newLeaderboardPosition);

        leaderboard.Positions.Add(newLeaderboardPosition);

        _leaderboardRepository.SaveChanges();
    }

    public bool UpdatePlayerInLeaderboard(Player player, int leaderboardId)
    {
        bool playerHasWon = _bingoGameService.CheckIfPlayerWon(player);

        if (playerHasWon && !IsPlayerInLeaderboard(player, leaderboardId))
        {
            AddPlayerToLeaderboard(player, leaderboardId);
        }
        else if (!playerHasWon && IsPlayerInLeaderboard(player, leaderboardId))
        {
            RemovePlayerFromLeaderboard(player, leaderboardId);
        }

        return playerHasWon;
    }

    public bool IsPlayerInLeaderboard(Player player, int leaderboardId)
    {
        var leaderboard = _leaderboardRepository.GetLeaderboardById(leaderboardId);
        var isPlayerInLeaderboard = leaderboard.Positions.Any(p => p.Player.Id == player.Id);
        return isPlayerInLeaderboard;
    }

    public void RemovePlayerFromLeaderboard(Player player, int leaderboardId)
    {
        var leaderboard = _leaderboardRepository.GetLeaderboardById(leaderboardId);

        if (!IsPlayerInLeaderboard(player, leaderboard.Id))
        {
            return;
        }

        _leaderboardPositionRepository.RemoveLeaderboardPositionByLeaderboardIdAndPlayerId(leaderboard.Id, player.Id);
    }

    public GeneralLeaderboardDTO GetGeneralLeaderboard()
    {
        var leaderboardPositionsDTOS = _leaderboardPositionRepository.GetAllLeaderboardPositionsAsDTOs();

        int currentPosition = 0;
        int previousPositionBingoCount = int.MaxValue;

        List<GeneralLeaderboardPositionDTO> allLeaderBoardPositionsDTOs = new();

        // Set proper positions
        foreach (var leaderboardPositionDTO in leaderboardPositionsDTOS)
        {
            if (leaderboardPositionDTO.BingoWinsCount < previousPositionBingoCount)
            {
                previousPositionBingoCount = leaderboardPositionDTO.BingoWinsCount;
                currentPosition++;
            }

            allLeaderBoardPositionsDTOs.Add(
                new GeneralLeaderboardPositionDTO
                {
                    PlayerName = leaderboardPositionDTO.PlayerName,
                    BingoWinsCount = leaderboardPositionDTO.BingoWinsCount,
                    Position = currentPosition
                }
            );
        }

        var generalLeaderboardDTO = new GeneralLeaderboardDTO { Positions = allLeaderBoardPositionsDTOs };

        return generalLeaderboardDTO;
    }

    public LeaderboardDTO GetLeaderboardByBingoGameId(int bingoGameId)
    {
        var bingoGame = _bingoGameService.GetBingoGameWithLeaderboardById(bingoGameId);
        var leaderboardPositionsDTOs = _leaderboardPositionRepository.GetLeaderboardPositionsAsDTOsByLeaderboardId(
            bingoGame.Leaderboard.Id
        );

        var leaderboardDTO = new LeaderboardDTO { Positions = leaderboardPositionsDTOs };

        return leaderboardDTO;
    }
}
