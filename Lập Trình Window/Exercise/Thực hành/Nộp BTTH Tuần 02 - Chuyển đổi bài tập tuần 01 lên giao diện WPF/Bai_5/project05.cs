using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_5
{
    class project05
    {
        private int ngay, thang, nam;

        public int Ngay { get => ngay; set => ngay = value; }
        public int Thang { get => thang; set => thang = value; }
        public int Nam { get => nam; set => nam = value; }

        public void createDate()
        {
            int[] month = { -1, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            Random r = new Random();

            this.ngay = r.Next(1, 32);
            this.thang = r.Next(1, 13);
            this.nam = r.Next(1900, 2101);

            if (this.isLeapYear() == true)
            {
                ++month[2];
            }

            if (this.ngay > month[this.thang])
            {
                this.createDate();
            }
            else
            {
                return;
            }
        }

        public bool isLeapYear()
        {
            return (((nam % 4 == 0) && (nam % 100 != 0)) || (nam % 400 == 0));
        }

        public string printNextDate()
        {
            this.createDate();

            int ngaysau = this.Ngay, thangsau = this.Thang, namsau = this.Nam;

            int[] month = { -1, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            if (this.isLeapYear() == true)
            {
                ++month[2];
            }

            ++ngaysau;

            if (ngaysau > month[this.Thang])
            {
                ngaysau = 1;
                ++thangsau;

                if (thangsau > 12)
                {
                    thangsau = 1;
                    ++namsau;
                }
            }

           return "Hôm sau: " + ngaysau.ToString() + "/" + thangsau.ToString() + "/" + namsau.ToString();
        }
    }
}
