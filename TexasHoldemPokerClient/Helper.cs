using GrpcGameMediatorServer;

namespace TexasHoldemPokerClient
{
	public static class Helper
	{
		public static PokerCommand? CreateCommand(string command)
		{
			PokerCommand? p = null;


			switch (command)
			{
				case "cal":
					p = PokerCommand.Call;
					break;
				case "rem":
					p = PokerCommand.RemovePlayer;
					break;
				case "che":
					p = PokerCommand.Check;
					break;
				case "fol":
					p = PokerCommand.Fold;
					break;
				case "rai":
					p = PokerCommand.Raise;
					break;
				default:
					break;
			}

			return p;
		}
	}
}
