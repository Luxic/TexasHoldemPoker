using System;
using System.Collections.Generic;
using System.Text;

namespace TexasHoldemPoker
{
	public class Deck
	{
		List<Card> cards;

		public Deck()
		{
			cards = new List<Card>();

			for (int i = 2; i <= 14; i++)
			{
				for (int j = 1; j <= 4; j++)
				{
					cards.Add(new Card(i, j)); ;
				}
			}
		}

		internal Card GetCard()
		{
			Card c = cards[0];
			cards.RemoveAt(0);

			return c;
		}
	}
}
