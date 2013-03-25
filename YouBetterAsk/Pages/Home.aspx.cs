using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YouBetterAsk.Models;

namespace YouBetterAsk
{
    public partial class Home : System.Web.UI.Page
    {
        public OptionsModel Model { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Model = new OptionsModel();
        }
    }
}