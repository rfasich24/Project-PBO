using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;

namespace Project_PBO_2.Model
{
    public class Alat
    {
        SqlDBHelper objSqlDb = new SqlDBHelper();
        public Alat()
        {

        }


        public DataTable getDataAlat()
        {
            string query = "Select * from alat";
            DataTable dt = objSqlDb.ExecuteQuery(query);
            return dt;
        }

        public string[] getBrokenTools()
        {
            string query = "Select count(kondisi_alat) from alat where kondisi_alat = 'Rusak'";
            DataTable dt = objSqlDb.ExecuteQuery(query);
            string[] names = dt.AsEnumerable().Select(r => r["count"].ToString()).ToArray();
            Console.WriteLine(names);
            return names;
        }
        public void hapusAlat(string id_alat)
        {
            string query = "Delete from alat where id_alat = :id_alat ::integer ;";
            objSqlDb.ExecuteNonQuery(query, new Npgsql.NpgsqlParameter(":id_peminjaman", id_alat));
        }

        public void updateAlat(string nama_alat, string merk, string jumlah, string kondisi_alat)
        {

            string query = @"update alat set nama_alat    = :nama_alat ::text,
                                                merk         = :merk ::text,
                                                nama_alat     = :nama_alat ::text,
                                                jumlah        = :jumlah ::integer,
                                                kondisi_alat  = :kondisi_alat ::kondisi";

            objSqlDb.ExecuteNonQuery(query,
                new NpgsqlParameter(":nama_alat", nama_alat),
                new NpgsqlParameter(":merk", merk),
                new NpgsqlParameter(":jumlah", jumlah),
                new NpgsqlParameter(":kondisi_alat", kondisi_alat)
                );

        }

        public void insertAlat(string nama_alat, string merk, string jumlah, string kondisi_alat)
        {
            string query = "insert into alat (nama_alat,merk,jumlah,kondisi_alat) values ('{0}', '{1}',{2}, '{3}')";
            query = string.Format(query, nama_alat, merk, jumlah, kondisi_alat);
            objSqlDb.ExecuteNonQuery(query);
        }
    }
}