namespace LogiTap2Click
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WindowsInput;
    using WindowsInput.Events;
    using WindowsInput.Events.Sources;

    public class KeyCapture : IDisposable
    {
        IKeyboardEventSource keyboardESrc;
        //IMouseEventSource mouseESrc;

        public KeyCapture()
        {
            keyboardESrc = default;
            keyboardESrc = WindowsInput.Capture.Global.Keyboard();
            //keyboardESrc = WindowsInput.Capture.CurrentThread.Keyboard();
            //keyboardESrc.KeyEvent += KeyboardESrc_KeyEvent;
            keyboardESrc.KeyDown += KeyboardESrc_KeyDown;
            keyboardESrc.KeyUp += KeyboardESrc_KeyUp;

            //mouseESrc = default;
            //mouseESrc = WindowsInput.Capture.Global.Mouse();
            ////mouseESrc = WindowsInput.Capture.CurrentThread.Mouse();
            //mouseESrc.MouseEvent += MouseESrc_MouseEvent;
        }

        bool isKdLWinEx = false;
        bool isKdD = false;

        void KeyboardESrc_KeyDown(object sender, EventSourceEventArgs<WindowsInput.Events.KeyDown> e)
        {
            if (e.Data.Key == WindowsInput.Events.KeyCode.LWin && !e.Data.Extended)
            {
                Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}: {e.Data.Key} {(e.Data.Extended?"Extended":"")}");
                isKdLWinEx = true;
                e.Next_Hook_Enabled = false;
            }
            else if (e.Data.Key == WindowsInput.Events.KeyCode.D && isKdLWinEx)
            {
                Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}: {e.Data.Key} {(e.Data.Extended?"Extended":"")}");
                isKdD = true;
                e.Next_Hook_Enabled = false;
            }
        }

        void KeyboardESrc_KeyUp(object sender, EventSourceEventArgs<WindowsInput.Events.KeyUp> e)
        {
            if ((e.Data.Key == WindowsInput.Events.KeyCode.LWin && !e.Data.Extended)
              || (e.Data.Key == WindowsInput.Events.KeyCode.D && isKdLWinEx))
            {
                Debug.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name}: {e.Data.Key} {(e.Data.Extended?"Extended":"")}");
                if (isKdLWinEx && isKdD)
                {
                    isKdLWinEx = false;
                    isKdD = false;
                    e.Next_Hook_Enabled = false;
                    Simulate.Events()
                        .Click(ButtonCode.Right)
                        .Invoke();
                }
                else if (isKdLWinEx)
                {
                    isKdD = false;
                    e.Next_Hook_Enabled = false;
                    Simulate.Events()
                        .Click(ButtonCode.Left)
                        .Invoke();
                }
            }
        }

        //void KeyboardESrc_KeyEvent(object sender, EventSourceEventArgs<KeyboardEvent> e)
        //{
        //    Log(e);
        //}
        //void MouseESrc_MouseEvent(object sender, EventSourceEventArgs<MouseEvent> e)
        //{
        //    Log(e);
        //}

        //void Log<T>(EventSourceEventArgs<T> e, string Notes = "") where T : InputEvent
        //{
        //    var NewContent = $"{e.Timestamp}: {Notes}\r\n";
        //    foreach (var item in e.Data.Events)
        //    {
        //        NewContent += $"  {item}\r\n";
        //    }
        //    System.Diagnostics.Debug.WriteLine(NewContent);
        //}

        public void Dispose()
        {
            keyboardESrc?.Dispose();
            //mouseESrc?.Dispose();
        }
    }
}
