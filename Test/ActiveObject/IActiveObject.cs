using System;
using System.Collections.Generic;
using System.Text;

namespace Test.ActiveObject
{
	public interface IActiveObject
	{
        void Initialize(string name, Action action); 
        void Signal(); 
        void Shutdown();
    }
}
