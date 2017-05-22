using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Actors;
using Tanks.Drawing;
using Tanks.Utlis;

namespace Tanks.Logic
{
    class TanksGame
    {
        private List<Tank> _tanks;
        private Rocket _rocket;
        private Board _board;
        
        private State _state;
        private GameObjectDrawer _gameObjectDrawer;

        Stopwatch stopwatch = new Stopwatch();

        public TanksGame(GameObjectDrawer gameObjectDrawer)
        {
            _gameObjectDrawer = gameObjectDrawer;
        }

        public void Initialize()
        {
            _tanks = new List<Tank>();
            var tank1 = new Tank(new Vector2D(0.1, 0.8), new Dimension(0.15, 0.1), Texture.Green);
            var tank2 = new Tank(new Vector2D(0.8, 0.8), new Dimension(0.15, 0.1), Texture.Red);

            tank1.FireEvent += Tank1_FireEvent;

            _tanks.Add(tank1);
            _tanks.Add(tank2);
        }

        private void Tank1_FireEvent()
        {
            _rocket.Launch();
        }

        public void Draw(Graphics g)
        {
            DrawTanks(g, _gameObjectDrawer);

            switch (_state)
            {
                case State.Aim:
                    break;
                case State.Shoot:
                    break;
                case State.Hit:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void DrawTanks(Graphics g, GameObjectDrawer gameObjectDrawer)
        {
            foreach (var tank in _tanks)
            {
                gameObjectDrawer.DrawGameObject(g, tank);
            }
        }

        public void Tick()
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();
                return;
            }


            var tick = stopwatch.ElapsedMilliseconds;

            foreach (var tank in _tanks)
            {
                tank.Update((double)tick / 1000);
            }

            stopwatch.Restart();
        }

        public void KeyPress(char c)
        {
            c = Char.ToLower(c);
            if (c == 's')
            {
                _tanks[0].Move(Direction.Right);
            }
            if (c == 'a')
            {
                _tanks[0].Move(Direction.Left);
            }

            if (c == 'e')
            {
                _tanks[0].MoveAngle(Direction.Up);
            }

            if (c == 'd')
            {
                _tanks[0].MoveAngle(Direction.Down);
            }
        }
    }
}
