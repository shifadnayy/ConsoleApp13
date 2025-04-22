using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace pbotugas
{
    internal class Program
    {
        static void Main(string[] agrs)
        {
            Console.WriteLine("DataBase Mahasiswa");
            Console.WriteLine("1. Membaca Data");
            Console.WriteLine("2. Menulis Data");
            Console.WriteLine("3. Menghapus Data");
            Console.Write("Pilih Menu: ");
            string pilihan = Console.ReadLine();
            switch (pilihan)
            {
                case "1":
                    MembacaData();
                    break;
                case "2":
                    MenulisData();
                    break;
                case "3":
                    menghapusdata();
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid.");
                    break;
            }
        }

        public static void MembacaData()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(Bantu.Koneksics.ConnParamPostgreSQL))
                {
                    conn.Open();
                    Console.WriteLine("Koneksi Berhasil");
                    string sql = "SELECT * FROM mhs";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine("NIM: " + reader["nim"] + ", Nama: " + reader["nama"] + ", Alamat: " + reader["alamat"]);
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("Koneksi Gagal: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Selesai Membaca Data. Ingin melanjutkan?");
                Console.WriteLine("1. Ya");
                Console.WriteLine("2. Tidak");
                string pilihan = Console.ReadLine();
                switch (pilihan)
                {
                    case "1":
                        Console.WriteLine("Kembali ke Menu Utama");
                        break;
                    case "2":
                        Console.WriteLine("Keluar dari Program");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
        }
        public static void MenulisData()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM mhs";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine(" NIM: " + reader["nim"] + ", Nama: " + reader["nama"] + ", Alamat: " + reader["alamat"]);
                        }
                    }
                    conn.Close();
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                        Console.WriteLine("Menambahkan Data");
                    Console.Write("Masukkan NIM: ");
                    string T_nim = Console.ReadLine();
                    Console.Write("Masukkan Nama: ");
                    string T_Nama = Console.ReadLine();
                    Console.Write("Masukkan Alamat: ");
                    string T_alamat = Console.ReadLine();
                    string sqli = "INSERT INTO mhs (nim, nama, alamat) VALUES (@nim, @nama, @alamat)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqli, conn))
                    {
                        cmd.Parameters.AddWithValue("@nim", T_nim);
                        cmd.Parameters.AddWithValue("@nama", T_Nama);
                        cmd.Parameters.AddWithValue("@alamat", T_alamat);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " baris ditambahkan.");
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("Koneksi Gagal: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Selesai Menulis Data. Ingin melanjutkan?");
                Console.WriteLine("1. Ya");
                Console.WriteLine("2. Tidak");
                string pilihan = Console.ReadLine();
                switch (pilihan)
                {
                    case "1":
                        Console.WriteLine("Kembali ke Menu Utama");
                        break;
                    case "2":
                        Console.WriteLine("Keluar dari Program");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
        }
        public static void menghapusdata()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(Tools.KoneksiDB.ConnParamPostgresSQL()))
                {
                    conn.Open();
                    string sql = "SELECT * FROM mhs";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine(" NIM: " + reader["nim"] + ", Nama: " + reader["nama"] + ", Alamat: " + reader["alamat"]);
                        }
                    }
                    conn.Close();
                    conn.Open();
                    Console.WriteLine("Menghapus Data");
                    Console.Write("Masukkan NIM yang ingin dihapus: ");
                    string T_nim = Console.ReadLine();
                    string sqli = "DELETE FROM mhs WHERE nim = @nim";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqli, conn))
                    {
                        cmd.Parameters.AddWithValue("@nim", T_nim);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected + " baris dihapus.");
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("Koneksi Gagal: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {

                Console.WriteLine("Selesai Menghapus Data. Ingin melanjutkan?");
                Console.WriteLine("1. Ya");
                Console.WriteLine("2. Tidak");
                string pilihan = Console.ReadLine();
                switch (pilihan)
                {
                    case "1":
                        Console.WriteLine("Kembali ke Menu Utama");
                        break;
                    case "2":
                        Console.WriteLine("Keluar dari Program");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
        }
        public static void media()
        {
        
        }
    }
}