using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestStuffWin
{
    public partial class frmBackgroundThread : Form
    {
        public frmBackgroundThread()
        {
            InitializeComponent();
        }

        private void PretendToDoSomeWork(BackgroundWorker instance, DoWorkEventArgs args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (instance.CancellationPending)
                {
                    args.Cancel = true;
                    break;
                }
                else
                {
                    Thread.Sleep(20);
                    instance.ReportProgress(i);
                }
            }
        }

        // Not on GUI thread.
        private void bgwMainProcessWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            PretendToDoSomeWork((BackgroundWorker)sender, e);
        }

        // IS on GUI thread.
        private void bgwMainProcessWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbStatus.Value = e.ProgressPercentage;
            txtStatus.Text = e.ProgressPercentage.ToString();
        }

        // IS on GUI thread.
        private void bgwMainProcessWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnCancel.Enabled = false;
            lblResult.Text = e.Cancelled 
                ? @"Cancelled!" 
                : @"Finished all processing.";
            pbStatus.Value = 0;
            btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnCancel.Enabled = true;
            txtStatus.Text = "";
            lblResult.Text = "";

            bgwMainProcessWorker.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bgwMainProcessWorker.CancelAsync();
            btnCancel.Enabled = false;
        }
    }
}
