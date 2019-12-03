using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DAL
{
    public class DAL_SinhVien : DB_Connect
    {
        /// <summary>
        ///     Thêm sinh viên vào table SINHVIEN
        /// </summary>
        /// <param name="sv">
        ///     Đối tượng sinh viên cần thêm
        /// </param>
        /// <returns>
        ///     Trả về 0 nếu thêm thành công ngược lại thì trả về 1
        /// </returns>
        public int InsertSV(DTO_SinhVien sv)
        {
            OpenConnection();
            int res = 0;

            try
            {
                SqlCommand cmd = new SqlCommand("InsertSV", Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@i_masv", sv.MaSV1);
                cmd.Parameters.AddWithValue("@i_hoten", sv.HoTen1);
                cmd.Parameters.AddWithValue("@i_phai", sv.Phai1);
                cmd.Parameters.AddWithValue("@i_lop", sv.Lop1);
                cmd.Parameters.AddWithValue("@i_dtb", sv.DTB1);
                cmd.Parameters.Add("@i_ngaysinh", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@i_ngaysinh"].Value = sv.NgaySinh1;

                res = cmd.ExecuteNonQuery();
            }
            catch
            {
                res = 1;
            }

            CloseConnection();

            return res;
        }

        /// <summary>
        ///     Tìm một sinh viên từ table SINHVIEN dựa vào mã sinh viên
        /// </summary>
        /// <param name="mssv">
        ///     Là mã sinh viên cần tìm
        /// </param>
        /// <param name="o_sv">
        ///     Là kết quả để tìm được
        /// </param>
        /// <returns>
        ///     Trả về 0 nếu thêm thành công và ngược lại trả về 1
        /// </returns>
        public int SeekSV(string mssv, ref DTO_SinhVien o_sv)
        {
            int res = 0;
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("SeekSV", Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlCommand.Parameters.AddWithValue("@i_masv", mssv);

                OpenConnection();
                res = sqlCommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataTable);
                CloseConnection();

                res = 0;
            }
            catch
            {
                res = 1;
            }

            if (dataTable.Rows.Count > 0 && res == 0)
            {
                o_sv.MaSV1 = dataTable.Rows[0]["MaSV"].ToString();
                o_sv.HoTen1 = dataTable.Rows[0]["HoTen"].ToString();
                o_sv.NgaySinh1 = Convert.ToDateTime(dataTable.Rows[0]["NgaySinh"].ToString());
                o_sv.Phai1 = dataTable.Rows[0]["Phai"].ToString();
                o_sv.Lop1 = dataTable.Rows[0]["Lop"].ToString();
                o_sv.DTB1 = float.Parse(dataTable.Rows[0]["DTB"].ToString());
            }

            return res;
        }

        /// <summary>
        ///  Tìm danh sách sinh viên có điểm trung bình cao nhất
        /// </summary>
        /// <param name="listSVRes"></param>
        /// <returns></returns>
        public int SeekSVMaxScore(ref List<DTO_SinhVien> listSVRes)
        {
            int res = 0;
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("SeekSVMaxScore", Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                OpenConnection();
                res = sqlCommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataTable);
                CloseConnection();

                res = 0;
            }
            catch
            {
                res = 1;
            }

            if (res == 0)
            {
                listSVRes = new List<DTO_SinhVien>();
            }

            for (int i = 0; i < dataTable.Rows.Count && res == 0; ++i)
            {
                DTO_SinhVien o_sv = new DTO_SinhVien();
                o_sv.MaSV1 = dataTable.Rows[i]["MaSV"].ToString();
                o_sv.HoTen1 = dataTable.Rows[i]["HoTen"].ToString();
                o_sv.NgaySinh1 = Convert.ToDateTime(dataTable.Rows[i]["NgaySinh"].ToString());
                o_sv.Phai1 = dataTable.Rows[i]["Phai"].ToString();
                o_sv.Lop1 = dataTable.Rows[i]["Lop"].ToString();
                o_sv.DTB1 = float.Parse(dataTable.Rows[i]["DTB"].ToString());

                listSVRes.Add(o_sv);
            }

            return res;
        }

        /// <summary>
        ///     Tìm danh sách sinh vien co diem trung bình thap nhất
        /// </summary>
        /// <param name="listSVRes"></param>
        /// <returns></returns>
        public int SeekSVMinScore(ref List<DTO_SinhVien> listSVRes)
        {
            int res = 0;
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("SeekSVMinScore", Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                OpenConnection();
                res = sqlCommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataTable);
                CloseConnection();

                res = 0;
            }
            catch
            {
                res = 1;
            }

            if (res == 0)
            {
                listSVRes = new List<DTO_SinhVien>();
            }

            for (int i = 0; i < dataTable.Rows.Count && res == 0; ++i)
            {
                DTO_SinhVien o_sv = new DTO_SinhVien();
                o_sv.MaSV1 = dataTable.Rows[i]["MaSV"].ToString();
                o_sv.HoTen1 = dataTable.Rows[i]["HoTen"].ToString();
                o_sv.NgaySinh1 = Convert.ToDateTime(dataTable.Rows[i]["NgaySinh"].ToString());
                o_sv.Phai1 = dataTable.Rows[i]["Phai"].ToString();
                o_sv.Lop1 = dataTable.Rows[i]["Lop"].ToString();
                o_sv.DTB1 = float.Parse(dataTable.Rows[i]["DTB"].ToString());

                listSVRes.Add(o_sv);
            }

            return res;
        }

        /// <summary>
        ///     Xuất danh sách sinh viên theo phái
        /// </summary>
        /// <param name="phai"></param>
        /// <returns></returns>
        public int PrintSVGender(string phai, ref List<DTO_SinhVien> listSVRes)
        {
            int res = 0;
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("PrintSVGender", Connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                sqlCommand.Parameters.AddWithValue("@i_phai", phai);

                OpenConnection();
                res = sqlCommand.ExecuteNonQuery();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataTable);
                CloseConnection();

                res = 0;
            }
            catch
            {
                res = 1;
            }

            if (res == 0)
            {
                listSVRes = new List<DTO_SinhVien>();
            }

            for (int i = 0; i < dataTable.Rows.Count && res == 0; ++i)
            {
                DTO_SinhVien o_sv = new DTO_SinhVien();

                o_sv.MaSV1 = dataTable.Rows[0]["MaSV"].ToString();
                o_sv.HoTen1 = dataTable.Rows[0]["HoTen"].ToString();
                o_sv.NgaySinh1 = Convert.ToDateTime(dataTable.Rows[0]["NgaySinh"].ToString());
                o_sv.Phai1 = dataTable.Rows[0]["Phai"].ToString();
                o_sv.Lop1 = dataTable.Rows[0]["Lop"].ToString();
                o_sv.DTB1 = float.Parse(dataTable.Rows[0]["DTB"].ToString());

                listSVRes.Add(o_sv);
            }

            return res;
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





        
    }
}
