namespace CharacterSheetHandler.DTOs.Vampire
{
    public class Status
    {
        public int Path { get; set; }
        public int MaxWillpower { get; set; }
        public int CurrentWillpower { get; set; }
        public int MaxBloodPool { get; set; }
        public int CurrentBloodPool { get; set; }
        public int BloodPerTurn { get; set; }
        public DamageType[] Health { get; set; }
    }
}