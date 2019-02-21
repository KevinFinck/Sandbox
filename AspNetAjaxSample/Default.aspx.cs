using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetAjaxSample
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        protected void btnDoSomething_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(3000);
            lblTime.Text = "Time Interrupted";
        }
    }
}