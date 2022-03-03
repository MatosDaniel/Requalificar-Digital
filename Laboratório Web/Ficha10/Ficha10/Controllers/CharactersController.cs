using Ficha10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ficha10.Controllers
{
    [Route("[controller]")]
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
        
        // POST api/<CharactersController>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Character character)
        {
            if (characters.CharactersList.Count == 0)
            {
                character.Id = 1;
                characters.CharactersList.Add(character);
            }
            else
            {
                var lastChar = characters.CharactersList[characters.CharactersList.Count - 1];
                character.Id = lastChar.Id + 1;
                characters.CharactersList.Add(character);
            }

            return Ok(character);
        }

        
        // DELETE api/<CharactersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var remove = characters.CharactersList.RemoveAll(e => e.Id == id);
            if(remove == 0)
            {
                return NotFound($"ID: {id} não foi encontrado.");
            }
            else
            {
                return Ok($"ID: {id} foi removido.");
            }
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var chara = characters.CharactersList.Find(e => e.Id == id);
            if (chara == null)
            {
                return NotFound($"ID: {id} not found.");
            }
            else
            {
                return Ok(chara);
            }
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Character))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(int id, [FromBody] Character character)
        {
            var chara = characters.CharactersList.Find(e => e.Id == id);
            if (chara == null)
            {
                return NotFound($"ID: {id} not found!");
            }
            else
            {
                chara.Name = character.Name;
                chara.Gender = character.Gender;
                chara.Homeworld = character.Homeworld;
                chara.Born = character.Born;
                chara.Jedi = character.Jedi;

                return Ok(chara);
            }
        } 

        [HttpGet("/jedi")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult GetJedi()
        {
            List<Character> jedi = characters.CharactersList.FindAll(e => e.Jedi == true);
            if (jedi.Count == 0)
            {
                return NotFound($"Não foi encontrada nenhuma personagem Jedi");
            }
            else
            {
                return Ok(jedi);
            }
        }

        [HttpGet("gender/{gender}", Name = "GetByGender")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Character))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string gender)
        {
            Character? chara = characters.CharactersList.Find(e => e.Gender == gender);
            if (chara == null)
            {
                return NotFound($"Não foi encontrado ninguem do género {gender}");
            }
            else
            {
                return Ok(chara);
            }
        }

        [HttpGet("download", Name = "DownloadChars")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Characters))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DownloadChars()
        {
            string jsonAllCharas = JsonSerializer.Serialize<Characters>(characters);
            System.IO.File.WriteAllText("JsonFiles/allCharas.json", jsonAllCharas);

            try
            {
                byte[] bytes = System.IO.File.ReadAllBytes("./JsonFiles/allCharas.json");
                return File(bytes, "application/json", "JsonFiles/characters.json");
            }
            catch (FileNotFoundException e)
            {
                return NotFound(e.Message);
            }
        } 
    }
}
