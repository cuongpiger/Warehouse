using _1760273.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1760273
{
    public partial class frmMain : Form
    {
        static busCategoryApartment busCA = new busCategoryApartment();
        static busLocations busLoca = new busLocations();
        static busApartment busApt = new busApartment();
        static DataTable dtLoca = new DataTable();
        static DataTable dtCA = new DataTable();
        static DataTable dtAprt = new DataTable();

        private void LoadLocations()
        {
            dtLoca = busLoca.LoadLocations();
        }

        private void LoadCategoryApartment()
        {
            dtCA = busCA.LoadCategoryApartment();
        }

        private void LoadApartment()
        {
            dtAprt = busApt.LoadApartment();
        }

        private void InitTabpageApartment()
        {
            dgvApartment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApartment.AllowUserToAddRows = false;
            dgvApartment.ReadOnly = true;
        }
    }
}
