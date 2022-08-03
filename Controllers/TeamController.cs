using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SoccerWebAPI.Entities;
using SoccerWebAPI.ExternalModels;
using SoccerWebAPI.Services.UnitsOfWork;

namespace SoccerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamUnitOfWork _teamUnit;
        private readonly IMapper _mapper;

        public TeamController(ITeamUnitOfWork teamUnit, IMapper mapper)
        {
            _teamUnit = teamUnit ?? throw new ArgumentNullException(nameof(teamUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #region Teams
        [HttpGet]
        [Route("{id}", Name = "GetTeam")]
        public IActionResult GetTeam(Guid id)
        {
            var teamEntity = _teamUnit.Teams.Get(id);
            if (teamEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TeamDTO>(teamEntity));
        }
        [HttpGet]
        [Route("", Name = "GetAllTeams")]
        public IActionResult GetAllBooks()
        {
            var teamEntities = _teamUnit.Teams.Find(t => t.Deleted == false || t.Deleted == null);
            if (teamEntities == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<TeamDTO>>(teamEntities));
        }
        [HttpGet]
        [Route("details/{id}", Name = "GetTeamDetails")]
        public IActionResult GetTeamDetails(Guid id)
        {
            var teamEntity = _teamUnit.Teams.GetTeamDetails(id);
            if (teamEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TeamDTO>(teamEntity));
        }
        [Route("add", Name = "Add a new team")]
        [HttpPost]
        public IActionResult AddTeam([FromBody] TeamDTO team)
        {
            var teamEntity = _mapper.Map<Team>(team);
            _teamUnit.Teams.Add(teamEntity);
            _teamUnit.Complete();
            _teamUnit.Teams.Get(teamEntity.Id);
            return CreatedAtRoute("GetTeam",
                new { id = teamEntity.Id }, _mapper.Map<TeamDTO>(teamEntity));
        }
        #endregion Teams
        #region Coaches
        [HttpGet]
        [Route("AllCoaches", Name = "GetAllCoaches")]
        public IActionResult GetAllCoaches()
        {
            var coachEntities = _teamUnit.Coaches.Find(c => c.Deleted == false || c.Deleted == null);
            if (coachEntities == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<CoachDTO>>(coachEntities));
        }
        [HttpGet]
        [Route("Coachesdetails/{id}", Name = "GetCoachDetails")]
        public IActionResult GetCoachDetails(Guid id)
        {
            var coachEntity = _teamUnit.Coaches.GetCoachDetails(id);
            if (coachEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CoachDTO>(coachEntity));
        }
        [Route("addCoach", Name = "Add a new coach")]
        [HttpPost]
        public IActionResult AddCoach([FromBody] CoachDTO coach)
        {
            var coachEntity = _mapper.Map<Coach>(coach);
            _teamUnit.Coaches.Add(coachEntity);
            _teamUnit.Complete();
            _teamUnit.Coaches.Get(coachEntity.Id);
            return CreatedAtRoute("GetCoach",
                new { id = coachEntity.Id }, _mapper.Map<CoachDTO>(coachEntity));
        }
        #endregion Coaches

    }
}