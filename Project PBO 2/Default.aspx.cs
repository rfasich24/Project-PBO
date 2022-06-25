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
    public partial class _Default : Page
    {
        users objUsers = new users();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Postback: dari dalam form / url dia sendiri
            if (!IsPostBack)
            {
                isiData();
                Unreturned();
            }
        }

        private void isiData()
        {

            DataTable dt = objUsers.getDataUsers();
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int rowIndex = int.Parse(e.CommandArgument.ToString());
            string id_peminjaman = GridView1.DataKeys[rowIndex]["id_peminjaman"].ToString();

            if (e.CommandName == "hapus")
            {
                objUsers.hapusUsers(id_peminjaman);
                isiData();
                Unreturned();
            }
            else if (e.CommandName == "ubah")
            {
                
                tbnama.Text = GridView1.DataKeys[rowIndex]["nama_siswa"].ToString();
                tbkelas.Text = GridView1.DataKeys[rowIndex]["kelas"].ToString();
                tbalat.Text = GridView1.DataKeys[rowIndex]["nama_alat"].ToString();
                tbjumlah.Text = GridView1.DataKeys[rowIndex]["jumlah"].ToString();
                tbkondisiawal.Text = GridView1.DataKeys[rowIndex]["kondisi_awal"].ToString();
                tbkondisiakhir.Text = GridView1.DataKeys[rowIndex]["kondisi_akhir"].ToString();
                tbstatuspeminjaman.Text = GridView1.DataKeys[rowIndex]["status_peminjaman"].ToString();
                tbdeskripsi.Text = GridView1.DataKeys[rowIndex]["deskripsi"].ToString();

                //ViewState => Variabel browser client tdk hilang jika tdk pindah form / url

                ViewState["id_peminjaman"] = id_peminjaman;
                btSimpan.Visible = false;
                btUpdate.Visible = true;
                panelUser.Visible = false;
                panelForm.Visible = true;
            }
        }


        protected void btSimpan_Click(object sender, EventArgs e)
        {
            objUsers.insertUsers(tbnama.Text, tbkelas.Text, tbalat.Text, tbjumlah.Text, tbkondisiawal.Text,
                tbkondisiakhir.Text, tbstatuspeminjaman.Text, tbdeskripsi.Text);
            isiData();
            Unreturned();
            panelUser.Visible = true;
            panelForm.Visible = false;
        }

        protected void btUpdate_Click(object sender, EventArgs e)
        {
            objUsers.updateUsers(tbnama.Text, tbkelas.Text, tbalat.Text, tbjumlah.Text, tbkondisiawal.Text,
                tbkondisiakhir.Text, tbstatuspeminjaman.Text, tbdeskripsi.Text, ViewState["id_peminjaman"].ToString());
            isiData();
            Unreturned();
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

        public void Unreturned()
        {
            string[] Unreturn = objUsers.getUnreturned();
            Console.WriteLine(Unreturn);
            lbunreturned.Text = Unreturn[0];
        }

    }
}