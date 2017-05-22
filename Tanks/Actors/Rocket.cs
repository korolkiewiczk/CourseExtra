using Tanks.Utlis;

namespace Tanks.Actors
{
    class Rocket : GameObject
    {
        public Rocket(Vector2D position, Dimension dimension, Texture texture) : base(position, dimension, texture, Shape.FillEllipse)
        {
        }

        public void Launch()
        {

        }
    }
}