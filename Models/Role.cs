using System.Text.Json.Serialization;

namespace DotNetRPG.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Role
    {
        Knight = 1,
        Wizard = 2,
        Healer = 3
    }
}