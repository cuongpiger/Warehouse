using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760273.DAL
{
    public class dalCategoryApartment
    {
        static dalDB dalDB = new dalDB();

        public DataTable sLoadCategoryApartment()
        {
            return dalDB.GetData("sLoadCategoryApartment");
        }
    }
}
