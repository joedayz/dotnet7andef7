using Microsoft.EntityFrameworkCore;
using SoccerPlayerAPIDotNet7.Data;
using SoccerPlayerAPIDotNet7.Models;

namespace SoccerPlayerAPIDotNet7.Services;

public class SoccerPlayerService: ISoccerPlayerService
{
    private readonly DataContext _dataContext;

    public SoccerPlayerService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<List<SoccerPlayer>> GetAllSoccerPlayers()
    {
        var soccerPlayers = await _dataContext.SoccerPlayers.ToListAsync();
        return soccerPlayers;
    }

    public async Task<SoccerPlayer?> GetSingleSoccerPlayer(int id)
    {
        var soccerPlayer = await _dataContext.SoccerPlayers.FindAsync(id);
        if (soccerPlayer is null)
            return null;
        return soccerPlayer;
    }

    public async Task<List<SoccerPlayer>> AddSoccerPlayer(SoccerPlayer soccerPlayer)
    {
        _dataContext.SoccerPlayers.Add(soccerPlayer);
        await _dataContext.SaveChangesAsync();
        return await _dataContext.SoccerPlayers.ToListAsync();
    }

    public async Task<List<SoccerPlayer>?> UpdateSoccerPlayer(int id, SoccerPlayer request)
    {
        var soccerPlayer = await _dataContext.SoccerPlayers.FindAsync(id);
        if (soccerPlayer is null)
            return null;
        soccerPlayer.FirstName = request.FirstName;
        soccerPlayer.LastName = request.LastName;
        soccerPlayer.Name = request.Name;
        soccerPlayer.Country = request.Country;
        
        await _dataContext.SaveChangesAsync();
        return await _dataContext.SoccerPlayers.ToListAsync();
    }

    public async Task<List<SoccerPlayer>?> DeleteSoccerPlayer(int id)
    {
        var soccerPlayer = await _dataContext.SoccerPlayers.FindAsync(id);
        if (soccerPlayer is null)
            return null;
        _dataContext.SoccerPlayers.Remove(soccerPlayer);
        await _dataContext.SaveChangesAsync();
        
        return await _dataContext.SoccerPlayers.ToListAsync();
    }
}