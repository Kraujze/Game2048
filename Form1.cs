using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{ 
    public partial class Form1 : Form
    {
        private int width = 400;
        private int height = 400;
        private int boxWidth;
        private int boxHeight;
        private Box[,] map = new Box[4, 4];
        private Random rnd = new Random();
        private int controls = 0;
        private int startControls = 2;
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(width, height);
            boxWidth = width / 4;
            boxHeight = height / 4;
            spawnEntity();
        }

        private void spawnEntity()
        {
            for (int i = 1; i <= startControls; i++) 
            {
                int tempRndX = rnd.Next(0, 4);
                int tempRndY = rnd.Next(0, 4);
                int tempRndValue = rnd.Next(1, 2) * 2;
                if (map[tempRndX, tempRndY] != null)
                {
                    tempRndX = rnd.Next(0, 4);
                    tempRndY = rnd.Next(0, 4);    
                }

                map[tempRndX, tempRndY] = new Box
                {
                    Text = tempRndValue.ToString(),
                    Location = new Point(tempRndX * boxWidth, tempRndY * boxHeight),
                    Size = new Size(width / 4, height / 4),
                    Score = tempRndValue,
                    Name = $"box{(++controls).ToString()}"
                };
            }
            renderEntity();
        }

        private void moveEntity(String direction)
        {
            switch (direction)
            {
                case "down":
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j <= 3; j++)
                        {
                            if (map[i,j] != null) 
                            {
                                if (map[i + 1, j] == null)
                                {
                                    map[i + 1, j] = map[i, j];
                                    Controls.Remove(map[i, j]);
                                    map[i, j] = null;
                                } else if (map[i + 1, j].Score == map[i, j].Score)
                                {
                                    map[i + 1, j].Score *= 2;
                                    Controls.Remove(map[i, j]);
                                    map[i, j] = null;
                                }
                            }
                        }
                    }
                    
                    break;
            }

            renderEntity();
        }

        public void renderEntity()
        {
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    if (map[i, j] != null)
                    {
                        map[i, j].Location = new Point(j * boxWidth, i * boxHeight);
                        Controls.Add(map[i, j]);
                    }
                }
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            { 
                case "W":
                    moveEntity("up");
                    break;
                case "A":
                    moveEntity("left");
                    break;
                case "S":
                    moveEntity("down");
                    break;
                case "D":
                    moveEntity("right");
                    break;
            }   
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}