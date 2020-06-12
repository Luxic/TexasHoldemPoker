using Grpc.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrpcGameMediatorServer.Services
{
	public interface IGameMediatorService
	{
		Task BroadcastCommandAsync(CommandRequest command);
		CommandReplay RegisterPlayerToGame(Player customer);
		void DisconnectPlayer(int GameId, int customerId);
		void SetCommand(CommandRequest current);
		void ConnectPlayerStream(int PlayerId, IAsyncStreamWriter<CommandReplay> stream);
	}
}
