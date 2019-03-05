using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceSite.Models {
    /// <summary>
    /// ViewModel for the Product Index page
    /// </summary>
    public class ProductIndexViewModel {
        public List<Product> Products { get; private set; }

        public int MaxPage { get; private set; }
        
        public int CurrPage { get; private set; }

        public ProductIndexViewModel(List<Product> pro, int max, int curPag) {
            Products = pro;
            MaxPage = max;
            CurrPage = curPag;
        }
    }
}
