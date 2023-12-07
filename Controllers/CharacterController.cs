using Microsoft.AspNetCore.Mvc;

namespace DotNetRPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CharacterController : ControllerBase
    {
        private static readonly List<Character> Characters = new()
        {
            new(),
            new(){
                Name = "Sam",
                Role = Role.Wizard,
                Strength = 15,
                Id = 1,
            }
        };
        [HttpGet]
        public ActionResult<List<Character>> GetAll()
        {
            return Ok(Characters);
        }

        [HttpGet("{Id}")]
        public ActionResult<Character> GetById(int Id)
        {
            var FoundCharacter = Characters.FirstOrDefault(Character => Character.Id == Id);
            if (FoundCharacter == null || FoundCharacter.Id != Id)
            {
                return NotFound();
            }
            return Ok(FoundCharacter);
        }
    }
}