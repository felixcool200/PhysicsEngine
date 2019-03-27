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
        PhysicsEngine PE = new PhysicsEngine();
        public Form1()
        {
            InitializeComponent();
            Random r = new Random();
            int lowerLimit = 0;
            int higerLimit = 200;
            for(int i = 0; i < 10; i++)
            {
                PE.Objects.Add(new PhysicsEngine.Object(r.Next(lowerLimit, higerLimit), r.Next(lowerLimit, 10), 10, 10, true));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach(PhysicsEngine.Object o in PE.Objects)
            {
                e.Graphics.FillEllipse(Brushes.Red, o.X, o.Y, o.Width, o.Height);
                e.Graphics.DrawString(o.Velocity.Y.ToString(), SystemFonts.MenuFont, Brushes.Black, 200, 10);
                e.Graphics.DrawLine(Pens.Black, 0, 100 + o.Height, 100, 100 + o.Height);
            }
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
