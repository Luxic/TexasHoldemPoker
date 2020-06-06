namespace GrpcGameMediatorServer.Commands
{
	public class CommandFactory
	{
		static ICommand command = null;

		public static ICommand GetCommand(CommandRequest commandRequest)
		{
			switch (commandRequest.CommandId)
			{
				case PokerCommand.Call:
					command = new CallCommand();
					break;
				case PokerCommand.NewPlayer:
					command = new AddPlayerCommand();
					break;
				case PokerCommand.Check:
					command = new CheckCommand();
					break;
				case PokerCommand.Fold:
					command = new FoldCommand();
					break;
				case PokerCommand.RemovePlayer:
					command = new RemovePlayerCommand();
					break;
				default:

					break;
			}

			return command;
		}
	}
}
