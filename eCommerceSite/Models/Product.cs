using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceSite.Models {
    public class Product {

        [Key]
        public int ProductID { get; set; }

        [Required, StringLength(75)]
        public string Name { get; set; }

        [Required, StringLength(255)]
        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        [Required, Range(0, 1000000), DataType(DataType.Currency)]
        public double Price { get; set; }

    }
}
