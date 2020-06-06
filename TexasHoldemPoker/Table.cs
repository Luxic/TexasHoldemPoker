using System.Collections.Generic;

namespace TexasHoldemPoker
{
	public class Table
	{
		public List<Player> listPlayers;
		Deck deck;

		public Table()
		{
			listPlayers = new List<Player>();
		}

	}
}
