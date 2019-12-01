using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DTO
{
    public class Product
    {
        private int productID;
        private string productName;
        private int supplierID;
        private int categoryID;
        private string quantityPerUnit;
        private decimal unitPrice;
        private int unitsInStock;
        private int unitsOnOrder;
        private int reorderLevel;
        private bool discontinued;

        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int SupplierID { get => supplierID; set => supplierID = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string QuantityPerUnit { get => quantityPerUnit; set => quantityPerUnit = value; }
        public decimal UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int UnitsInStock { get => unitsInStock; set => unitsInStock = value; }
        public int UnitsOnOrder { get => unitsOnOrder; set => unitsOnOrder = value; }
        public int ReorderLevel { get => reorderLevel; set => reorderLevel = value; }
        public bool Discontinued { get => discontinued; set => discontinued = value; }
    }
}
