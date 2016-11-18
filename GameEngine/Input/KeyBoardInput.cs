using System;

namespace GameEngine.Input
{
    public class KeyboardEventArgs : EventArgs
    {
        public int Key { get; internal set; }
    }
    public class KeyBoardInput : IDisposable
    {
        public event EventHandler<KeyboardEventArgs> KeyBoardKeyPressed;

        private WindowsHookHelper.HookDelegate keyBoardDelegate;
        private IntPtr keyBoardHandle;
        private const Int32 WH_KEYBOARD_LL = 13;
        private bool disposed;



        public KeyBoardInput()
        {
            keyBoardDelegate = KeyboardHookDelegate;
            keyBoardHandle = WindowsHookHelper.SetWindowsHookEx(WH_KEYBOARD_LL, keyBoardDelegate, IntPtr.Zero, 0);

            KeyBoardKeyPressed += KeyboardInput_KeyBoardKeyPressed;
        }

        private void KeyboardInput_KeyBoardKeyPressed(object sender, KeyboardEventArgs e)
        {
            Debug.Log(e.Key.ToString());
        }

        private IntPtr KeyboardHookDelegate(Int32 Code, IntPtr wParam, IntPtr lParam)
        {
            if (Code < 0)
            {
                return WindowsHookHelper.CallNextHookEx(keyBoardHandle, Code, wParam, lParam);
            }

            KeyBoardKeyPressed?.Invoke(this, new KeyboardEventArgs());

            return WindowsHookHelper.CallNextHookEx(keyBoardHandle, Code, wParam, lParam);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (keyBoardHandle != IntPtr.Zero)
                {
                    WindowsHookHelper.UnhookWindowsHookEx(keyBoardHandle);
                }

                disposed = true;
            }
        }

        ~KeyBoardInput()
        {
            Dispose(false);
        }
    }
}
