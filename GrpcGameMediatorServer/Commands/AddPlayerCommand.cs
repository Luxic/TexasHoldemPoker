using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokerPlayer = TexasHoldemPoker.Player;

namespace GrpcGameMediatorServer.Commands
{
	public class AddPlayerCommand : ICommand
	{
		public override void Execute()
		{
			PokerPlayer p = new PokerPlayer();
			p.Id = _player.Id;
			p.Name = _player.Name;
			p.Amount = _player.Ammount;

			_pokerGame.AddPlayer(p);
		}
	}
}
