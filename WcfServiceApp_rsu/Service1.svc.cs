using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServiceApp_rsu
{
    public class Service1 : IService1
    {
        public string url = "Data source=LAPTOP_PE_NAFI; database=data_pasien;User ID=sa;Password=123";

        public string deletedata_pasien(string id_pasien)
        {
            SqlConnection con = new SqlConnection();
            string a = "gagal";
            try
            {
                con = new SqlConnection(url);
                con.Open();
                SqlCommand cm = new SqlCommand("DELETE FROM[dbo].[data_pasien] WHERE[id_pasien] =  '" + id_pasien + "';", con);

                cm.ExecuteNonQuery();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            finally { con.Close(); }
            return a;
        }

        public string editdata_pasien(string id_pasien, string nik, string nama_pasien, string tempat_lahir, string tgl_lahir, string agama, string jns_kelamin, string alamat, string no_telpon)
        {
            SqlConnection com = new SqlConnection();
            string a = "gagal";
            try
            {
                com = new SqlConnection(url);
                com.Open();
                SqlCommand command = new SqlCommand("update [dbo].[data_pasien] set" +
                                "[NIK] = '" + nik + "'," +
                                "[nama_pasien] = '" + nama_pasien + "'," +
                                "[tempat_lahir] = '" + tempat_lahir + "'," +
                                "[tanggal_lahir] = '" + tgl_lahir + "'," +
                                "[agama] = '" + agama + "'," +
                                "[jenis_kelamin] = '" + jns_kelamin + "'," +
                                "[alamat] = '" + alamat + "'," +
                                "[no_telpon] = '" + no_telpon + "'" +
                                "where[id_pasien] = '" + id_pasien + "' ", com);
                command.ExecuteNonQuery();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            finally { com.Close(); }
            return a;
        }

        public string insertdata_pasien(string id_pasien, string nik, string nama_pasien, string tempat_lahir, string tgl_lahir, string agama, string jns_kelamin, string alamat, string no_telpon)
        {
            SqlConnection conn = new SqlConnection();
            string a = "gagal";
            try
            {
                conn = new SqlConnection(url);
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into [dbo].[data_pasien]([id_pasien],[NIK],[nama_pasien],[tempat_lahir],[tanggal_lahir],[agama],[jenis_kelamin],[alamat],[no_telpon])" +
                            "values('" + id_pasien + "', '" + nik + "', '" + nama_pasien + "', '" + tempat_lahir + "', '" + tgl_lahir + "', '" + agama + "', '" + jns_kelamin + "', '" + alamat + "', '" + no_telpon + "')", conn);

                cmd.ExecuteNonQuery();

                a = "sukses";
            }
            catch (Exception e)
            {
                Console.WriteLine(a+e);
            }
            finally { conn.Close(); }
            return a;
        }

        public List<view_data> listdata_pasien()
        {
            SqlConnection con = new SqlConnection();
            List<view_data> list = new List<view_data>();
            try
            {
                con = new SqlConnection(url);
                con.Open();

                SqlCommand cmd = new SqlCommand("select [id_pasien], [NIK], [nama_pasien], [tempat_lahir], [tanggal_lahir],[agama],[jenis_kelamin],[no_telpon],[alamat] from [dbo].[data_pasien]", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    view_data data = new view_data();
                    data.id_pasien = reader[0].ToString();
                    data.nik = reader[1].ToString();
                    data.nama_pasien = reader[2].ToString();
                    data.tempat_lahir = reader[3].ToString();
                    data.tgl_lahir = reader[4].ToString();
                    data.agama = reader[5].ToString();
                    data.jns_kelamin = reader[6].ToString();
                    data.no_telpon = reader[7].ToString();
                    data.alamat = reader[8].ToString();
                    list.Add(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            } finally { con.Close(); }
            return list;
        }

        List<view_data> IService1.caridata_pasien(string id_pasien)
        {
            SqlConnection con = new SqlConnection();
            List<view_data> list = new List<view_data>();
            try
            {
                con = new SqlConnection(url);
                con.Open();

                SqlCommand cmd = new SqlCommand("select [id_pasien], [NIK], [nama_pasien], [tempat_lahir], [tanggal_lahir],[agama],[jenis_kelamin],[no_telpon],[alamat] " +
                                                            "from[dbo].[data_pasien] where[id_pasien] = '" + id_pasien + "'", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    view_data data = new view_data();
                    data.id_pasien = reader[0].ToString();
                    data.nik = reader[1].ToString();
                    data.nama_pasien = reader[2].ToString();
                    data.tempat_lahir = reader[3].ToString();
                    data.tgl_lahir = reader[4].ToString();
                    data.agama = reader[5].ToString();
                    data.jns_kelamin = reader[6].ToString();
                    data.no_telpon = reader[7].ToString();
                    data.alamat = reader[8].ToString();
                    list.Add(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally { con.Close(); }
            return list;
        }
    }
}
