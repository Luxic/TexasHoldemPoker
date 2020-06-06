using System;
using System.Collections.Generic;
using System.Text;

namespace TexasHoldemPoker
{
	public class Player
	{
		int id;
		Hand myHand;
		List<Card> myCards = new List<Card>();
		string name;
		int amount;
		private string playerName;

		public Player()
		{
		}

		public Player(string playerName)
		{
			this.playerName = playerName;
			amount = 1000;
		}

		public string Name { get => name; set => name = value; }

		public int Amount { get => amount; set => amount = value; }
		public List<Card> MyCards { get => myCards; set => myCards = value; }
		public int Id { get => id; set => id = value; }
		internal Hand MyHand { get => myHand; set => myHand = value; }
	}
}
