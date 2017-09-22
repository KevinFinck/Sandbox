using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Playground_ASP
{
    public partial class TestMe : Page
    {
        private string _myLoad;
        protected void Page_Load(object sender, EventArgs e)
        {
            _myLoad = Guid.NewGuid().ToString();
            if (!IsPostBack && !string.IsNullOrWhiteSpace(Session["ErrorMessage"]?.ToString()))
            {
                Log($"****** ERROR ****** {Session["ErrorMessage"]}");
                Session["ErrorMessage"] = null;
            }
            else
            {
                Log(IsPostBack ? $"Page Load: {Request.HttpMethod}" : "First Time ! ! !");
            }
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Log("Going to sleep...");
            Thread.Sleep(3000);
            Log("Waking up!");

             Session["ErrorMessage"] = "Look for me!";

            Response.Redirect(Request.RawUrl, false);
            Context.ApplicationInstance.CompleteRequest();
        }

        private void Log(string msg)
        {
            Debug.WriteLine($"{_myLoad}  --  {msg}");
        }
    }
}