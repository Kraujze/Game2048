using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{ 
    public partial class Form1 : Form
    {
        public int width { get; private set; }
        public int height { get; private set; }
        
        public Form1()
        {
            InitializeComponent();
        }
        
        public void addElement()
        {
            this.Controls.Add(new Label()
            {
                Text = "test",
                Location = new Point(200,200)
            });    
        }
    }
}