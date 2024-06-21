﻿namespace CharacterInventoryAPI.Models
{
    public class Backpack
    {
        public int CharacterId { get; set; }
        public Character Character { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Amount { get; set; }
    }
}