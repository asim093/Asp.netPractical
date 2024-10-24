using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;

namespace Practical.Models
{
    public class ProductSearchViewModel
    {
        public List<SelectListItem> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}
