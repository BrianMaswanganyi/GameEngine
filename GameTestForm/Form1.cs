using GameEngine;
using GameEngine.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameTestForm
{
    public partial class Form1 : Form, IGame
    {
        public GameObjectCollection GameObjects { get; set; }
        public bool ExitGame { get; set; }
        public KeyBoardInput keyboardInput { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Start();
        }
    }
}
