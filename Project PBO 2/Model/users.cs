﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;

namespace Project_PBO_2.Model
{
    public class users
    {
        SqlDBHelper objSqlDb = new SqlDBHelper();

        public users()
        {

        }

        public DataTable getDataUsers()
        {
            string query = "Select * from peminjaman";
            DataTable dt = objSqlDb.ExecuteQuery(query);
            return dt;
        }

        public string[] getUnreturned()
        {
            string query = "Select count(status_peminjaman) from peminjaman where status_peminjaman = 'Belum Dikembalikan'";
            DataTable dt = objSqlDb.ExecuteQuery(query);
            string[] names = dt.AsEnumerable().Select(r => r["count"].ToString()).ToArray();
            Console.WriteLine(names);
            return names;
        }

        public void hapusUsers(string id_peminjaman)
        {
            string query = "Delete from peminjaman where id_peminjaman = :id_peminjaman ::integer ;";
            objSqlDb.ExecuteNonQuery(query, new Npgsql.NpgsqlParameter(":id_peminjaman", id_peminjaman));
        }

        public void updateUsers(string nama_siswa, string kelas, string nama_alat, string jumlah,
            string kondisi_awal, string kondisi_akhir, string status_peminjaman, string deskripsi, string id_peminjaman)
        {



            string query = @"update peminjaman set nama_siswa    = :nama_siswa ::text,
                                                kelas         = :kelas ::text,
                                                nama_alat     = :nama_alat ::text,
                                                jumlah        = :jumlah ::integer,
                                                kondisi_awal  = :kondisi_awal ::kondisi,
                                                kondisi_akhir = :kondisi_akhir ::kondisi,
                                                status_peminjaman = :status_peminjaman ::status,
                                                deskripsi     = :deskripsi ::text
                                                where id_peminjaman = :id_peminjaman ::integer";

            objSqlDb.ExecuteNonQuery(query,
                new NpgsqlParameter(":nama_siswa", nama_siswa),
                new NpgsqlParameter(":kelas", kelas),
                new NpgsqlParameter(":nama_alat", nama_alat),
                new NpgsqlParameter(":jumlah", jumlah),
                new NpgsqlParameter(":kondisi_awal", kondisi_awal),
                new NpgsqlParameter(":kondisi_akhir", kondisi_akhir),
                new NpgsqlParameter(":status_peminjaman", status_peminjaman),
                new NpgsqlParameter(":deskripsi", deskripsi),
                new NpgsqlParameter(":id_peminjaman", id_peminjaman)
                );

        }

        public void insertUsers(string nama_siswa, string kelas, string nama_alat, string jumlah,
            string kondisi_awal, string kondisi_akhir, string status_peminjaman, string deskripsi)
        {

            string query = "insert into peminjaman (nama_siswa,kelas,nama_alat,jumlah,kondisi_awal,kondisi_akhir,status_peminjaman,deskripsi) values ('{0}', '{1}','{2}', {3}, '{4}', '{5}', '{6}', '{7}')";
            query = string.Format(query, nama_siswa, kelas, nama_alat, jumlah, kondisi_awal, kondisi_akhir, status_peminjaman, deskripsi);
            objSqlDb.ExecuteNonQuery(query);
        }

    }
}