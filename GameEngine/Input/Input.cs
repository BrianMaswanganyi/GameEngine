using System;
namespace GameEngine.Input
{
    public class Input
    {
        public static bool Key(ConsoleKey checkkey)
        {
            return checkkey == Debug.lastKeyPressed;   
        }
    }
}
