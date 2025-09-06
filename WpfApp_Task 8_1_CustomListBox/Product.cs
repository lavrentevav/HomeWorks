using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_Task_8_1_CustomListBox
{
    public enum ProductCategory
    {
        Food,
        HouseholdEquipment
    }

    public class Product(string name, decimal price, string imagePath, ProductCategory category)
    {
        public string ProductName { get; set; } = name;
        public decimal Price { get; set; } = price;
        public string ImagePath { get; set; } = imagePath;
        public ProductCategory Category { get; set; } = category;
    }
}
