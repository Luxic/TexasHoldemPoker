using Grpc.Core;
using Grpc.Net.Client;
using GrpcGameMediatorServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WinPokerClient
{
	public class gRpcServiceThread
	{
		GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");

		Player player;

		AsyncQueue<CommandReplay> receiverQueue;
		AsyncQueue<CommandRequest> sendQueue;

		bool run = true;

		public gRpcServiceThread(AsyncQueue<CommandReplay> q, AsyncQueue<CommandRequest> q2)
		{
			receiverQueue = q;
			sendQueue = q2;
		}

		public bool Run1 { get => run; set => run = value; }

		public void Add(Player p)
		{
			AddPlayerRequest addPlayerRequest = new AddPlayerRequest();
			addPlayerRequest.Player = p;

			var client = new PlayerService.PlayerServiceClient(channel);
			client.AddPlayerToGame(addPlayerRequest);
			//receiverQueue.Enqueue(commandReply);
		}

		public async Task Run()
		{

			using (var duplex = new PlayerService.PlayerServiceClient(channel).SendPlayerCommand())
			{
				var responseTask = Task.Run(async () =>
				{
					while (await duplex.ResponseStream.MoveNext(CancellationToken.None))
					{
						receiverQueue.Enqueue(duplex.ResponseStream.Current);
					}
				});

				while (Run1)
				{
					var ret = await sendQueue.DequeueAsync();					
					
					await duplex.RequestStream.WriteAsync(ret);
				}

				await duplex.RequestStream.CompleteAsync();
			}
		}

		internal void Exit()
		{
			throw new NotImplementedException();
		}
	}
}
