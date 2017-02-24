using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{       
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ExtremeDbContext db = new ExtremeDbContext();   
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Services() {

            return View(db.Services);
        }

      

        public ActionResult Create()
        {
            return View("Edit", new Service());
        }

          // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
           Service service =  db.Services.FirstOrDefault(s=>s.Id==id);

            return View(service);
        }

        [HttpPost]
         public ActionResult Edit(Service service, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    service.ImageMimeType = image.ContentType;
                    service.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(service.ImageData, 0, image.ContentLength);
                }

                if (service.Id == 0)
                {
                    db.Services.Add(service);
                }
                else
                {
                    Service dbEntry = db.Services.Find(service.Id);
                    if (dbEntry != null)
                    {
                        dbEntry.name = service.name;
                        dbEntry.price = service.price;
                        dbEntry.TimeLimit = service.TimeLimit;
                        dbEntry.shortDescription = service.shortDescription;
                        dbEntry.description = service.description;
                        if (image != null)
                        {
                            dbEntry.ImageData = service.ImageData;
                            dbEntry.ImageMimeType = service.ImageMimeType;
                        }
                    }
                }
                    db.SaveChanges();
                if (service.Id != 0)
                {
                    TempData["message"] = string.Format("Послуга була змінена  \" {0} \". Зміни збережено", service.name);
                }
                else
                {
                    TempData["message"] = string.Format("Послуга була створена \" {0} \". Зміни збережено", service.name);
                }
                return RedirectToAction("Services");
                
            }
        
                // Что-то не так со значениями данных
                return View(service);
          
        }
    
      
        public ActionResult Delete(int Id)
        {

            Service dbEntry = db.Services.Find(Id);
         
            if (dbEntry != null) {
                db.Services.Remove(dbEntry);
                db.SaveChanges();
            }
            TempData["message"] = String.Format("Послуга була видалена \"{0}\". Зміни збережено.", dbEntry.name);
                return RedirectToAction("Services");
            }

        public ActionResult Posts() {

            return View(db.Posts);
        }

        public ActionResult EditPost(int Id)
        {
            Post post = db.Posts.Find(Id);
            if (post != null)
            {
                return View(post);
            }
            else {
                 TempData["error"] = string.Format("Упс.. щось пішло не так. Спробуйте ща раз пізніше");
                return RedirectToAction("Posts");
            }
        }
        [HttpPost]
        public ActionResult EditPost(Post post, HttpPostedFileBase image)
        {

            if (image != null)
            {
                post.ImageMimeType = image.ContentType;
                post.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(post.ImageData, 0, image.ContentLength);
            }
            if (ModelState.IsValid)
            {
                if (post.Id == 0)
                {
                    db.Posts.Add(post);
                }
                else
                {
                    Post dbEntry = db.Posts.Find(post.Id);
                    if (dbEntry != null)
                    {
                        dbEntry.Title = post.Title;
                        dbEntry.Text = post.Text;
                        dbEntry.Tags = post.Tags;
                        dbEntry.Date = post.Date;
                        if (image != null)
                        {
                            dbEntry.ImageMimeType = post.ImageMimeType;
                            dbEntry.ImageData = post.ImageData;
                        }
                    }
                }
                db.SaveChanges();
                if (post.Id != 0)
                {
                    TempData["message"] = string.Format("Стаття була змінена  \" {0} \". Зміни збережено", post.Title);
                }
                else
                {
                    TempData["message"] = string.Format("Стаття була створена \" {0} \". Зміни збережено", post.Title);
                }
                return RedirectToAction("Posts");

            }

            TempData["error"] = string.Format("Упс.. щось пішло не так. Спробуйте ща раз пізніше");

            // Что-то не так со значениями данных
            return View(post);

        }

        public ActionResult CreatePost() {

            return View("EditPost", new Post());
            }

        public ActionResult DeletePost(int Id) {

            Post dbEntry = db.Posts.Find(Id);

            if (dbEntry != null)
            {
                db.Posts.Remove(dbEntry);
                db.SaveChanges();

                TempData["message"] = string.Format("Стаття була видалена \"{0}\". Зміни збережено.", dbEntry.Title);
            }
            else {
                TempData["error"] = string.Format("Сталася Помилка. Нажаль не вдалося выдалити статтю." );
            }

           return RedirectToAction("Posts");

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

        public FileContentResult GetImageForPost(int Id)
        {
            Post post = db.Posts
                .FirstOrDefault(g => g.Id == Id);
            if (post != null)
            {
                if (post.ImageData != null && post.ImageMimeType != null)
                {
                    return File(post.ImageData, post.ImageMimeType);
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        
        public PartialViewResult EditImage() {

            return PartialView();
        }

    }
    }

