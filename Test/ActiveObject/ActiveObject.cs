using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Test.ActiveObject
{
	public class ActiveObject : IActiveObject
	{
		string m_Name;
		Thread m_ActiveThreadContext;
		Action m_ActiveAction;
		AutoResetEvent m_SignalObject;
		ManualResetEvent m_ShutdownEvent;
		WaitHandle[] m_SignalObjects;

        public void Initialize(string name, Action action)
        {
            m_Name = name;
            m_ActiveAction = action;
            m_SignalObject = new AutoResetEvent(false);
            m_ShutdownEvent = new ManualResetEvent(false);
            m_SignalObjects = new WaitHandle[]
                                {
                                    m_ShutdownEvent,
                                    m_SignalObject
                                };

            m_ActiveThreadContext = new Thread(Run);
            m_ActiveThreadContext.Name = string.Concat("ActiveObject.", m_Name);
            m_ActiveThreadContext.Start();
        }

        private void Run(object obj)
        {

            try
            {
                while (Guard())
                {
                    try
                    {
                        m_ActiveAction();
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                m_SignalObject.Close();
                m_ShutdownEvent.Close();

                m_SignalObject = null;
                m_ShutdownEvent = null;
            }
        }
    

        private bool Guard()
        {
            int index = WaitHandle.WaitAny(m_SignalObjects);
            return index == 0 ? false : true;
        }

        /// <summary>
        /// Signal the active object to perform its loop action.
        /// </summary>
        /// <remarks>
        /// Application may call this after some simple of complex condition evaluation
        /// </remarks>
        public void Signal()
        {
            m_SignalObject.Set();
        }

        /// <summary>
        /// Signals to shotdown this active object
        /// </summary>
        public void Shutdown()
        {
            m_ShutdownEvent.Set();

            if (m_ActiveThreadContext != null)
            {
                m_ActiveThreadContext.Join();
            }

            m_ActiveThreadContext = null;
        }



    }
}
