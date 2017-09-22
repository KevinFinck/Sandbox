using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncTesting
{
    public partial class AsyncForm : Form
    {
        private readonly Label _label;

        public AsyncForm()
        {
            InitializeComponent();

            AutoSize = true;

            _label = new Label
            {
                Location = new Point(10, 20),
                Width = 300,
                Text = @"Length"
            };
            Controls.Add(_label);

            var btn = new Button
            {
                Location = new Point(10, 50),
                Text = @"Click"
            };
            btn.Click += DisplayWebSiteLength;
            Controls.Add(btn);

            btn = new Button
            {
                Location = new Point(110, 50),
                Text = @"To Console"
            };
            btn.Click += WriteLengthToConsole;
            Controls.Add(btn);

            #region Nevermind
            btn = new Button
            {
                Location = new Point(220, 50),
                Text = @"Get it Now"
            };
            btn.Click += ShowWriteLengthNow;
            //Controls.Add(btn);
            #endregion
        }

        public sealed override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        async void DisplayWebSiteLength(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())    // Make sure HttpClient is disposed regardless of async call outcome.
            {
                _label.Text = @"Fetching 1st...";

                // Simple way.
                string text = client.GetStringAsync("http://csharpindepth.com").Result;
                    // <--- Exit method.


                    // -------------------------------------------------------
                    // ---> CONTINUATION 1:
                    // -------------------------------------------------------
                    _label.Text = @"Just making you wait...";
                    await Task.Run(() =>
                        {
                            System.Threading.Thread.Sleep(2000);
                        });
                        // <--- Exit method.


                        // ---------------------------------------------------
                        // ---> CONTINUATION 2:
                        // ---------------------------------------------------
                        var firstLength = text.Length;
                        _label.Text = $"1st Length = {firstLength}, Fetching 2nd...";
                            // Explicit way.
                            Task<string> explicitTask = client.GetStringAsync("http://incomm.com");
                            text += 
                                await explicitTask;
                                // <--- Exit method.


                                // -------------------------------------------
                                // ---> CONTINUATION 3:
                                // -------------------------------------------
                                _label.Text = $"1st Length = {firstLength}, Total Length = {text.Length}";
            }
        }

        void WriteLengthToConsole(object sender, EventArgs e)
        {
            AsyncIt.PrintPageLength("http://csharpindepth.com");
        }

        void ShowWriteLengthNow(object sender, EventArgs e)
        {
            MessageBox.Show($"The page length is {AsyncIt.GetPageLengthAsyncNow("http://csharpindepth.com")}",
                @"Synchronous Test", MessageBoxButtons.OK);
            AsyncIt.PrintPageLength("http://csharpindepth.com");
        }

    }
}
