namespace DotNetRPG.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<CharacterResponse>>> GetAllCharacters();
        Task<ServiceResponse<CharacterResponse>> GetCharacterById(int id);

        Task<ServiceResponse<CharacterResponse>> AddNewCharacter(AddCharacterRequest newCharacter);
        Task<ServiceResponse<CharacterResponse>> UpdateCharacter(UpdateCharacterRequest updatedCharacter);

        Task<ServiceResponse<CharacterResponse>> DeleteCharacter(int id);
    }
}