using GameEngine.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace GameEngine
{
    public interface IGame
    {
        Thread GameLoopThread { get; set; }
        ConsoleKey LastKeyPressed { get; set; }
        GameObjectCollection GameObjects { get; set; }
        bool ExitGame { get; set; }
        KeyBoardInput keyboardInput { get; set; }

    }
}
