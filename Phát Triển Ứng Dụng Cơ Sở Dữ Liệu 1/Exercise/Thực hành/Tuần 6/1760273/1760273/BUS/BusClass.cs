using _1760273.DAO;
using _1760273.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760273.BUS
{
    public class BusClass
    {
        static DaoClass daoClass = new DaoClass();

        public int InsertOneClass(DtoClass other)
        {
            if (other.MaLop == "")
            {
                return 0;
            }

            return daoClass.InsertOneClass(other);
        }

        public int DeleteOneClass(string maLop)
        {
            if (maLop == "")
            {
                return 0;
            }

            return daoClass.DeleteOneClass(maLop);
        }

        public int UpdateOneClass(DtoClass other)
        {
            if (other.MaLop == "")
            {
                return 0;
            }

            return daoClass.UpdateOneClass(other);
        }

        public DataTable LoadListClasses()
        {
            return daoClass.LoadListClasses();
        }
    }
}
