using System;
using System.Linq;

namespace TexasHoldemPoker
{

	public enum PokerState
	{
		WaitForPlayers = 1,
		DealToPlayers,
		PlayersBetting,
		DealFlop,
		PlayersBetting2,
		DealRiver,
		PlayersBettin3,
		Finish,
	}

	public class PokerGame
	{
		int _id;

		public void Fold(int id)
		{
			
		}

		Table pokerTable;
		PokerState state;

		public int ID
		{
			get { return _id; }
		}

		public PokerGame(int Id)
		{
			_id = Id;
			PokerTable = new Table();
			state = PokerState.WaitForPlayers;
		}

		public Table PokerTable { get => pokerTable; set => pokerTable = value; }

		public void AddPlayer(Player player)
		{
			if (PokerTable.listPlayers.Count == 6)
				return;

			PokerTable.listPlayers.Add(player);
		}

		public void StartGame()
		{

		}

		public void RemovePlayer(int id)
		{
			var sdf = pokerTable.listPlayers.Where(x => x.Id == id).FirstOrDefault();
			pokerTable.listPlayers.Remove(sdf);
		}

		public void Call(int id)
		{
			
		}

		public void Check(int id)
		{
			throw new NotImplementedException();
		}
	}
}
