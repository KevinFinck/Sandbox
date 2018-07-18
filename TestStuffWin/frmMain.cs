using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Ninja;

namespace TestStuffWin
{
    public partial class frmMain : Form
    {
        public frmMain()
        {

            var conn = Ninja.ConnectionInfo.GetConnectionString("motr", ServerEnvironmentNames.DEV);

            var x = "1,2 ,3, 4, ,, 99"
                .Split(',')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => int.Parse(s?.Trim() ?? ""))
                .ToList();

            InitializeComponent();
        }


        private void ReadTypes()
        {
            var filename = @"C:\Code\Personal\TestStuffWin\bin\Debug\TestStuffWin.exe";

            //var assembly = Assembly.GetExecutingAssembly();
            var assembly = Assembly.LoadFile(filename);

            var methods = assembly.GetTypes()
                      .SelectMany(t => t.GetMethods())
                      .Where(m => m.GetCustomAttributes(typeof(MyAttribute), false).Length > 0)
                      .ToList();

            string message = "";
            foreach (var method in methods.Where(method => method != null))
            {
                var tracer = TracerFactory.Load(method, IsTransaction(method));
                message += $"Class: {tracer.ClassName}, {tracer.Name}: Is Transaction = {IsTransaction(method)}\n";
            }
            MessageBox.Show(message);


            //Dictionary<string, MethodInfo> methods2 = Assembly.GetExecutingAssembly()
            //    .GetTypes()
            //    .SelectMany(x => x.GetMethods())
            //    .Where(y => y.GetCustomAttributes().OfType<MyAttribute>().Any())
            //    .ToDictionary(z => z.Name);

        }

        private bool IsTransaction(MethodInfo method)
        {
            var myAttribute = method.GetCustomAttributes().OfType<MyAttribute>().FirstOrDefault();

            return myAttribute?.IsTransaction ?? false;
        }


        delegate void DoSomeWork(int progress);

        delegate void ShowProgressDelegate(int progress);

        private void DoSomeWorkHandler(int value)
        {

            for (int i = 1; i <= 100; i++)
            {
                ShowProgress(i);
                Thread.Sleep(10);
            }
            
        }

        private void ShowProgress(int progress)
        {
            if (progressTracker.InvokeRequired)
            {
                var del = new ShowProgressDelegate(ShowProgress);
                this.BeginInvoke(del, new object[] { progress });
            }
            else
            {
                progressTracker.Value = progress;
                txtProgress.Text = progress.ToString();
                if (progress == 100)
                {
                    //progressTracker.Value = 0;
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //ReadTypes();
            btnTest.Enabled = false;

            var progressDelegate = new DoSomeWork(DoSomeWorkHandler);
            progressDelegate.BeginInvoke(0, null, null);

            btnTest.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmBackgroundThread().Show(this.Owner);
        }
    }
}
