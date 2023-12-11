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
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponse>>>> GetAll()
        {
            return Ok(await _CharacterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterResponse>>> GetById(int id)
        {
            return Ok(await _CharacterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponse>>>> Create(AddCharacterRequest newCharacter)
        {
            return Ok(await _CharacterService.AddNewCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterResponse>>>> Update(UpdateCharacterRequest updatedCharacter)
        {
            return Ok(await _CharacterService.UpdateCharacter(updatedCharacter));
        }
    }
}