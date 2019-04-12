using System;

namespace PhysicsEngineDOTNETCORE
{
    class Program
    {
        static void Main(string[] args)
        {
            PhysicsEngine.EngineCore EC = new PhysicsEngine.EngineCore();
            Console.WriteLine(EC.PhysicsEngineClockThread.IsAlive.ToString());
            EC.StartEngine();
            Console.WriteLine(EC.PhysicsEngineClockThread.IsAlive.ToString());
            
            EC = new PhysicsEngine.EngineCore();
            Console.WriteLine(EC.PhysicsEngineClockThread.IsAlive.ToString());
            Console.WriteLine("Done");
        }
    }
}
