using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanks.Drawing;
using Tanks.Logic;
using Tanks.Utlis;

namespace Tanks
{
    public partial class Form1 : Form
    {
        private TanksGame _tanksGame;

        public Form1()
        {
            InitializeComponent();

            SetStyle(
            ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.DoubleBuffer, true);

            Timer GameTimer = new Timer();
            GameTimer.Interval = 33;
            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Start();

            Paint += Form1_Paint;

            KeyDown += Form1_KeyDown;
            _tanksGame = new TanksGame(new GameObjectDrawer(new Dimension(ClientSize.Width, ClientSize.Height)));
            _tanksGame.Initialize();
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _tanksGame.KeyPress((char)e.KeyValue);
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            _tanksGame.Draw(e.Graphics);
        }

        void GameTimer_Tick(object sender, EventArgs e)
        {
            _tanksGame.Tick();
            Invalidate();
        }
    }
}
