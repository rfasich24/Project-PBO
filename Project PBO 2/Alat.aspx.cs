using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Npgsql;
using Project_PBO_2.Model;

namespace Project_PBO_2
{
    public partial class Alat : Page
    {
        users objUsers = new users();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Postback: dari dalam form / url dia sendiri
            if (!IsPostBack)
            {
                isiDataAlat();
                getBrokenTools();
            }

        }
        private void isiDataAlat()
        {

            DataTable dt = objUsers.getDataAlat();
            GridView2.DataSource = dt;
            GridView2.DataBind();

        }
        public void getBrokenTools()
        {
            string[] brokentools = objUsers.getBrokenTools();
            lbbrokentools.Text = brokentools[0];
        }
    }
}