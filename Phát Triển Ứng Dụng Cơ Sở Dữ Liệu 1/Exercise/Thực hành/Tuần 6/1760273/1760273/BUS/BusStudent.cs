using _1760273.DAO;
using _1760273.DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760273.BUS
{
    public class BusStudent
    {
        static DaoStudent daoStudent = new DaoStudent();

        public int InsertOneStudent(DtoStudent other)
        {
            if (other.HoTen == "" || other.MaSV == "")
            {
                return 0;
            }

            return daoStudent.InsertOneStudent(other);
        }
    }
}
