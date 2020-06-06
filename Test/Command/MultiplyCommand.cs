using System;
using System.Collections.Generic;
using System.Text;

namespace WinPokerClient.Commands
{
	public class MultiplyCommand : Command
	{
		public MultiplyCommand(IReciever reciever)
			: base(reciever)
		{

		}

		public override int Execute()
		{
			base.receiver.SetAction(ACTIO_LIST.MULTIPLY);
			return receiver.GetResult();
		}
	}
}
