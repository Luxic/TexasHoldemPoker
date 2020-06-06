using TexasHoldemPoker;

namespace GrpcGameMediatorServer.Commands
{
	public class CallCommand : ICommand
	{
		public CallCommand()
		{ }

		public override void Execute()
		{
			_pokerGame.Call(_player.Id);
		}
	}
}
