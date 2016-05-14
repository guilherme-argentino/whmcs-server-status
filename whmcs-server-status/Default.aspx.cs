using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace whmcs_server_status
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // create new instance for System Up Time
            PerformanceCounter pcUptime = new PerformanceCounter("System", "System Up Time");
            pcUptime.NextValue(); //Normally starts with zero. do Next Value always.
            TimeSpan ts = TimeSpan.FromSeconds(pcUptime.NextValue());

            // populate System Up Time
            uptimeLiteral.Text = string.Format(@"{0:%d} days {0:hh\:mm\:ss}", ts);

            // create new instance for System Up Time
            PerformanceCounter pcProcessor = new PerformanceCounter("System", "Processor Queue Length");

            // populate System Up Time
            loadLiteral.Text = string.Format("{0:0.00}", pcProcessor.NextValue());
        }
    }
}