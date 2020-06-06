namespace WinPokerClient.Commands
{
	public enum ACTIO_LIST
	{
		ADD,
		SUBTRACT,
		MULTIPLY
	}

	public interface IReciever
	{
		void SetAction(ACTIO_LIST action);
		int GetResult();
	}
}
