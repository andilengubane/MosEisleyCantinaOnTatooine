using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MosEisleyCantinaOnTatooine.DTO
{
    public class MenuItemsDTO
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image_Url { get; set; }
    }
}
