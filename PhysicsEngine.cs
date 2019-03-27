using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PhysicsEngine
{
    //Classes
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
    public class Object
    {
        //Acceleration = 9.82M/s = 9.82M/1000ms => 0.982 M/100ms => 0.0982 M/10ms  => 0.00982 M/1ms

        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public Vector2 Velocity = new Vector2(0, 0);
        Vector2 Acceleration = new Vector2(0, 0.00982F);

        public bool affectedByGravity { get; set; }
     
        public Object(float X = 10, float Y = 10, float Width = 10, float Height = 10, bool hasGravity = true)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            affectedByGravity = hasGravity;
        }

        public void Gravity()
        {
            //Velocity.X += Acceleration.X;
            Velocity.Y += Acceleration.Y;

            //X += Velocity.X;
            Y += Velocity.Y;
        }

        public void ApplyForces()
        {

        }

        public void Stop()
        {
            Velocity = new Vector2(0, 0);
        }

        public void Tick() //should be called once every 1ms
        {
            if (affectedByGravity)
            {
                Gravity();
            }
            //Bounce at 100px
            if (Y >= 100)
            {
                Velocity.Y = -Velocity.Y + Velocity.Y / 5;
            }
            //Makeing it stop when laying on the "floor"
            if (Math.Round(Velocity.Y, 7) == -0.0043644)
            {
                Acceleration.Y = 0;
                Velocity.Y = 0;
            }
        }
    }

    //Enigne
    public List<Object> Objects = new List<Object>();

    System.Threading.Thread PeT;

    public PhysicsEngine()
    {
        PeT = new System.Threading.Thread(new System.Threading.ThreadStart(Clock));
        PeT.Start();
    }
    public void StartEngine()
    {
        PeT.Start();
    }

    public void StopEngine()
    {
        PeT.Abort();
    }

    public void Clock()
    {
        while (true)
        {
            System.Threading.Thread.Sleep(10);
            foreach (Object o in Objects)
            {
                o.Tick();
            }
            //Do physics
            //bool done = false;
            //if (done) { break; }
        }
    }
}
