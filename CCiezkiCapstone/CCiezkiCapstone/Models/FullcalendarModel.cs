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
        [Display(Name = "Your name")]
        public string title { get; set; }

        [Required]
        [Display(Name = "Enter date you would like a cleaning")]
        public DateTime date { get; set; }

        //[Required]
        //[Display (Name = "Event Start Time")]
        //public string start { get; set; }

        //[Display(Name = "Event End Time")]
        //public string end { get; set; }


        //[Display(Name = "Enter URL")]
        //public string url { get; set; }

        //[Required]
        //[Display(Name = "Enter description of cleaning")]
        //public string description { get; set; }


    }
}