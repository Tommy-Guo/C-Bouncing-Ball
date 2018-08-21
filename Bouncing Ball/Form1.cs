using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bouncing_Ball {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }  

        private void button1_Click(object sender, EventArgs e) {
            if (WorldTimer.Enabled) {
                WorldTimer.Enabled = false;
            } else {
                WorldTimer.Enabled = true;
            }
        }

        private void WorldTimer_Tick(object sender, EventArgs e) {
            world1.Invalidate();
        }
    }
}

public class World : Control
{
    private Vector Ball = new Vector(200, 200);
    private Vector speed = new Vector(2, 5);

    public World()
    {
        DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        g.Clear(Color.White);

        update();
        g.FillEllipse(Brushes.Red, new Rectangle((int)Ball.x, (int)Ball.y, 50, 50));
        g.DrawEllipse(new Pen(Brushes.Black, 2), new Rectangle((int)Ball.x, (int)Ball.y, 50, 50));
    }

    public void update()
    {
        Ball = Ball.add(speed);
        if ((Ball.x > Width - 50) | (Ball.x < 50))
            speed.x = speed.x * -1;
        if ((Ball.y > Height - 50) | (Ball.y < 50))
            speed.y = speed.y * -1;
    }
}

public class Vector
{
    public double x;
    public double y;

    public Vector(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public double magnitude()
    {
        return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
    }


    public Vector add(Vector v1)
    {
        return new Vector(x + v1.x, y + v1.y);
    }
    public Vector add(Vector v1, Vector v2)
    {
        return new Vector(v1.x + v2.x, v1.y + v2.y);
    }
}
