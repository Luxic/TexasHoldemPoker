namespace WinPokerClient.Commands
{
	public abstract class Command
	{
		protected IReciever receiver = null;

		public Command(IReciever receiver)
		{
			this.receiver = receiver;
		}

		public abstract int Execute();
	}
}
