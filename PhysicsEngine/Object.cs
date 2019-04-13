using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine
{
    public class Object
    {
        //Templates
        public class Rectangle : Object
        {
            public Rectangle(PhysicsEngine.Position.Point Position, float Width = 10, float Height = 10, bool hasGravity = true) //: base(Position, Width, Height, hasGravity)
            {
                this.Position = Position;
                this.Width = Width;
                this.Height = Height;
                affectedByGravity = hasGravity;
            }

            public bool Collision(PhysicsEngine.Object.Circle circle)
            {
                PhysicsEngine.Position.Point deltaPos = new Position.Point(Math.Abs(Position.X - circle.Position.X), Math.Abs(Position.Y-circle.Position.Y));

                if (Math.Abs(deltaPos.X - Width / 2) < Math.Abs(circle.Position.X) || Math.Abs(deltaPos.Y - Height / 2) < circle.Position.Y) //the circle is centered at one of the sides
                {
                    if ((Math.Abs(deltaPos.X - Width / 2) < Math.Abs(circle.Position.X) && Math.Abs(deltaPos.Y - Height / 2) < circle.Position.Y))
                    {
                        return true;
                    }
                    return false;
                }

                PhysicsEngine.Position.Point cornerPos = new Position.Point(Height / 2, Width / 2);
                PhysicsEngine.Position.Point deltaPosCorner = deltaPos - cornerPos;
                double deltaHyp = Math.Sqrt(deltaPosCorner.X * deltaPosCorner.X + deltaPosCorner.Y * deltaPosCorner.Y);

                //Gör din collision här
                if (deltaHyp > circle.Radius)
                {
                    return true;
                }
                return false;

                /* going to be used when calculating the outcome (direction of circle)
                PhysicsEngine.Position.Point cornerMod = new Position.Point(1f, 1f);

                if (circle.Position.Y < Position.Y)
                {
                    cornerPos.Y -= Height;
                    cornerMod.Y--;
                }
                if (circle.Position.X < Position.X)
                {
                    cornerPos.X -= Width;
                    cornerMod.X--;
                }*/

                
            }

            public bool Collision(PhysicsEngine.Object.Rectangle rectangle)
            {
                if ((Math.Abs(Position.X - rectangle.Position.X) >= (Width + rectangle.Width)/2) && (Math.Abs(Position.Y - rectangle.Position.Y) >= (Height + rectangle.Height) / 2))
                {
                    return true;
                }
                return false;
            }
        }
        public class Circle : Object
        {
            public float Radius { get; set; }
            public Circle(PhysicsEngine.Position.Point Position, float Radius = 10, bool hasGravity = true) //: base(Position, Width, Height, hasGravity)
            {
                this.Position = Position;
                Width = Radius;
                Height = Radius;
                this.Radius = Radius;
                affectedByGravity = hasGravity;
            }

            public bool Collision(PhysicsEngine.Object.Circle circle)
            {
                    if((Math.Abs(Math.Pow(Position.X - circle.Position.X,2)) + (Math.Abs(Math.Pow(Position.Y - circle.Position.Y, 2))) <= Radius + circle.Radius)){
                    return true;
                    }
                return false;
            }

            public bool Collision(PhysicsEngine.Object.Rectangle rectangle)
            {
                //Gör din collision här
                    if (rectangle.Position.X==1)
                    {
                    return true;
                    }
                return false;
            }
        }

        //Acceleration = 9.82M/s = 9.82M/1000ms => 0.982 M/100ms => 0.0982 M/10ms  => 0.00982 M/1ms

        public PhysicsEngine.Position.Point Position { get; set; }
        public float Mass { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        //public PhysicsEngine.Position.Vector2 Velocity = new PhysicsEngine.Position.Vector2(0, 0);
        //PhysicsEngine.Position.Vector2 Acceleration = new PhysicsEngine.Position.Vector2(0, 0.00982F);
        PhysicsEngine.Position.Vector2 Acceleration = new PhysicsEngine.Position.Vector2(0, 0F);
        PhysicsEngine.Position.Vector2 Velocity = new PhysicsEngine.Position.Vector2(0, 1);

        public bool affectedByGravity { get; set; }

        /*public Object(Point Position, float Width = 10, float Height = 10, bool hasGravity = true)
        {
            this.Position = Position;
            this.Width = Width;
            this.Height = Height;
            affectedByGravity = hasGravity;
        }*/

        public void Gravity()
        {
            Velocity.Y += Acceleration.Y;
        }

        public void Stop()
        {
            Velocity = new PhysicsEngine.Position.Vector2(0, 0);
        }

        public void Move()
        {
            //Position += Velocity;
            Position.Y += Velocity.Y;
            Position.X += Velocity.X;
        }

        public void UpdateObject() //should be called once every 1ms
        {
            if (affectedByGravity)
            {
                Gravity();
            }
            Move();
        }
    }
}
