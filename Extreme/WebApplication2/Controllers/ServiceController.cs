using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service

        ExtremeDbContext db = new ExtremeDbContext();

        public ActionResult Index()
        {
             return View(db.Services);
        }

        public FileContentResult GetImage(int Id)
        {
            Service service = db.Services
                .FirstOrDefault(g => g.Id == Id);

            if (service.ImageData != null && service.ImageMimeType != null)
            {
                return File(service.ImageData, service.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}