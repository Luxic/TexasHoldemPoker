using GrpcGameMediatorServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TexasHoldemPoker;

namespace GrpcGameMediatorServer.Providers
{
	public interface IGameProvider
	{
		PokerGame GetPokerGameByID(int gameId);
		List<Player> GetAllPlayers();
	}
}
