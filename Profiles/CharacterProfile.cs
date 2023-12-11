namespace DotNetRPG.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, GetCharacterResponse>();
            CreateMap<AddCharacterRequest, Character>();
        }
    }
}