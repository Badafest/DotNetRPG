namespace DotNetRPG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _CharacterService;
        public CharacterController(ICharacterService characterService)
        {
            _CharacterService = characterService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Character>>>> GetAll()
        {
            return Ok(await _CharacterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Character>>> GetById(int id)
        {
            return Ok(await _CharacterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Character>>> Create(Character NewCharacter)
        {
            return Ok(await _CharacterService.AddNewCharacter(NewCharacter));
        }
    }
}