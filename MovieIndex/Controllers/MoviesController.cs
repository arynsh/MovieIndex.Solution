using Microsoft.AspNetCore.Mvc;
using MovieIndex.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieIndex.Controllers
{                
    public class MoviesController : Controller
    {     
        private readonly MovieIndexDbContext _db;

        public MoviesController(MovieIndexDbContext db)
        {
            _db = db;
        }                                                                                                                                         public ActionResult Index()
        {
            List<Movie> model = _db.Movies.ToList();
            return View(model);        
        }
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie, int GenreId)
        {
            _db.Movies.Add(movie);
            if(GenreId != 0)
            {
                _db.GenreMovie.Add(new GenreMovie(){ GenreId = GenreId, MovieId = movie.MovieId});
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisMovie = _db.Movies
                .Include(movie => movie.Genres)
                .ThenInclude(join => join.Genre)
                .FirstOrDefault(movie => movie.MovieId == id);
            return View(thisMovie);
        }

        public ActionResult Edit(int id)
        {
        var thisMovie = _db.Movies.FirstOrDefault(movies => movies.MovieId == id);
        ViewBag.GenreId = new SelectList(_db.Genres, "GenreId", "Name");
        return View(thisMovie);
        }
        [HttpPost]
        public ActionResult Edit(Movie movie, int GenreId)
        {
        // Item previousItem = _db.movies.Include(movies => movies.Categories).ThenInclude(join => join.Genre).FirstOrDefault(items => items.ItemId == item.ItemId);
        GenreMovie join = _db.GenreMovie.FirstOrDefault(genMovie => genMovie.GenreId == GenreId && genMovie.MovieId == movie.MovieId);
        if (GenreId != 0 && join == null)
        {
            _db.GenreMovie.Add(new GenreMovie() { GenreId = GenreId, MovieId = movie.MovieId});
        }
        _db.Entry(movie).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
        var thisMovie = _db.Movies.FirstOrDefault(movies => movies.MovieId == id);
        return View(thisMovie);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
        var thisMovie = _db.Movies.FirstOrDefault(movies => movies.MovieId == id);
        _db.Movies.Remove(thisMovie);
        _db.SaveChanges();
        return RedirectToAction("Index");
        }
    }
}             