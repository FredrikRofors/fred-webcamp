﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GeekQuiz.Models;

namespace GeekQuiz.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        private TriviaContext db = new TriviaContext();

        // GET: Questions
        public ActionResult Index()
        {
            return View(db.TriviaQuestions.ToList());
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriviaQuestion triviaQuestion = db.TriviaQuestions.Find(id);
            if (triviaQuestion == null)
            {
                return HttpNotFound();
            }
            return View(triviaQuestion);
        }

        // GET: Questions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Hint")] TriviaQuestion triviaQuestion)
        {
            if (ModelState.IsValid)
            {
                db.TriviaQuestions.Add(triviaQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(triviaQuestion);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriviaQuestion triviaQuestion = db.TriviaQuestions.Find(id);
            if (triviaQuestion == null)
            {
                return HttpNotFound();
            }
            return View(triviaQuestion);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Hint")] TriviaQuestion triviaQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(triviaQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(triviaQuestion);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TriviaQuestion triviaQuestion = db.TriviaQuestions.Find(id);
            if (triviaQuestion == null)
            {
                return HttpNotFound();
            }
            return View(triviaQuestion);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TriviaQuestion triviaQuestion = db.TriviaQuestions.Find(id);
            db.TriviaQuestions.Remove(triviaQuestion);
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
