using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieIndex.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieIndex.Controllers 
{
    public class GenresController : Controller
    {
        private readonly MovieIndexContext _db;
        public GenresController(MovieIndexContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Genre> model = _db.Genres.ToList();
            return View(model);
        }
        
        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            _db.Genres.Add(genre);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult Details(int id)
        {
            Genre thisGenre = _db.Genres
            .Include(genre => genre.Movies)
            .ThenInclude(join => join.Movie)
            .FirstOrDefault(genre => genre.GenreId == id);
            return View(thisGenre);
        }

        public ActionResult Edit(int id)
        {
            Genre thisGenre = _db.Genres.FirstOrDefault(genres => genres.GenreId == id);
            return View(thisGenre);
        }
        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            _db.Entry(genre).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}