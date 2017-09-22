using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWebApi2Consumer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            CallServiceFrom(ApiService.GetValues(), (Button)sender);
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            CallServiceFrom(ApiService.GetBooks(), (Button)sender);
        }

        private async void CallServiceFrom(Task<string[]> task, Button btn)
        {
            btn.Enabled = false;
            txtResults.Text = @"Loading...";

            DisplayResults(await task);

            btn.Enabled = true;
        }

        private void DisplayResults(string[] values)
        {
            if (values != null && values.Length > 0)
            {
                txtResults.Text = "";
                foreach (var value in values)
                {
                    txtResults.Text += value + Environment.NewLine;
                }
            }
            else
            {
                txtResults.Text = @"No data returned.";
            }
        }

    }
}
