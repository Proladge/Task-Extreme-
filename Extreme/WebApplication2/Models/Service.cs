using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Service
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Назва")]
        public String name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Опис")]
        public String description { get; set; }

        [Display(Name = "Ціна (грн)")]
        public int price { get; set;}

        [DataType(DataType.MultilineText)]
        [Display(Name = "Короткий опис")]
        public String shortDescription { get; set; }

        [Display(Name = "Час (хв)")]
        public int TimeLimit { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name ="Зображення")]
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}