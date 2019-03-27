using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhysicsEngineWinForm
{
    public partial class Form1 : Form
    {
        PhysicsEngine.EngineCore PE = new PhysicsEngine.EngineCore();
        public Form1()
        {
            InitializeComponent();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                PE.Objects.Add(new PhysicsEngine.Object.Circle(new PhysicsEngine.Position.Point(r.Next(10, 100), r.Next(0, 1)), 10, true));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (PhysicsEngine.Object o in PE.Objects)
            {
                e.Graphics.FillEllipse(Brushes.Red, o.Position.X - o.Width / 2, o.Position.Y - o.Height / 2, o.Width, o.Height);
                e.Graphics.FillEllipse(Brushes.Black, o.Position.X - o.Width / 2, o.Position.Y - o.Height / 2, 1, 1);
                e.Graphics.DrawString(o.Velocity.Y.ToString(), SystemFonts.MenuFont, Brushes.Black, 200, 10);
            }
            e.Graphics.DrawLine(Pens.Black, 0, 100, 100, 100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PE.StopEngine();
            Application.Exit();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
