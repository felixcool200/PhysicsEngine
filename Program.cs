using System;

namespace PhysicsEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            PhysicsEngine.EngineCore EC = new PhysicsEngine.EngineCore();
            Console.WriteLine(EC.PhysicsEngineClockThread.IsAlive.ToString());
            EC.StartEngine();
            Console.WriteLine(EC.PhysicsEngineClockThread.IsAlive.ToString());
            EC.Objects.Add();
            bool isOn = true;
            while(inOn){
                foreach(PhysicsEngine.Object c in EC.Objects){
                    Console.Write(c.Position.X);
                }
            }
            //The .Net core way of disabling a thread(i think)
            EC = new PhysicsEngine.EngineCore();
            Console.WriteLine(EC.PhysicsEngineClockThread.IsAlive.ToString());
            Console.WriteLine("Done");
        }
    }
}
