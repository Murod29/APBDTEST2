namespace CharacterInventoryAPI.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CurrentWeight { get; set; }
        public int MaxWeight { get; set; }
        public ICollection<Backpack> Backpacks { get; set; }
        public ICollection<CharacterTitle> CharacterTitles { get; set; }
    }
}