namespace DotNetRPG.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly List<Character> characters = new()
        {
            new(),
            new(){
                Name = "Sam",
                Role = CharacterRole.Wizard,
                Strength = 15,
                Id = 1,
            }
        };

        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterResponse>>> GetAllCharacters()
        {
            return new() { Data = characters.Select(c => _mapper.Map<GetCharacterResponse>(c)).ToList() };
        }

        public async Task<ServiceResponse<GetCharacterResponse>> GetCharacterById(int id)
        {
            var foundCharacter = characters.FirstOrDefault(c => c.Id == id);
            if (foundCharacter is not null && foundCharacter.Id == id)
            {
                return new() { Data = _mapper.Map<GetCharacterResponse>(foundCharacter) };
            }

            return new() { Message = "Character Not Found", Success = false };
        }


        public async Task<ServiceResponse<GetCharacterResponse>> AddNewCharacter(AddCharacterRequest newCharacter)
        {
            var addedCharacter = _mapper.Map<Character>(newCharacter);
            addedCharacter.Id = characters.Max(c => c.Id) + 1;
            characters.Add(addedCharacter);
            return new() { Data = _mapper.Map<GetCharacterResponse>(addedCharacter) };
        }

        public async Task<ServiceResponse<GetCharacterResponse>> UpdateCharacter(UpdateCharacterRequest updatedCharacter)
        {
            var foundCharacter = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
            if (foundCharacter is not null && foundCharacter.Id == updatedCharacter.Id)
            {
                foundCharacter.Name = updatedCharacter.Name;
                foundCharacter.HitPoints = updatedCharacter.HitPoints;
                foundCharacter.Strength = updatedCharacter.Strength;
                foundCharacter.Defense = updatedCharacter.Defense;
                foundCharacter.Intelligence = updatedCharacter.Intelligence;
                foundCharacter.Role = updatedCharacter.Role;
            
                return new() { Data = _mapper.Map<GetCharacterResponse>(foundCharacter) };
            }

            return new() { Message = "Character Not Found", Success = false };
        }
    }
}