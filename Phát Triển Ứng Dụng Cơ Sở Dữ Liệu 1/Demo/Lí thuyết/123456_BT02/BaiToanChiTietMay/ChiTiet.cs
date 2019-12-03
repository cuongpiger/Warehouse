using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiToanChiTietMay
{
    class ChiTiet
    {
        private string _maSo;

        protected string MaSo
        {
            get { return _maSo; }
            set { _maSo = value; }
        }

        public virtual void Nhap()
        {
        
        }

        public virtual void Xuat()
        { 
        
        }

        public virtual ChiTiet TimKiem(string ms)
        {
            return null;
        }

        public virtual int DemChiTietDon()
        {
            return 0;
        }
    }
}
