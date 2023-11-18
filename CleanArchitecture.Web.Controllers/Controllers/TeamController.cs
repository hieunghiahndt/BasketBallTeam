using CleanArchitecture.Application;
using CleanArchitecture.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamUseCase _teamUseCase;

        public TeamController(ITeamUseCase teamUseCase)
        {
            _teamUseCase = teamUseCase;
        }

        [HttpGet("{teamId}")]
        public async Task<ActionResult<Team>> GetTeamData(string teamId)
        {
            var teamData = await _teamUseCase.Get_BasketballTeamAsync(teamId);
            return Ok(teamData);
        }
    }
}