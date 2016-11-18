using System;
using System.Runtime.InteropServices;

namespace GameEngine.Input
{
    public class KeyboardEventArgs : EventArgs
    {
        private KeyStrokes _key;

        public KeyboardEventArgs(KeyStrokes code)
        {
            this._key = code;
        }

        public KeyStrokes Key { get { return _key; } }
    }
    public class KeyBoardInput : IDisposable
    {
        internal KeyStrokes LastKeyPressed;

        public event EventHandler<KeyboardEventArgs> KeyBoardKeyPressed;

        private WindowsHookHelper.HookDelegate keyBoardDelegate;
        private IntPtr keyBoardHandle;
        private const Int32 WH_KEYBOARD_LL = 13;
        private bool disposed;



        public KeyBoardInput()
        {
            keyBoardDelegate = KeyboardHookDelegate;
            keyBoardHandle = WindowsHookHelper.SetWindowsHookEx(WH_KEYBOARD_LL, keyBoardDelegate, IntPtr.Zero, 0);
            KeyBoardKeyPressed -= KeyboardInput_KeyBoardKeyPressed;
            KeyBoardKeyPressed += KeyboardInput_KeyBoardKeyPressed;
        }

        private void KeyboardInput_KeyBoardKeyPressed(object sender, KeyboardEventArgs e)
        {
            LastKeyPressed = e.Key;
            Debug.Log(e.Key.ToString());
        }

        private IntPtr KeyboardHookDelegate(Int32 Code, IntPtr wParam, IntPtr lParam)
        {
            if (Code < 0)
            {
                return WindowsHookHelper.CallNextHookEx(keyBoardHandle, Code, wParam, lParam);
            }
            
            var pressedKey = GetKeyCode(lParam);

            KeyBoardKeyPressed?.Invoke(this, new KeyboardEventArgs(pressedKey));

            return WindowsHookHelper.CallNextHookEx(keyBoardHandle, Code, wParam, lParam);
        }

        private KeyStrokes GetKeyCode(IntPtr wParam)
        {
            int keycode = Marshal.ReadInt32(wParam);
            return ((KeyStrokes)keycode);
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
