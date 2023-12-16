namespace DotNetRPG.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CharacterService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<CharacterResponse>>> GetAllCharacters()
        {
            var characters = await _context.Characters.ToListAsync();
            return new() { Data = characters.Select(c => _mapper.Map<CharacterResponse>(c)).ToList() };
        }

        public async Task<ServiceResponse<CharacterResponse>> GetCharacterById(int id)
        {
            var foundCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            if (foundCharacter is not null && foundCharacter.Id == id)
            {
                return new() { Data = _mapper.Map<CharacterResponse>(foundCharacter) };
            }

            return new() { Message = "Character Not Found", Success = false, Status = HttpStatusCode.NotFound };
        }


        public async Task<ServiceResponse<CharacterResponse>> AddNewCharacter(AddCharacterRequest newCharacter)
        {
            var addedCharacter = _mapper.Map<Character>(newCharacter);
            // addedCharacter.Id = characters.Max(c => c.Id) + 1;
            await _context.Characters.AddAsync(addedCharacter);
            await _context.SaveChangesAsync();
            return new() { Data = _mapper.Map<CharacterResponse>(addedCharacter) };
        }

        public async Task<ServiceResponse<CharacterResponse>> UpdateCharacter(UpdateCharacterRequest updatedCharacter)
        {
            var foundCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
            if (foundCharacter is not null && foundCharacter.Id == updatedCharacter.Id)
            {
                foundCharacter.Name = updatedCharacter.Name;
                foundCharacter.HitPoints = updatedCharacter.HitPoints;
                foundCharacter.Strength = updatedCharacter.Strength;
                foundCharacter.Defense = updatedCharacter.Defense;
                foundCharacter.Intelligence = updatedCharacter.Intelligence;
                foundCharacter.Role = updatedCharacter.Role;
                await _context.SaveChangesAsync();
                return new() { Data = _mapper.Map<CharacterResponse>(foundCharacter) };
            }

            return new() { Message = "Character Not Found", Success = false, Status = HttpStatusCode.NotFound };
        }

        public async Task<ServiceResponse<CharacterResponse>> DeleteCharacter(int id)
        {
            var foundCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            if (foundCharacter is not null && foundCharacter.Id == id)
            {
                _context.Characters.Remove(foundCharacter);
                await _context.SaveChangesAsync();
                return new() { Data = _mapper.Map<CharacterResponse>(foundCharacter) };
            }

            return new() { Message = "Character Not Found", Success = false, Status = HttpStatusCode.NotFound };
        }
    }
}