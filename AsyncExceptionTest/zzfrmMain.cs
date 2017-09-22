using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncExceptionTest
{
    public partial class zzfrmMain : Form
    {
        public zzfrmMain()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += (s, e) => Log("*** Crash! ***", "UnhandledException");
            TaskScheduler.UnobservedTaskException += (s, e) => Log("*** Crash! ***", "UnobservedTaskException");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunSelectedTest();
        }



        private async void RunSelectedTest()
        {
            var checkedButton = grpExceptionType
                .Controls
                .OfType<RadioButton>()
                .FirstOrDefault(r => r.Checked);

            Log();
            try
            {
                switch (checkedButton?.Name)
                {
                    case "radVoidNoWait":
                        VoidNoWait();
                        break;
                    case "radAsyncVoidAwait":
                        AsyncVoidAwait();
                        break;
                    case "radAsyncVoidAwaitWithTry":
                        AsyncVoidAwaitWithTry();
                        break;
                    case "radTaskNoWait":
                        TaskNoWait();
                        break;
                    case "radTaskAwait":
                        TaskAwait();
                        break;
                    case "radAwaitTaskNoWait":
                        await TaskNoWait();
                        break;
                    case "radAwaitTaskAwait":
                        await TaskAwait();
                        break;
                    default:
                        Log("No exception type selected.");
                        break;
                }

            }
            catch (Exception ex)
            {
                Log($"Exception handled OK: \n{ex.Message}");
            }

            switch (checkedButton?.Name)
            {
                case "radAwaitTaskNoWaitNoTry":
                    await TaskNoWait();
                    break;
                case "radAwaitTaskAwaitNoTry":
                    await TaskAwait();
                    break;
            }

            // Let async tasks complete...
            Thread.Sleep(500);
            GC.Collect(3, GCCollectionMode.Forced, true);
        }


        // Unsafe
        void VoidNoWait()
        {
            ThrowAsync();
        }

        // Unsafe
        async void AsyncVoidAwait()
        {
            await ThrowAsync();
        }

        // Safe
        async void AsyncVoidAwaitWithTry()
        {
            try { await ThrowAsync(); }
            catch (Exception ex) { Log("Exception handled OK"); }
        }

        // Safe only if caller uses await (or Result) inside a try
        Task TaskNoWait()
        {
            return ThrowAsync();
        }

        // Safe only if caller uses await (or Result) inside a try
        async Task TaskAwait()
        {
            await ThrowAsync();
        }

        // Helper that sets an exception asnychronously
        Task ThrowAsync()
        {
            var tcs = new TaskCompletionSource<Task>();
            ThreadPool.QueueUserWorkItem(_ => tcs.SetException(new Exception("ThrowAsync")));
            return tcs.Task;
        }

        internal void Log(string message = null, [CallerMemberName] string caller = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                if (!string.IsNullOrEmpty(txtLog.Text))
                {
                    txtLog.Text += $@"{Environment.NewLine}";
                }
            }
            else
            {
                txtLog.Text += $@"{caller}: {message}{Environment.NewLine}";
            }
        }
    }

}
