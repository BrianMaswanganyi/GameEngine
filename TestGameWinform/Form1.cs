using GameEngine.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestGameWinform
{
    public partial class Form1 : Game
    {
        public Form1()
            :base()
        {
            InitializeComponent();

            this.Load += new System.EventHandler(this.Form1_Load);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
