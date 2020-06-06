using GrpcGameMediatorServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TexasHoldemPoker;

namespace GrpcGameMediatorServer.Providers
{
	public class GameProvider : IGameProvider
	{

		private List<PokerCommand> _commands;
		PokerCommand _pokerCommand;

		#region Constructor

		public GameProvider()
		{
			_commands = new List<PokerCommand>();
		}

		#endregion

		public void SetCommand(PokerCommand command) => _pokerCommand = command;

		public void Invoke()
		{
			_commands.Add(_pokerCommand);

		}


		private static List<PokerGame> pokerGameList = new List<PokerGame>()
		{
			new PokerGame(1)
		};




		public List<Player> GetAllPlayers()
		{
			try
			{
				PokerGame g = GetPokerGameByID(1);
				var lista = g.PokerTable.listPlayers.ToList();

				List<Player> l = new List<Player>();
				foreach (TexasHoldemPoker.Player p in lista)
				{
					Player pl = new Player();
					pl.Id = p.Id;
					pl.Name = p.Name; 
					pl.Ammount = p.Amount;

					l.Add(pl);
				}

				return l;
			}
			catch (Exception ex)
			{ return null; }
		}

		public PokerGame GetPokerGameByID(int gameId)
		{
			return pokerGameList.FirstOrDefault(x => x.ID == gameId);
		}
	}
}
