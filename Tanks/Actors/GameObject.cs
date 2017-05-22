using System;
using System.Collections.Generic;
using Tanks.Utlis;

namespace Tanks.Actors
{
    class GameObject
    {
        public Vector2D Position { get; protected set; }
        public Dimension Dimension { get; protected set; }
        public Texture Texture { get; }
        public Shape Shape { get; }

        public IList<GameObject> Children { get; private set; } = new List<GameObject>();

        public GameObject(Vector2D position, Dimension dimension, Texture texture, Shape shape)
        {
            Position = position;
            Dimension = dimension;
            Texture = texture;
            Shape = shape;
        }

        public void AddChild(GameObject obj)
        {
            Children.Add(obj);
        }
    }
}
