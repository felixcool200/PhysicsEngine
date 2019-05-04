using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine
{
    class Program
    {
         static readonly int screenWidth = 100;
         static readonly int screenHeight = 70;
        static char[,] screen = new char[screenWidth,screenHeight];

        static void Main(string[] args)
        {
            PhysicsEngine.EngineCore EC = new PhysicsEngine.EngineCore();
            GenerateScreen();
            Console.WriteLine(EC.PhysicsEngineClockThread.IsAlive.ToString());
            EC.StartEngine();
            Console.WriteLine(EC.PhysicsEngineClockThread.IsAlive.ToString());           
            GenerateExampleObjects(10,EC.Objects);
            int n = 0;
            //We need a better drawing algoritm so that it doesn't just blink :P
            while(n < 10000)
            {   
                PrintObjects(EC.Objects,screen);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                n++;
            }
                
            //The .Net core way of disabling a thread(i think)
            EC = new PhysicsEngine.EngineCore();
            Console.WriteLine(EC.PhysicsEngineClockThread.IsAlive.ToString());
            Console.WriteLine("Done");
            //Environment.Exit(-1);
        }

        static void GenerateScreen(){
            for(int i = 0; i < screenHeight; i++){
                for(int j = 0; j < screenWidth; j++){
                screen[j,i] = ' ';
                }
            }
        }

        static void PrintObjects(List<PhysicsEngine.Object> o, char[,] screen){
        foreach(PhysicsEngine.Object c in o){
            if(c.Position.X < screenWidth && c.Position.Y < screenHeight){
                if(c is PhysicsEngine.Object.Circle){
                    screen[int.Parse(c.Position.X.ToString()),int.Parse(c.Position.Y.ToString())] = '○';}
                else if(c is PhysicsEngine.Object.Rectangle){
                    screen[int.Parse(c.Position.X.ToString()),int.Parse(c.Position.Y.ToString())] = '☐';}
            }}
             for(int i = 0; i < screenHeight; i++){
                for(int j = 0; j < screenWidth; j++){
                    Console.Write(screen[j,i]);
                }
                Console.WriteLine("");
            }             
        }

        static void GenerateExampleObjects(int numberOfObjects, List<PhysicsEngine.Object> listToStoreObjects){
            Random r = new Random();
            for(int i = 0;i < numberOfObjects/2; i++){
            listToStoreObjects.Add(new PhysicsEngine.Object.Circle(new PhysicsEngine.Position.Point(r.Next(1,screenWidth),r.Next(1,screenHeight)),1,true));
            }
            for(int i = 0;i < numberOfObjects/2; i++){
            listToStoreObjects.Add(new PhysicsEngine.Object.Rectangle(new PhysicsEngine.Position.Point(r.Next(1,screenWidth),r.Next(1,screenHeight)),1,1,true));
            }
        }
    }
}
