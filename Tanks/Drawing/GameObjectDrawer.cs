using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Actors;
using Tanks.Utlis;

namespace Tanks.Drawing
{
    class GameObjectDrawer
    {
        private readonly Dimension _windowSize;

        public GameObjectDrawer(Dimension windowSize)
        {
            _windowSize = windowSize;
        }

        public void DrawGameObject(Graphics graphics, GameObject gameObject)
        {
            switch (gameObject.Shape)
            {
                case Shape.FillRect:
                    graphics.FillRectangle(GetBrush(gameObject), ConvertToRectangle(gameObject));
                    break;
                case Shape.FillEllipse:
                    graphics.FillEllipse(GetBrush(gameObject), ConvertToRectangle(gameObject));
                    break;
                case Shape.Line:
                    {
                        var rect = ConvertToRectangle(gameObject);
                        graphics.DrawLine(GetPen(gameObject), rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            foreach (var moveableGameObject in gameObject.Children)
            {
                DrawGameObject(graphics, moveableGameObject);
            }
        }

        private static Color GetColor(GameObject gameObject)
        {
            switch (gameObject.Texture)
            {
                case Texture.Red:
                    return Color.Red;
                case Texture.Green:
                    return Color.Green;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static Pen GetPen(GameObject gameObject)
        {
            return new Pen(GetColor(gameObject));
        }

        private static Brush GetBrush(GameObject gameObject)
        {
            return new SolidBrush(GetColor(gameObject));
        }

        private Rectangle ConvertToRectangle(GameObject gameObject)
        {
            return new Rectangle((int)Math.Round(gameObject.Position.X * _windowSize.Width),
                (int)Math.Round(gameObject.Position.Y * _windowSize.Height),
                (int)Math.Round(gameObject.Dimension.Width * _windowSize.Width),
                (int)Math.Round(gameObject.Dimension.Height * _windowSize.Height));
        }
    }
}
