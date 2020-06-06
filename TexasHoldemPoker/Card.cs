namespace TexasHoldemPoker
{
	public enum RANK
	{
		TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN, EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
	}
	public enum SUIT
	{
		DIAMONDS = 1,
		CLUBS,
		HEARTS,
		SPADES
	}
	public class Card
	{
		private int rank;
		private int suit;

		public Card(int rank, int suit)
		{
			this.rank = rank;
			this.suit = suit;
		}
	}
}
