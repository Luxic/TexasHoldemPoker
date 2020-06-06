using Grpc.Core;

namespace GrpcGameMediatorServer.Models
{
	public class PlayerStream
	{
		int id;
		public IAsyncStreamWriter<CommandReplay> Stream { get; set; }

		TexasHoldemPoker.Player player;

		public PlayerStream(TexasHoldemPoker.Player player)
		{
			this.player = player;
			id = player.Id;
		}

		public int Id { get => id; set => id = value; } 
	}
}
