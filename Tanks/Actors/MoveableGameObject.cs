using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Utlis;

namespace Tanks.Actors
{
    class MoveableGameObject : GameObject
    {
        public Vector2D Velocity { get; protected set; }
        public Vector2D Acceleration { get; protected set; }

        public MoveableGameObject(Vector2D position, Dimension dimension, Texture texture, Shape shape) : base(position, dimension, texture, shape)
        {
            Velocity = new Vector2D(0, 0);
            Acceleration = new Vector2D(0, 0);
        }

        public virtual void Update(double tick)
        {
            Position = Position.Shift(Velocity.X * tick, Velocity.Y * tick);
            Velocity = Velocity.Shift(Acceleration.X * tick, Acceleration.Y * tick);

            foreach (var child in Children.OfType<MoveableGameObject>())
            {
                child.Update(tick);
            }
        }
    }
}
