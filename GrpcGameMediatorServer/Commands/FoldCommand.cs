using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcGameMediatorServer.Commands
{
	public class FoldCommand : ICommand
	{
		public FoldCommand()
		{ }

		public override void Execute()
		{
			_pokerGame.Fold(_player.Id);
		}
	}
}
