using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_SinhVien:DB_Connect
    {
        public void InsertSV(DTO_SinhVien sv)
        {
            OpenConnection();
            string query = string.Format("insert into sinhvien(MaSV, hoten, ngaysinh, phai, lop, DTB) values ('{0}','{1}','{2}','{3}','{4}',{5})",
                sv.MaSV1, sv.HoTen1, sv.NgaySinh1, sv.Phai1, sv.Lop1, sv.DTB1);
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Connection = Connection;
            cmd.CommandType = CommandType.Text;

            int result = cmd.ExecuteNonQuery();
            CloseConnection();
            if (result > 0)
            {
                Console.WriteLine("Succeed");
            }
            else
            {
                Console.WriteLine("Unsucceed");
            }
        }

        public void UpdateDiemSV(string mssv, float diem)
        {
            OpenConnection();
            string query = string.Format("update SINHVIEN set DTB = '{0}' where MaSV = '{1}'", diem, mssv);
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Connection = Connection;
            cmd.CommandType = CommandType.Text;

            int result = cmd.ExecuteNonQuery();
            CloseConnection();
            if (result > 0)
            {
                Console.WriteLine("Succeed");
            }
            else
            {
                Console.WriteLine("Unsucceed");
            }
        }

        public float TongDiemTrungBinh()
        {
            OpenConnection();
            string query = string.Format("select sum(DTB)/COUNT(MaSV) from SINHVIEN");
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Connection = Connection;
            cmd.CommandType = CommandType.Text;

            float result = float.Parse((cmd.ExecuteScalar().ToString()));
            CloseConnection();

            return result;
        }

        public float TinhDiemTrungBinh(string mssv)
        {
            OpenConnection();
            string query = string.Format("select sum(dk.Diem * dk.SoTC) / sum(dk.SoTC) from DKHP dk where dk.MaSV = '{0}'", mssv);
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Connection = Connection;
            cmd.CommandType = CommandType.Text;

            float result = float.Parse((cmd.ExecuteScalar().ToString()));
            CloseConnection();

            return result;
        }

        public DTO_SinhVien SelectSV(string mssv)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();

            string query = string.Format("select * from sinhvien where sinhvien.masv = N'{0}'", mssv);
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Connection = Connection;
            cmd.CommandType = CommandType.Text;

            DTO_SinhVien sv = new DTO_SinhVien();
            OpenConnection();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            CloseConnection();

            if (dt.Rows.Count > 0)
            {
                sv.MaSV1 = dt.Rows[0]["MaSV"].ToString();
                sv.HoTen1 = dt.Rows[0]["HoTen"].ToString();
                sv.NgaySinh1 = Convert.ToDateTime(dt.Rows[0]["NgaySinh"].ToString());
                sv.Phai1 = dt.Rows[0]["Phai"].ToString();
                sv.Lop1 = dt.Rows[0]["Lop"].ToString();
                sv.DTB1 = float.Parse(dt.Rows[0]["DTB"].ToString());
            }

            return sv;
        }

        public DTO_SinhVien SinhVienCaoDiemNhat()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();

            string query = string.Format("select sv.* from SINHVIEN sv where sv.DTB >= all(select sv1.DTB from SINHVIEN sv1)");
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Connection = Connection;
            cmd.CommandType = CommandType.Text;

            DTO_SinhVien sv = new DTO_SinhVien();
            OpenConnection();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            CloseConnection();

            if (dt.Rows.Count > 0)
            {
                sv.MaSV1 = dt.Rows[0]["MaSV"].ToString();
                sv.HoTen1 = dt.Rows[0]["HoTen"].ToString();
                sv.NgaySinh1 = Convert.ToDateTime(dt.Rows[0]["NgaySinh"].ToString());
                sv.Phai1 = dt.Rows[0]["Phai"].ToString();
                sv.Lop1 = dt.Rows[0]["Lop"].ToString();
                sv.DTB1 = float.Parse(dt.Rows[0]["DTB"].ToString());
            }

            return sv;
        }

        public List<DTO_SinhVien> XuatSinhVienTheoPhai(string phai)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            List<DTO_SinhVien> arrSV = new List<DTO_SinhVien>();

            string query = string.Format("select * from sinhvien where sinhvien.Phai = N'{0}'", phai);
            SqlCommand cmd = new SqlCommand(query, Connection);
            cmd.Connection = Connection;
            cmd.CommandType = CommandType.Text;

            OpenConnection();
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(dt);
            CloseConnection();

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                DTO_SinhVien sv = new DTO_SinhVien();
                sv.MaSV1 = dt.Rows[i]["MaSV"].ToString();
                sv.HoTen1 = dt.Rows[i]["HoTen"].ToString();
                sv.NgaySinh1 = Convert.ToDateTime(dt.Rows[i]["NgaySinh"].ToString());
                sv.Phai1 = dt.Rows[i]["Phai"].ToString();
                sv.Lop1 = dt.Rows[i]["Lop"].ToString();

                if (!dt.Rows[i].IsNull("DTB"))
                {
                    sv.DTB1 = float.Parse(dt.Rows[i]["DTB"].ToString());
                }
                
                arrSV.Add(sv);
            }

            return arrSV;
        }
    }
}
