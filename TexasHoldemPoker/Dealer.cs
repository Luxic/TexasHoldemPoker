namespace TexasHoldemPoker
{
	public class Dealer
	{
		Table pokerTable;
		Deck deck;

		public Dealer()
		{
			deck = new Deck();
		}

		public Table PokerGame { get => pokerTable; set => pokerTable = value; }
		public Deck Deck { get => deck; set => deck = value; }

		internal void DealPlayersCard()
		{
			for(int i = 0; i < 2; i++)
			{
				foreach (Player p in pokerTable.listPlayers)
				{
					p.MyCards.Add(deck.GetCard());
				}
			}
		}
	}
}
