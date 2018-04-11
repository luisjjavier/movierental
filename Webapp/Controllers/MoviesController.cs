using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Webapp.Models;

namespace Webapp.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movies
        public ActionResult Index()
        {
            var movies = db.Movies.Include(m => m.ApplicationUser).Include(m => m.Language).Include(m => m.OrginalLanguage);

            var moviesViewModel = Mapper.Map<List<MovieViewModel>>(movies.ToList());
            return View(moviesViewModel);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email");
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name");
            ViewBag.OriginalLanguageId = new SelectList(db.Languages, "Id", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                var movie = Mapper.Map<Movie>(movieViewModel);
                movie.Created = DateTime.Now;
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", movieViewModel.ApplicationUserId);
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", movieViewModel.LanguageId);
            ViewBag.OriginalLanguageId = new SelectList(db.Languages, "Id", "Name", movieViewModel.OriginalLanguageId);
            return View(movieViewModel);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", movie.ApplicationUserId);
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", movie.LanguageId);
            ViewBag.OriginalLanguageId = new SelectList(db.Languages, "Id", "Name", movie.OriginalLanguageId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ImageUrl,Description,ReleaseYear,Director,LanguageId,OriginalLanguageId,Price,Rating,ReplacementCost,ApplicationUserId,Created")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "Email", movie.ApplicationUserId);
            ViewBag.LanguageId = new SelectList(db.Languages, "Id", "Name", movie.LanguageId);
            ViewBag.OriginalLanguageId = new SelectList(db.Languages, "Id", "Name", movie.OriginalLanguageId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
