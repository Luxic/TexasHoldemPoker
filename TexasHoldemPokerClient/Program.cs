using GrpcGameMediatorServer;
using System;
using WinPokerClient;

namespace TexasHoldemPokerClient
{
	class Program
	{
		static PokerGames pokerGame;
		static gRpcServiceThread t;
		static AsyncQueue<CommandReplay> commandReceivQueue;
		static AsyncQueue<CommandRequest> commandSendQueue;
		static CommandRequest commandRequest;
		static Player player;

		static void Main(string[] args)
		{

			int ID;
			string Name = "";

			Console.Write("ID => ");
			ID = Convert.ToInt32(Console.ReadLine());
			DeletePrevConsoleLine();

			Console.Write("Name => ");
			Name = Console.ReadLine();
			DeletePrevConsoleLine();

			pokerGame = new PokerGames();
			pokerGame.Name = "SitAndGo";
			pokerGame.Min = 5;
			pokerGame.Max = 10;
			pokerGame.Id = 1;

			player = new Player();
			player.Id = ID;
			player.Name = Name;
			player.Ammount = 1000;



			commandRequest = new CommandRequest();
			commandRequest.Player = player;

			commandReceivQueue = new AsyncQueue<CommandReplay>();
			commandSendQueue = new AsyncQueue<CommandRequest>();

			//	pokerCommand = new PokerCommandHandler(ProcessCommand);
			t = new gRpcServiceThread(commandReceivQueue, commandSendQueue);
			t.Add(player);
			CommandListener();

			CommandRequest connectStreamRequest = new CommandRequest();
			connectStreamRequest.Player = player;

			commandSendQueue.Enqueue(connectStreamRequest);

			t.Run();

			string sd = Console.ReadLine();

			while (sd != "ex")
			{
				CommandRequest req = new CommandRequest();
				PokerCommand? comand = Helper.CreateCommand(sd);

				if (comand != null)
				{
					req.CommandId = (PokerCommand)comand;
					req.Player = player;
					//Riješiti da se odmah konektuje
				
					commandSendQueue.Enqueue(req);
				}

				sd = Console.ReadLine();
				DeletePrevConsoleLine();
			}

			CommandRequest req2 = new CommandRequest();
			req2.CommandId = (PokerCommand)Helper.CreateCommand(sd);
			req2.Player = player;
			commandSendQueue.Enqueue(req2);

			t.Run1 = false;
		}

		private static async void CommandListener()
		{
			while (true)
			{
				var t = await commandReceivQueue.DequeueAsync();
				ProcessCommand(t);
			}
		}

		private static void ProcessCommand(CommandReplay message)
		{
			Console.WriteLine();
			Console.WriteLine(message.Command.ToString());
			foreach (Player p in message.Players)
			{
				Console.WriteLine(p.Name + " " + p.Ammount);
			}
		}

		private static void DeletePrevConsoleLine()
		{
			if (Console.CursorTop == 0) return;
			Console.SetCursorPosition(0, Console.CursorTop - 1);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, Console.CursorTop - 1);
		}
	}
}
