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

        public float X { get; set; } = 10;
        public float Y { get; set; } = 10;
        public float Width { get; set; } = 10;
        public float Height { get; set; } = 10;

        public Vector2 Velocity = new Vector2(0, 0);
        Vector2 Acceleration = new Vector2(0, 0.00982F);

        public bool affectedByGravity { get; set; }

        public Object(bool affectedByGravity = true)
        {
            affectedByGravity = this.affectedByGravity;
        }

        public void Gravity()
        {
            Velocity.X += Acceleration.X;
            Velocity.Y += Acceleration.Y;

            X += Velocity.X;
            Y += Velocity.Y;
        }

        public void Stop()
        {
            Velocity = new Vector2(0, 0);
        }

        public void Tick() //should be called once every 1ms
        {
            Gravity();
            //Bounce at 100px
            if (Y >= 100)
            {
                Velocity.Y = -Velocity.Y + Velocity.Y / 5;
            }
            //Reset at 100px       
            if (Y >= 500)
            {
                Y = 0;
                Stop();
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
    List<Object> listOfObjects = new List<Object>();

    public PhysicsEngine()
    {
        //Clock();
    }

    public void Clock()
    {
        while (true)
        {
            System.Threading.Thread.Sleep(50);
            foreach (Object o in listOfObjects)
            {
                if (o.affectedByGravity)
                {
                    o.Gravity();
                }
            }
            //Do physics
            //bool done = false;
            //if (done) { break; }
        }
    }
}
