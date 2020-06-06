using System;
using Test.ActiveObject;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{

			EntityAgent e = new EntityAgent();
			e.Initialize();
			e.SomeComplexConditionEvaluation();

			Console.ReadLine();
		}


	 

		#region delegate
		public void DelegateFunc()
		{
			PokerDelegate del = new PokerDelegate(ProccessMessage);
			clsDelegate d = new clsDelegate(del);
			d.StartGame();
		}

		private static string ProccessMessage(string message)
		{
			Console.WriteLine(message);

			return "";
		}
		#endregion
	}

	#region ActiveObject

	public class EntityAgent
	{
		private IActiveObject m_PickupActiveObject;

		public EntityAgent()
		{
			m_PickupActiveObject = new ActiveObject.ActiveObject();
		}

		public void Initialize()
		{
			m_PickupActiveObject.Initialize("Pickup", TryPickupInternalAsync);
		}

		public void SomeComplexConditionEvaluation()
		{
			m_PickupActiveObject.Signal();
		}

		private void TryPickupInternalAsync()
		{
			Console.WriteLine("TryPickupInternalAsync");
		}
	}

	#endregion


}
