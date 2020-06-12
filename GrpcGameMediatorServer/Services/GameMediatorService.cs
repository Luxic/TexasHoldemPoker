using Grpc.Core;
using GrpcGameMediatorServer.Commands;
using GrpcGameMediatorServer.Models;
using GrpcGameMediatorServer.Providers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TexasHoldemPoker;

namespace GrpcGameMediatorServer.Services
{
	public class GameMediatorService : IGameMediatorService
	{
		private readonly IGameProvider _gameProvider;
		private static IDictionary<int, PlayerStream> playerStreamlist;

		#region Constructor
		public GameMediatorService(IGameProvider gameProvider)
		{
			_gameProvider = gameProvider;
			playerStreamlist = new Dictionary<int, PlayerStream>();
		}

		#endregion

		private CommandReplay GenerateCommandReplay(PokerCommand command)
		{
			var list = _gameProvider.GetAllPlayers();

			CommandReplay commandReplay = new CommandReplay();
			commandReplay.Command = command;
			commandReplay.Players.AddRange(list);

			return commandReplay;
		}

		public async Task BroadcastCommandAsync(CommandRequest command)
		{
			try
			{
				CommandReplay com = GenerateCommandReplay(command.CommandId);
				var list = _gameProvider.GetAllPlayers();

				foreach (var player in list)
				{
					await playerStreamlist[player.Id].Stream.WriteAsync(com);
				}
			}
			catch (Exception ex)
			{ }
		}

		public void DisconnectPlayer(int GameId, int customerId)
		{
			_gameProvider.GetPokerGameByID(1).RemovePlayer(customerId);
		}

		public void SetCommand(CommandRequest commandRequest)
		{
			ICommand command = CommandFactory.GetCommand(commandRequest);
			command.PokerGame = _gameProvider.GetPokerGameByID(1);
			command.Player = commandRequest.Player;

			if (command is RemovePlayerCommand)
				playerStreamlist.Remove(commandRequest.Player.Id);

			command.Execute();
		}

		#region Methods

		public CommandReplay RegisterPlayerToGame(Player customer)
		{
			TexasHoldemPoker.Player player = new TexasHoldemPoker.Player(customer.Name);
			player.Id = customer.Id;
			player.Name = customer.Name;
			player.Amount = customer.Ammount;

			playerStreamlist.Add(customer.Id, new PlayerStream(player));

			PokerGame pokerGame = _gameProvider.GetPokerGameByID(1);
			pokerGame.AddPlayer(player);

			return GenerateCommandReplay(PokerCommand.NewPlayer);
		}

		public void ConnectPlayerStream(int PlayerId, IAsyncStreamWriter<CommandReplay> stream)
		{
			playerStreamlist[PlayerId].Stream = stream;
		}

		#endregion
	}
}
