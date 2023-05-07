using System.Text.Json.Serialization;

namespace dotnet_rpg.Models.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass : int
    {
        Knight,
        Mage,
        Cleric,
        Healer
    }
}