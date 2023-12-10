
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
        public async Task<ServiceResponse<Character>> AddNewCharacter(Character newCharacter)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            return new() { Data = characters };
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var foundCharacter = characters.FirstOrDefault(c => c.Id == id);
            if (foundCharacter is not null && foundCharacter.Id == id)
            {
                return new() { Data = foundCharacter };
            }

            return new() { Message = "Character Not Found", Success = false };
        }
    }
}