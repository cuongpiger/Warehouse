using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class QuanLySanPham
    {
        public DataTable LoadTatCaSanPham() 
        {
            Provider provider = new Provider();
            try
            {
                string strSQL = "SELECT * FROM SanPham";
                provider.Connect();
                DataTable dt = provider.Select(CommandType.Text, strSQL);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                provider.DisConnect();
            }
        }

        public int ThemSanPham(SanPham sp)
        {
            Provider provider = new Provider();
            int nRow = 0;
            try
            {
                string strSQL = "INSERT INTO SanPham VALUES(@MaSP, @TenSP, @GiaTien, @SoLuong, @DonVi)";
                provider.Connect();
                nRow = provider.ExeCuteNonQuery(CommandType.Text, strSQL,
                        new SqlParameter {ParameterName="@MaSP", Value = sp.MaSP },
                        new SqlParameter {ParameterName="@TenSP", Value = sp.TenSP },
                        new SqlParameter {ParameterName="@GiaTien", Value = sp.GiaTien },
                        new SqlParameter {ParameterName="@SoLuong", Value = sp.SoLuong},
                        new SqlParameter {ParameterName="@DonVi", Value = sp.DonVi }
                    );
                if (nRow > 0)
                    return 1;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                provider.DisConnect();
            }
            return nRow;
        }

        public int XoaSanPham(string ma)
        {
            Provider provider = new Provider();
            try
            {
                string strSQL = "sp_XoaSanPham";
                provider.Connect();
                SqlParameter p = new SqlParameter("@rs", SqlDbType.Int);
                p.Direction = ParameterDirection.ReturnValue;
                provider.ExeCuteNonQuery(CommandType.StoredProcedure, strSQL,
                        new SqlParameter { ParameterName = "@MaSP", Value = ma }, p
                    );
                return (int)p.Value;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                provider.DisConnect();
            }
        }

        public DataTable TimKiemSanPhamTheoTen(string ma)
        {
            Provider provider = new Provider();
            try
            {
                string strSQL = "sp_TimKiemSanPhamTheoTen";
                provider.Connect();

                DataTable dt = provider.Select(CommandType.StoredProcedure, strSQL,
                         new SqlParameter { ParameterName = "@ten", Value = ma }
                    );
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                provider.DisConnect();
            }
        }
    }
}
