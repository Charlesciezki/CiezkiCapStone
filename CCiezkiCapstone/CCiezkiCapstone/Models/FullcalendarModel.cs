using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CCiezkiCapstone.Models
{
    public class FullcalendarModel
    {
        [Key]
        [Required]
        public int event_id { get; set; }

        [Required]
        [Display(Name = "Customer name")]
        public string title { get; set; }

        [Required]
        [Display(Name = "Requested date of cleaning")]
        public DateTime date { get; set; }

        [Required]
        [Display(Name = "Address of cleaning")]
        public string address { get; set; }

        [Required]
        [Display(Name = "Description of cleaning")]
        public string description { get; set; }

        //[Display(Name = "Event End Time")]
        //public string end { get; set; }


        //[Display(Name = "Enter URL")]
        //public string url { get; set; }


    }
}