using dotnet_rpg.Dtos.Character;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private static List<Character> Characters = new List<Character>{
            new Character(),
            new Character{ Name="Sam" }
        };

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            Characters.Add(_mapper.Map<Character>(newCharacter));
            response.Data = Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            response.Data = Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(Guid id)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            Character? character = Characters.FirstOrDefault(c => c.Id == id);
            if (character is not null)
            {
                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            else
            {
                response.Message = $"Character whit id '{id}' not found";
                response.Success = false;
            }
            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            ServiceResponse<GetCharacterDto> response = new ServiceResponse<GetCharacterDto>();
            Character? character = Characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
            if (character is not null)
            {
                response.Data = _mapper.Map<GetCharacterDto>(_mapper.Map<Character>(updatedCharacter));
                response.Message = "Character updated successfuly";
            }
            else
            {
                response.Message = $"Character with id '{updatedCharacter.Id}' not found";
                response.Success = false;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(Guid id)
        {
            Character? character = Characters.Find(c => c.Id == id);
            ServiceResponse<List<GetCharacterDto>> response = new ServiceResponse<List<GetCharacterDto>>();
            if (character is not null)
            {
                Characters.Remove(character);
                response.Data = Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
                response.Message = $"Character '{id}' deleted successfuly";
            }
            else
            {
                response.Success = false;
                response.Message = "Character '{id}' not found";
            }
            return response;
        }
    }
}