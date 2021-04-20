using UnityEngine;

	public class Card
	{
		private static int _cardsID;
		
		public int ID { get; }
		public int Value { get; }
		public string Name { get; }
		public Sprite Image { get; }
		public Decks Deck { get; }

		public Card(string name, Sprite file, int value, Decks deck)
		{
			ID = _cardsID++;
			Value = value;
			Name = name;
			Deck = deck;
			Image = file;
		}
	}