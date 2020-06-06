namespace GrpcGameMediatorServer.Commands
{
	public class RemovePlayerCommand : ICommand
	{
		public override void Execute()
		{
			_pokerGame.RemovePlayer(_player.Id);
		}
	}
}
