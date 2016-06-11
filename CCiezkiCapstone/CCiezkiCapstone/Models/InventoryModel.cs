using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CCiezkiCapstone.Models
{
    public class InventoryModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string productName { get; set; }

        [Required]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal price { get; set; }

        [Display(Name = "Quantity")]
        public int quantity { get; set; }

        [Display(Name = "Warning sent at")]
        public int warningSent { get; set; }

        [Required]
        [Display(Name = "Warning Level")]
        public int warningLevel { get; set; }

        [Required]
        [Display(Name = "Refill Level")]
        public int refillLevel { get; set; }
    }
}