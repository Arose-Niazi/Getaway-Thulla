using UnityEngine;

	public class Card
	{
		private int Value { get; }
		private string Name { get; }
		public Sprite Image { get; }
		private Decks Deck { get; }

		public Card(string name, Sprite file, int value, Decks deck)
		{
			Value = value;
			Name = name;
			Deck = deck;
			Image = file;
			Debug.Log(Image);
		}
	}