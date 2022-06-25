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

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string id_alat = GridView2.DataKeys[rowIndex]["id_alat"].ToString();

            if (e.CommandName == "hapus")
            {
                objUsers.hapusAlat(id_alat);
                isiDataAlat();
                getBrokenTools();
            }
            else if (e.CommandName == "ubah")
            {

                tbnamaalat.Text = GridView2.DataKeys[rowIndex]["nama_alat"].ToString();
                tbmerk.Text = GridView2.DataKeys[rowIndex]["merk"].ToString();
                tbjumlah.Text = GridView2.DataKeys[rowIndex]["jumlah"].ToString();
                tbkondisialat.Text = GridView2.DataKeys[rowIndex]["kondisi_alat"].ToString();

                //ViewState => Variabel browser client tdk hilang jika tdk pindah form / url

                ViewState["id_alat"] = id_alat;
                btSimpan.Visible = false;
                btUpdate.Visible = true;
                panelUser.Visible = false;
                panelForm.Visible = true;
            }
        }


        protected void btSimpan_Click(object sender, EventArgs e)
        {
            objUsers.insertAlat(tbnamaalat.Text,tbmerk.Text,tbjumlah.Text,tbkondisialat.Text);
            isiDataAlat();
            getBrokenTools();

            tbnamaalat.Text = "";
            tbmerk.Text = "";
            tbjumlah.Text = "";
            tbkondisialat.Text = "";
            panelUser.Visible = true;
            panelForm.Visible = false;
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            objUsers.updateAlat(tbnamaalat.Text,tbmerk.Text,tbjumlah.Text,tbkondisialat.Text,ViewState["id_alat"].ToString());
            isiDataAlat();
            getBrokenTools();

            tbnamaalat.Text = "";
            tbmerk.Text = "";
            tbjumlah.Text = "";
            tbkondisialat.Text = "";
            panelUser.Visible = true;
            panelForm.Visible = false;
        }

        protected void lbTambah_Click(object sender, EventArgs e)
        {
            panelUser.Visible = false;
            panelForm.Visible = true;
            btSimpan.Visible = true;
            btUpdate.Visible = false;
        }

        protected void btBatal_Click(object sender, EventArgs e)
        {
            panelUser.Visible = true;
            panelForm.Visible = false;
        }
    }
}