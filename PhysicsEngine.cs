using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngineWinForm
{
    class PhysicsEngine
    {
        public PhysicsEngine()
        {
            Clock();
        }

        public void Clock()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(50);
                //Do physics
                bool done = false;
                if (done) { break; }
            }
        }
    }
}
