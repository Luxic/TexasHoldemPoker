namespace WinPokerClient.Commands
{
	public class AddCommand : Command
	{
		public AddCommand(IReciever reciever) : base(reciever)
		{}

		public override int Execute()
		{
			base.receiver.SetAction(ACTIO_LIST.ADD);
			return receiver.GetResult();
		}
	}
}
