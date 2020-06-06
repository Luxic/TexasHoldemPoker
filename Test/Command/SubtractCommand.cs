using System;
using System.Collections.Generic;
using System.Text;

namespace WinPokerClient.Commands
{
	public class SubtractCommand : Command
    {
        public SubtractCommand(IReciever reciever)
            : base(reciever)
        {

        }

        public override int Execute()
        {
            base.receiver.SetAction(ACTIO_LIST.SUBTRACT);
            return receiver.GetResult();
        }
    }
}
