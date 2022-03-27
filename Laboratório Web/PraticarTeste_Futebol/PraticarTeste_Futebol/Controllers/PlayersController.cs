using Microsoft.AspNetCore.Mvc;
using PraticarTeste_Futebol.Models;
using PraticarTeste_Futebol.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PraticarTeste_Futebol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService service;

        public PlayersController(IPlayerService service)
        {
            this.service = service;
        }


        // GET: api/<PlayersController>
        [HttpGet]
        public IEnumerable<Player> GetAll()
        {
            return service.GetAll();
        }


        // GET api/<PlayersController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Player player = service.GetByID(id);
            if(player is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(player);
            }
        }

        // POST api/<PlayersController>
        [HttpPost]
        public IActionResult Post([FromBody] Player player)
        {
            if(player == null)
            {
                return BadRequest();
            }
            else {
                var newPlayer = service.Create(player);
                return CreatedAtRoute("GetByID", newPlayer);
            }
            
        }

        // PUT api/<PlayersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Player player)
        {
            var bookToUpdate = service.GetByID(id);
            if(bookToUpdate is not null || player is not null)
            {
                service.Update(id, player);
                return Ok(bookToUpdate);
            }
            else
            {
                return NotFound();
            }

        }

        // DELETE api/<PlayersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var playerToDelete = service.GetByID(id);
            if(playerToDelete == null)
            {
                return NotFound();
            }
            else
            {
                service.DeleteByID(id);
                return Ok(id);
            }
        }

        [HttpGet]
        public IActionResult GetByTeam(Team team)
        {
            var player = service.GetByTeam(team);
            if (player == null)
            {
                return NotFound();
            }
            else
            { return Ok(player);}
        }

        [HttpPatch]
        public IActionResult Patch(int id, int teamId)
        {
            var player = service.GetByID(id);
            if (player == null)
            { 
                return NotFound();
            }
            else
            {
                player.team.ID = teamId;
                return Ok(player);
            }
        }
    }
}
