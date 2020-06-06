namespace GrpcGameMediatorServer.Commands
{
	public class CheckCommand : ICommand
	{
		public override void Execute()
		{
			_pokerGame.Check(_player.Id);
		}
	}
}
