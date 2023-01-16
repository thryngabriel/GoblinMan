using SQLite;

namespace GoblinMan.Models
{
    [Table("goblins")]
    public class Goblin
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public bool IsCreature { get; set; }
        public int Level { get; set; }
        public int HealthMax { get; set; }
        public int Armor { get; set; }
        public int Perception { get; set; }
        public int Stealth { get; set; }
    }
}
