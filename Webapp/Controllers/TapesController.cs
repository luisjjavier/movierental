using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Webapp.Models;

namespace Webapp.Controllers
{
    public class TapesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tapes
        public ActionResult Index()
        {
            var tapes = db.Tapes.Include(t => t.Movie);
            return View(tapes.ToList());
        }

        // GET: Tapes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tape tape = db.Tapes.Find(id);
            if (tape == null)
            {
                return HttpNotFound();
            }
            return View(tape);
        }

        // GET: Tapes/Create
        public ActionResult Create()
        {
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title");
            return View();
        }

        // POST: Tapes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MovieId")] Tape tape)
        {
            if (ModelState.IsValid)
            {
                db.Tapes.Add(tape);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title", tape.MovieId);
            return View(tape);
        }

        // GET: Tapes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tape tape = db.Tapes.Find(id);
            if (tape == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title", tape.MovieId);
            return View(tape);
        }

        // POST: Tapes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MovieId")] Tape tape)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tape).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title", tape.MovieId);
            return View(tape);
        }

        // GET: Tapes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tape tape = db.Tapes.Find(id);
            if (tape == null)
            {
                return HttpNotFound();
            }
            return View(tape);
        }

        // POST: Tapes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tape tape = db.Tapes.Find(id);
            db.Tapes.Remove(tape);
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
