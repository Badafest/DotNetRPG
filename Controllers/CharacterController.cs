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
        public async Task<ActionResult<ServiceResponse<List<CharacterResponse>>>> GetAll()
        {
            var serviceResponse = await _CharacterService.GetAllCharacters();
            return StatusCode((int)serviceResponse.Status, serviceResponse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CharacterResponse>>> GetById(int id)
        {
            var serviceResponse = await _CharacterService.GetCharacterById(id);
            return StatusCode((int)serviceResponse.Status, serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CharacterResponse>>>> Create(AddCharacterRequest newCharacter)
        {
            var serviceResponse = await _CharacterService.AddNewCharacter(newCharacter);
            return StatusCode((int)serviceResponse.Status, serviceResponse);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<CharacterResponse>>>> Update(UpdateCharacterRequest updatedCharacter)
        {
            var serviceResponse = await _CharacterService.UpdateCharacter(updatedCharacter);
            return StatusCode((int)serviceResponse.Status, serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<CharacterResponse>>>> Delete(int id)
        {
            var serviceResponse = await _CharacterService.DeleteCharacter(id);
            return StatusCode((int)serviceResponse.Status, serviceResponse);
        }
    }
}