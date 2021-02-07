using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CategoryOfProductsDTO : IDto
    {
        public string CategoryName { get; set; }
        public int NumberOfProducts { get; set; }
        public decimal TotalPrice { get; set; }      
        public decimal MaxPrice { get; set; }      
        public decimal MinPrice { get; set; }      

    }
}
