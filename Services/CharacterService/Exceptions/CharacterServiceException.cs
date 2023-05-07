namespace dotnet_rpg.Services.CharacterService.Exceptions
{
    public class CharacterServiceException : ApplicationException
    {
        public CharacterServiceException(string msg) : base(msg) { }
    }
}