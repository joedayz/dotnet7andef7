using Microsoft.AspNetCore.Mvc;
using SoccerPlayerAPIDotNet7.Models;
using SoccerPlayerAPIDotNet7.Services;

namespace SoccerPlayerAPIDotNet7.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SoccerPlayerController: ControllerBase
{
    private readonly ISoccerPlayerService _soccerPlayerService;
    
    public SoccerPlayerController(ISoccerPlayerService soccerPlayerService)
    {
        _soccerPlayerService = soccerPlayerService;
    }

    [HttpGet]
    public async Task<ActionResult<List<SoccerPlayer>>> GetAllSoccerPlayers()
    {
        return await _soccerPlayerService.GetAllSoccerPlayers();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<SoccerPlayer>> GetSingleSoccerPlayer(int id)
    {
         var soccerPlayer =  await _soccerPlayerService.GetSingleSoccerPlayer(id);
         if (soccerPlayer is null)
             return NotFound("Soccer Player not found.");
         return Ok(soccerPlayer);
    }

    [HttpPost]
    public async Task<ActionResult<List<SoccerPlayer>>> AddSoccerPlayer(SoccerPlayer soccerPlayer)
    {
        var result =  await _soccerPlayerService.AddSoccerPlayer(soccerPlayer);
        return Ok(result);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<SoccerPlayer>>> UpdateSoccerPlayer(int id, SoccerPlayer request)
    {
        var result =  await _soccerPlayerService.UpdateSoccerPlayer(id, request);
        if(result is null)
            return NotFound("Soccer Player not found.");
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<SoccerPlayer>>> DeleteSoccerPlayer(int id)
    {
        var result =  await _soccerPlayerService.DeleteSoccerPlayer(id);
        if(result is null)
            return NotFound("Soccer Player not found.");
        return Ok(result);
    }
}