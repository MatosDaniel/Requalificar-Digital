using Ficha10.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ficha10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {

        private Characters characters;

        public CharactersController()
        {
            characters = JsonLoader.LoadCharactersJson();
        }

        // GET: api/<CharactersController>
        [HttpGet]
        public IEnumerable<Character> Get()
        {
            return characters.CharactersList;
        }

        // GET api/<CharactersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CharactersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CharactersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CharactersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
