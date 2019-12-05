using _1760273.DAL;
using _1760273.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760273.BUS
{
    public class busApartment
    {
        static dalApartment dalApartment = new dalApartment();

        public DataTable LoadApartment()
        {
            return dalApartment.LoadApartment();
        }

        public int MaxIDApartment()
        {
            var res = dalApartment.MaxIDApartment();

            if (res is null)
            {
                return 0;
            }

            return int.Parse(res.Rows[0][0].ToString());
        }

        public int InsertApartment(dtoApartment other)
        {
            return dalApartment.InsertApartment(other);
        }

        public int DeleteApartment(int id)
        {
            return dalApartment.DeleteApartment(id);
        }

        public DataTable LoadApartmentWithID(int id)
        {
            return dalApartment.LoadApartmentWithID(id);
        }

        public int UpdateApartment(dtoApartment other)
        {
            return dalApartment.UpdateApartment(other);
        }
    }
}
