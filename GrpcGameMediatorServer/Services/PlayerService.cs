using Grpc.Core;
using GrpcGameMediatorServer.Services;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace GrpcGameMediatorServer
{
	public class GameService : PlayerService.PlayerServiceBase
	{
		private readonly ILogger<GameService> _logger;

		private readonly IGameMediatorService _gameMediatorService;

		public GameService(ILogger<GameService> logger, IGameMediatorService gameMediatorService)
		{
			_logger = logger;
			_gameMediatorService = gameMediatorService;
		}

		public override Task<CommandReplay> AddPlayerToGame(AddPlayerRequest request, ServerCallContext context)
		{
			return Task.FromResult(_gameMediatorService.RegisterPlayerToGame(request.Player));
		}

		public override async Task SendPlayerCommand(IAsyncStreamReader<CommandRequest> playerStream, IServerStreamWriter<CommandReplay> playerCommandStream, ServerCallContext context)
		{
			var httpContext = context.GetHttpContext();

			if(!await playerStream.MoveNext())
				return;
			
			_gameMediatorService.ConnectPlayerStream(playerStream.Current.Player.Id, playerCommandStream);

			try
			{
				while (await playerStream.MoveNext())
				{
					_gameMediatorService.SetCommand(playerStream.Current);
					await _gameMediatorService.BroadcastCommandAsync(playerStream.Current);
				}
			}
			catch (IOException)
			{ }

		}
	}
}
