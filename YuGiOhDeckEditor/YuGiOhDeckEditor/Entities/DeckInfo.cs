﻿using Core.Entities;

namespace YuGiOhDeckEditor.Entities
{
    public class DeckInfo : BaseID
    {
        public string Name { get; set; }
        public string OwnerId { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime UpdatedDeck { get; set; }

        // Constructor with parameters (optional for convenience)
        public DeckInfo(string name, string ownerId, string description, DateTime dateCreated, DateTime updatedDeck)
        {
            Name = name;
            OwnerId = ownerId;
            Description = description;
            DateCreated = dateCreated;
            UpdatedDeck = updatedDeck;
        }

        public DeckInfo()
        {
        }
    }
}
