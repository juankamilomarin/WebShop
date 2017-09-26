using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    /// <summary>
    /// A Product Entity.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// The identification number of the product.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Number { get; set; }

        /// <summary>
        /// The title of the product.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        /// <summary>
        /// The description of the product.
        /// </summary>
        [StringLength(4000)]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// The price of the product
        /// </summary>
        [Required]
        [RegularExpression(@"^\d{1,18}(\.\d{1,2})?$", 
            ErrorMessage = "Price must be positive and only with two decimal digits (i.e. 15.74)")]
        public decimal Price { get; set; }
    }
}
