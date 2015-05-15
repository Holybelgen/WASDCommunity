using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Wasd.Models;
using Wasd.Services;
using Microsoft.AspNet.Identity;


namespace Wasd.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /UserPost/
        public ActionResult PostList()
        {
            var ser = new userPostService();
            var posts = ser.getPostsFromFriends(User.Identity.GetUserId());

            return View(posts.OrderByDescending(p => p.date).ToList());
        }

        // GET: /UserPost/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPost userpost = db.UserPosts.Find(id);
            if (userpost == null)
            {
                return HttpNotFound();
            }
            return View(userpost);
        }

        // GET: /UserPost/Create
        public ActionResult Index()
        {
            return View();
        }

        // POST: /UserPost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,userName,userID,content,date")] UserPost userpost)
        {
            var currUserId = User.Identity.GetUserId();
            var currUserName = User.Identity.GetUserName();

            userpost.userName = currUserName;
            userpost.userID = currUserId;

            string format = "ddd MMM d HH:mm yyyy";

            userpost.date = DateTime.Now.ToString(format);

            var userPostSer = new userPostService();
            if (ModelState.IsValid)
            {
                userPostSer.addUserPost(userpost);
                return RedirectToAction("Index");
            }
            
            return View(userpost);
        }

        // GET: /UserPost/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPost userpost = db.UserPosts.Find(id);
            if (userpost == null)
            {
                return HttpNotFound();
            }
            return View(userpost);
        }

        // POST: /UserPost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID,Content,Date")] UserPost userpost)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userpost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userpost);
        }

        // GET: /UserPost/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPost userpost = db.UserPosts.Find(id);
            if (userpost == null)
            {
                return HttpNotFound();
            }
            return View(userpost);
        }

        // POST: /UserPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserPost userpost = db.UserPosts.Find(id);
            db.UserPosts.Remove(userpost);
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