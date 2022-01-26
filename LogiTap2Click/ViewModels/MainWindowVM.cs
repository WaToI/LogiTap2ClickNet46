namespace LogiTap2Click
{
    using Reactive.Bindings;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using WindowsInput;
    using WindowsInput.Events;
    using WindowsInput.Events.Sources;

    public class MainWindowVM : IDisposable
    {
        public ReactiveCommand TestCmd { get; set; } = new ReactiveCommand();

        void doTestCmd() {
        }

        public ReactiveCommand ClosingCmd { get; set; } = new ReactiveCommand();
        //public ReactiveCommand<CancelEventArgs> ClosingCmd { get; set; } = new ReactiveCommand<CancelEventArgs>();
        void doClosingCmd() {
        //void doClosingCmd(CancelEventArgs e) {
            saveProperty();
        }

        public MainWindowVM()
        {
            TestCmd.Subscribe(() => doTestCmd());
            ClosingCmd.Subscribe(() => doClosingCmd());
            //ClosingCmd.Subscribe(s => doClosingCmd(s));
        }

        void saveProperty()
        {
            Properties.Settings.Default.Save();
        }

        public void Dispose()
        {
            saveProperty();
        }

    }
}
