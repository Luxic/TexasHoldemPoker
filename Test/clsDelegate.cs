using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Test
{

	public delegate string PokerDelegate(string message);

	public class clsDelegate
	{
		public PokerDelegate pokerEvent;
		string message = "delegateMessage";

		Thread thread;

		public clsDelegate(PokerDelegate p)
		{
			pokerEvent = p;
			thread = new Thread(StartThread);
		}

		private void StartThread(object obj)
		{
			int counter = 0;
			while(counter < 20)
			{
				Thread.Sleep(500);
				counter++;

				pokerEvent(counter.ToString()); ;
			}
		}

		public void StartGame()
		{

			thread.Start();
		}

	}
}
