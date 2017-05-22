using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Utlis;

namespace Tanks.Actors
{
    class Barrel : MoveableGameObject
    {
        private double _length;

        /// <summary>
        /// Creates barrel with angle set as default to 0
        /// </summary>
        /// <param name="position"></param>
        /// <param name="dimension"></param>
        /// <param name="texture"></param>
        public Barrel(Vector2D position, Dimension dimension, Texture texture) : base(position, new Dimension(dimension.Width,0), texture, Shape.Line)
        {
            _length = dimension.Width;
        }

        public void SetRotation(double angle)
        {
            Dimension = new Dimension(Math.Cos(angle) * _length, Math.Sin(angle) * _length);
        }

        public void Synchronize(MoveableGameObject gameObject)
        {
            Velocity = gameObject.Velocity;
        }
    }
}
