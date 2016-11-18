using System.Windows.Forms;
using GameEngine.Input;
using GameEngine;
using System;
using System.Threading;

namespace GameEngine.Views
{
    public class Game : Form, IGame
    {
        public Thread GameLoopThread
        {
            get; set;
        }

        public ConsoleKey LastKeyPressed
        {
            get; set;
        }
        public bool ExitGame
        {
            get; set;
        }

        public GameObjectCollection GameObjects
        {
            get; set;
        }

        public KeyBoardInput keyboardInput
        {
            get; set;
        }

        public void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Game
            // 
            this.ClientSize = new System.Drawing.Size(730, 639);
            this.ControlBox = false;
            this.Name = "Game";
            this.ResumeLayout(false);

            ((IGame)this).StartGame();
        }


    }
}
