using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LissajouFigures
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Это PictureBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drawingPlace_Click(object sender, EventArgs e)
        {
            var pointsList = new List<PointF>();
            var t_max = 10.0;
            var x_angle = 0.0;
            var y_angle = 0.0;
            var x_freq = 1.0;
            var y_freq = 2.0;
            var x_amp = 100.0;
            var y_amp = 100.0;
            var screen_width_center = this.Width / 2;
            var screen_height_center = this.Height / 2;
            var blackPen = Pens.Black;
            if (checkBox1.Checked == false)
            {
                for (var t = 0.0; t <= t_max; t += Math.PI / 360)
                {
                    //Сразу рисует 
                    var x = (screen_width_center + Convert.ToSingle(x_amp * Math.Sin(x_freq * t + x_angle)));
                    var y = (screen_height_center + Convert.ToSingle(y_amp * Math.Sin(y_freq * t + y_angle)));
                    pointsList.Add(new PointF(x, y));
                }
                Bitmap plane = new Bitmap(drawingPlace.Width, drawingPlace.Height);
                var drawArea = Graphics.FromImage(plane);
                drawArea.DrawLines(blackPen, pointsList.ToArray());
                drawingPlace.Image = plane;
                pointsList.Clear();
            }
            else
            {
                for (var t = 0.0; t <= t_max; t += Math.PI / 360)
                {
                    //Рисует постепенно 
                    var x = (screen_width_center + Convert.ToSingle(x_amp * Math.Sin(x_freq * t + x_angle)));
                    var y = (screen_height_center + Convert.ToSingle(y_amp * Math.Sin(y_freq * t + y_angle)));
                    pointsList.Add(new PointF(x, y));
                    var arr = pointsList.ToArray();
                    if (arr.Length > 1)
                    {
                        using (Bitmap plane = new Bitmap(drawingPlace.Width, drawingPlace.Height))
                        {
                            using (var drawArea = Graphics.FromImage(plane))
                            {
                                drawArea.DrawLines(blackPen, arr);
                            }
                            drawingPlace.Image = plane;
                            drawingPlace.Refresh();
                        }
                    }
                }
                pointsList.Clear();
            }
        }
    }
}
