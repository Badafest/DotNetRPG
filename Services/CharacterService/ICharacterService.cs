namespace DotNetRPG.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterResponse>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterResponse>> GetCharacterById(int id);

        Task<ServiceResponse<GetCharacterResponse>> AddNewCharacter(AddCharacterRequest newCharacter);
        Task<ServiceResponse<GetCharacterResponse>> UpdateCharacter(UpdateCharacterRequest updatedCharacter);
    }
}