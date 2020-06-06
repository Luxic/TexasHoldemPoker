using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WinPokerClient
{

	public delegate void PokerCommandHandler(string message);


	public class ReceiverSendManager
	{
		public event PokerCommandHandler commandReceivedEvent;

		AsyncQueue<string> commandReceivQueue;
		AsyncQueue<string> commandSendQueue;
		Thread commandManagerThread;

		public ReceiverSendManager(AsyncQueue<string> q, AsyncQueue<string> q2)
		{
			commandReceivQueue = q;
			commandSendQueue = q2;
		}

		public void Start()
		{
			commandManagerThread = new Thread(Run);
			commandManagerThread.Start();
		}

		private async void Run()
		{
			while (true)
			{
				var command = await commandReceivQueue.DequeueAsync();
				OnCommamndReceive(command.ToString());

				Thread.Sleep(500);
			}
		}

		public void Stop()
		{
			commandManagerThread.Join();
		}

		protected void OnCommamndReceive(string message)
		{
			if (commandReceivedEvent != null)
			{
				commandReceivedEvent(message);
			}
		}
	}
}
