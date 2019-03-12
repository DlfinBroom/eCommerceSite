using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceSite.Models {
    public class SearchCriteria {

        /// <summary>
        /// The partial matching product name
        /// </summary>
        [RegularExpression("[A-Za-z]+", ErrorMessage = "name cannot contain any numbers or special characters")]
        public string Name { get; set; }

        [RegularExpression("[A-Za-z]+", ErrorMessage = "category cannot contain any numbers or special characters")]
        public string Category { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "low price cannot be a negative number")]
        public double? LowPrice { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "max price cannot be less then 0.01")]
        public double? HighPrice { get; set; }

        /// <summary>
        /// The product list results from the search criteria
        /// </summary>
        public List<Product> Products { get; set; }
    }
}
