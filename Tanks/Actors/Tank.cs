using System;
using Tanks.Utlis;

namespace Tanks.Actors
{
    class Tank : MoveableGameObject
    {
        private Barrel _barrel;
        private double _angle;
        public event Action FireEvent;

        public Tank(Vector2D position, Dimension dimension, Texture texture) : base(position, dimension, texture, Shape.FillRect)
        {
            _barrel = new Barrel(new Vector2D(position.X + dimension.Width / 2, position.Y),
                new Dimension(dimension.Width / 2, 0), texture);
            AddChild(_barrel);

            SetAngle(Math.PI / 3);
        }

        public void MoveAngle(Direction direction)
        {
            if (direction == Direction.Up)
            {
                SetAngle(_angle + Math.PI / 20);
            }

            if (direction == Direction.Down)
            {
                SetAngle(_angle - Math.PI / 20);
            }
        }

        private void SetAngle(double angle)
        {
            _angle = angle;
            _barrel.SetRotation(-_angle);
        }

        public void Move(Direction direction)
        {
            if (direction == Direction.Left)
            {
                Velocity = new Vector2D(-0.1, 0);
            }
            if (direction == Direction.Right)
            {
                Velocity = new Vector2D(0.1, 0);
            }

            _barrel.Synchronize(this);
        }

        public override void Update(double tick)
        {
            base.Update(tick);
            Velocity = new Vector2D(0, 0);
            _barrel.Synchronize(this);
        }

        public void Fire()
        {
            OnFireEvent();
        }

        protected virtual void OnFireEvent()
        {
            FireEvent?.Invoke();
        }
    }
}
