namespace LogiTap2Click {

    using System;
    using System.Windows;

    public partial class App : Application, IDisposable {

        KeyCapture keycap = new KeyCapture();
        System.Windows.Forms.ContextMenuStrip menu = new System.Windows.Forms.ContextMenuStrip();
        System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon
        {
            Icon = LogiTap2Click.Properties.Resources.t631_icon,
            Text = LogiTap2Click.Properties.Settings.Default.AppName,
            Visible = true,
        };

        MainWindow mwind = new MainWindow();

        public App()
        {
            //menu.Items.Add("Window", null, (s, e) => { mwind.Toggle(); });
            menu.Items.Add("Exit", null, (s, e) => { Dispose(); });

            notifyIcon.ContextMenuStrip = menu;
            //notifyIcon.DoubleClick += (s, e) => { mwind.Toggle(); };
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        public void Dispose()
        {
            notifyIcon.Dispose();
            Shutdown();
        }
    }
}
