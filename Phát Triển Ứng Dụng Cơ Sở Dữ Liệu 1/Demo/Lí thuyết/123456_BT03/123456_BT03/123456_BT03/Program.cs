using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            { 
                Console.WriteLine(" ***** Menu  ****");
                Console.WriteLine("1. Load tat ca cac san pham");
                Console.WriteLine("2. Them 1 san pham");
                Console.WriteLine("3. Xoa 1 san pham");
                Console.WriteLine("4. Sua thong tin 1 san pham");
                Console.WriteLine("5. Tim mot san pham theo ten");
                Console.WriteLine("6. Xuat danh sach ra file txt");
                Console.WriteLine("7. Thoat");
                Console.WriteLine();
                Console.Write("Nhap lua chon cua ban: ");
                int chon = int.Parse(Console.ReadLine());
                QuanLySanPham quanly = new QuanLySanPham();
                switch (chon)
                {
                    case 1:
                        {
                            try{
                                DataTable dt = quanly.LoadTatCaSanPham();
                                foreach (DataRow row in dt.Rows)
                                {
                                    Console.WriteLine(row[0] + " - " + row[1] + " - " + row[2] + " - " + row[3] + " - " + row[4]);
                                }
                            }
                            catch(Exception ex)
                            {
                                 Console.WriteLine("Loi" + ex.ToString());
                            }
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                Console.WriteLine("Nhap thong tin san pham muon them: ");
                                SanPham sp = new SanPham();
                                sp.Nhap();
                                int kq = quanly.ThemSanPham(sp);
                                if(kq > 0)
                                     Console.WriteLine("Them thanh cong !!!");
                                else
                                    Console.WriteLine("Them that bai !!!");
                             }
                            catch(Exception ex)
                            {
                                 Console.WriteLine("Loi" + ex.ToString());
                            }
                             break;
                        }
                    case 3:
                         {
                             try
                             {
                                 Console.Write("Nhap ma san pham can xoa: ");
                                 string ma = Console.ReadLine();
                                 int kq = quanly.XoaSanPham(ma);
                                 if (kq > 0)
                                     Console.WriteLine("Xoa thanh cong !!!");
                                 else
                                     Console.WriteLine("Xoa that bai !!!");
                             }
                             catch (Exception ex)
                             {
                                 Console.WriteLine("Loi" + ex.ToString());
                             }
                             break;
                         }
                    case 5:
                         {
                             try
                             {
                                 Console.Write("Nhap ten san pham can tim: ");
                                 string ten = Console.ReadLine();
                                 DataTable dt = quanly.TimKiemSanPhamTheoTen(ten);
                                 if (dt != null)
                                 {
                                     Console.WriteLine("Cac san pham o the la san pham ban tim: ");
                                     foreach (DataRow row in dt.Rows)
                                     {
                                         Console.WriteLine(row[0] + " - " + row[1] + " - " + row[2] + " - " + row[3] + " - " + row[4]);
                                     }
                                 }
                                 else
                                 {
                                     Console.Write("Khong tim thay !!!");
                                 }
                             }
                             catch (Exception ex)
                             {
                                 Console.WriteLine("Loi" + ex.ToString());
                             }
                             break;
                         }
                    case 6:
                         {
                             try
                             {
                                 DataTable dt = quanly.LoadTatCaSanPham();
                                 TxtReportGeneraion txtReportGeneraion = new TxtReportGeneraion();
                                 StreamWriter file = new StreamWriter(@"test.txt");
                                 foreach (DataRow row in dt.Rows)
                                 {
                                     string line = row[0] + " - " + row[1] + " - " + row[2] + " - " + row[3] + " - " + row[4];
                                     txtReportGeneraion.GenerateReport(line, ref file);
                                 }
                             }
                             catch (Exception ex)
                             {
                                 Console.WriteLine("Loi" + ex.ToString());
                             }
                             break;
                         }
                    case 7:
                        {
                            Console.WriteLine("Thoat !!! ");
                            return;
                        }
                }
                Console.WriteLine();
            }
        }
    }
}
