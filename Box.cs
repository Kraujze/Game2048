using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    public class Box : Control
    {
        public int BORDER_SIZE = 6;
        private ContentAlignment alignmentValue = ContentAlignment.MiddleCenter;

        public Font Font { get; set; } = new Font("Segoe UI", 15);
        /*public int Score { 
            get { return Score; }
            set { 
                Score = value;
                Text = value.ToString();
            }
        }*/
        public int Score;
        public Box()
        {

        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Text = Score.ToString();
            StringFormat style = new StringFormat();
            style.Alignment = StringAlignment.Center;
            switch (alignmentValue)
            {
                case ContentAlignment.MiddleLeft:
                    style.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    style.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleCenter:
                    style.Alignment = StringAlignment.Center;
                    break;
            }
            
            e.Graphics.DrawString(
                Text,
                Font,
                new SolidBrush(ForeColor),
                new Rectangle(0,(int) (Width / 2 - Font.Size),Width,(int) (Font.Size * 2)), style);
            ControlPaint.DrawBorder(e.Graphics, new Rectangle(0,0,Width,Height),
                Color.Gray, BORDER_SIZE, ButtonBorderStyle.Solid,
                Color.Gray, BORDER_SIZE, ButtonBorderStyle.Solid,
                Color.Gray, BORDER_SIZE, ButtonBorderStyle.Solid,
                Color.Gray, BORDER_SIZE, ButtonBorderStyle.Solid);

        }
    }
}