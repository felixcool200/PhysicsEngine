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
        PhysicsEngine.Object o = new PhysicsEngine.Object();
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, o.X, o.Y, o.Width, o.Height);
            e.Graphics.DrawString(o.Velocity.Y.ToString(), SystemFonts.MenuFont, Brushes.Black, 200, 10);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            o.Tick();
            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled)
            {
                button1.Text = "Pause";
            }
            else
            {
                button1.Text = "Test Gravity";
            }
            MessageBox.Show(Math.Round(o.Velocity.Y, 7).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            o = new PhysicsEngine.Object();
            Invalidate();
        }
    }
}
