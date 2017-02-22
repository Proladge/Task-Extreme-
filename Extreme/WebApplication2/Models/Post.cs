using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Post
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int IdAuthor { get; set; }

        [Display(Name = "Назва")]
        public String Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Текст")]
        public String Text { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Display(Name = "Теги(вказані через кому)")]
        public String Tags { get; set; }

        [Display(Name = "Зображення")]
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}