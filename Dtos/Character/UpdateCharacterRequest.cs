namespace DotNetRPG.Dtos
{
    public class UpdateCharacterRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Frodo";
        public int HitPoints { get; set; } = 100;

        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public CharacterRole Role { get; set; } = CharacterRole.Knight;
    }
}