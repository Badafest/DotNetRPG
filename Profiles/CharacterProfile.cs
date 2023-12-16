namespace DotNetRPG.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterResponse>();
            CreateMap<AddCharacterRequest, Character>();
        }
    }
}