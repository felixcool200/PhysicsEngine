using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine
{
    class EngineCore
    {
        //Enigne
        public List<Object> Objects = new List<Object>();

        System.Threading.Thread PhysicsEngineClockThread;

        public EngineCore()
        {
            PhysicsEngineClockThread = new System.Threading.Thread(new System.Threading.ThreadStart(Timer));
            PhysicsEngineClockThread.Start();
        }

        public void StartEngine()
        {
            PhysicsEngineClockThread.Start();
        }

        public void StopEngine()
        {
            PhysicsEngineClockThread.Abort();
        }

        public void Timer()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(10);
                EngineUpdate();
            }
        }

        public void EngineUpdate()
        {
            foreach (Object @object in Objects)
            {
                @object.UpdateObject();
            }
        }
    }
}
