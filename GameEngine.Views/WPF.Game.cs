using GameEngine.Input;
using System.Windows;
using GameEngine;
using System;
using System.Threading;

namespace GameEngine.WPF
{
    public class Game : Window, IGame
    {
        public Thread GameLoopThread
        {
            get; set;
        }

        public ConsoleKey LastKeyPressed
        {
            get; set;
        }
        public Game()
        {
            WindowStyle = WindowStyle.None;
            ((IGame)this).StartGame();
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

    }
}
