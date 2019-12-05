using _1760273.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760273.BUS
{
    public class busCategoryApartment
    {
        static dalCategoryApartment dalCA = new dalCategoryApartment();

        public DataTable LoadCategoryApartment()
        {
            return dalCA.sLoadCategoryApartment();
        }
    }
}
