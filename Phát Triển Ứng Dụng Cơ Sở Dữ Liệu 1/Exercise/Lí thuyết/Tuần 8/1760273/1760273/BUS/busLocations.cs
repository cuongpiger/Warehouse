using _1760273.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760273.BUS
{
    public class busLocations
    {
        static dalLocations dalLoca = new dalLocations();

        public DataTable LoadLocations()
        {
            return dalLoca.sLoadLocations();
        }
    }
}
