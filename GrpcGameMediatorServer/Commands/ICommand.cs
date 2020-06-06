using TexasHoldemPoker;

namespace GrpcGameMediatorServer.Commands
{
	public abstract class ICommand
	{
		protected Player _player;
		protected PokerGame _pokerGame;

		public PokerGame PokerGame
		{
			set { _pokerGame = value; }
		}

		public Player Player
		{
			set { _player = value; }
		}
		public abstract void Execute();
	}
}
