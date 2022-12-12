using SoccerPlayerAPIDotNet7.Models;

namespace SoccerPlayerAPIDotNet7.Services;

public interface ISoccerPlayerService
{
    Task<List<SoccerPlayer>> GetAllSoccerPlayers();
    Task<SoccerPlayer?> GetSingleSoccerPlayer(int id);
    Task<List<SoccerPlayer>> AddSoccerPlayer(SoccerPlayer soccerPlayer);
    Task<List<SoccerPlayer>?> UpdateSoccerPlayer(int id, SoccerPlayer request);
    Task<List<SoccerPlayer>?> DeleteSoccerPlayer(int id);
}