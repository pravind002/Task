using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Emp.Models;

namespace Emp.Controllers
{
    public class EmployeeesController : Controller
    {
        private ProductMasterEntities1 db = new ProductMasterEntities1();

        // GET: Employeees
        public async Task<ActionResult> Index()
        {
            return View(await db.Employeees.ToListAsync());
        }

        // GET: Employeees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeee employeee = await db.Employeees.FindAsync(id);
            if (employeee == null)
            {
                return HttpNotFound();
            }
            return View(employeee);
        }

        // GET: Employeees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employeees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmpId,EMPLOYEE_CODE,EMPLOYEE_NAME,GENDER,DOJ,ADDRESS")] Employeee employeee)
        {
            if (ModelState.IsValid)
            {
                db.Employeees.Add(employeee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employeee);
        }

        // GET: Employeees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeee employeee = await db.Employeees.FindAsync(id);
            if (employeee == null)
            {
                return HttpNotFound();
            }
            return View(employeee);
        }

        // POST: Employeees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmpId,EMPLOYEE_CODE,EMPLOYEE_NAME,GENDER,DOJ,ADDRESS")] Employeee employeee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employeee);
        }

        // GET: Employeees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employeee employeee = await db.Employeees.FindAsync(id);
            if (employeee == null)
            {
                return HttpNotFound();
            }
            return View(employeee);
        }

        // POST: Employeees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employeee employeee = await db.Employeees.FindAsync(id);
            db.Employeees.Remove(employeee);
            await db.SaveChangesAsync();
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
