using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehicleLoan.Models;

namespace VehicleLoan.Controllers
{
    public class AdminController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Admin
        public ActionResult Index()
        {
            if (Session["AdminName"] != null)
            {
                return View(db.Customers.ToList());
            }
            else
                return RedirectToAction("Login", "Admin");
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["AdminName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Customer customer = db.Customers.Find(id);
                if (customer == null)
                {
                    return HttpNotFound();
                }
                return View(customer);
            }
            else
                return RedirectToAction("Login", "Admin");
        }


        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["AdminName"] != null) {         

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
            else
                return RedirectToAction("Login", "Admin");
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["AdminName"] != null)
            {
                Customer customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Login", "Admin");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin admin)
        {
            using (AppDBContext db = new AppDBContext())
            {
                var obj = db.Admins.Where(a => a.AdminName.Equals(admin.AdminName) && a.Password.Equals(admin.Password)).FirstOrDefault();



                if (obj != null)
                {

                    Session["AdminName"] = obj.AdminName.ToString();


                    return RedirectToAction("DashBoard", "Admin");
                }
                else
                {
                    ViewBag.Message = "user not found for given Email and Password";
                    return View();
                }
            }
        }
        public ActionResult DashBoard()
        {
            if (Session["AdminName"] != null)
            {
                ViewBag.Name = Session["AdminName"].ToString();
                return View();
            }
            else
                return RedirectToAction("Login", "Admin");
        }

        public ActionResult ViewLoans()
        {
            if (Session["AdminName"] != null)
            {
                return View(db.Loans.ToList());
            }
            else
                return RedirectToAction("Login", "Admin");
        }


        // GET: Loans/Delete/5
        public ActionResult DeleteLoan(int? id)
        {
            if (Session["AdminName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Loan loan = db.Loans.Find(id);
                if (loan == null)
                {
                    return HttpNotFound();
                }
                return View(loan);
            }
            else
                return RedirectToAction("Login", "Admin");

        }

        // POST: Loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLoanConfirmed(int id)
        {
            if (Session["AdminName"] != null)
            {
                Loan loan = db.Loans.Find(id);
                db.Loans.Remove(loan);
                db.SaveChanges();
                return RedirectToAction("ViewLoans");
            }
            else
                return RedirectToAction("Login", "Admin");
        }

        // GET: Loans/Details/5
        public ActionResult DetailsLoan(int? id)
        {
            if (Session["AdminName"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Loan loan = db.Loans.Find(id);
                if (loan == null)
                {
                    return View("Create");
                    //return HttpNotFound();
                }
                return View(loan);
            }
            else
                return RedirectToAction("Login", "Admin");
        }

        public ActionResult Accepted(int id)
        {
            if (Session["AdminName"] != null)
            {

                using (var db = new AppDBContext())
                {
                    var result = db.Loans.SingleOrDefault(b => b.LoanID == id);
                    if (result != null)
                    {
                        result.Status = "Accepted";
                        db.SaveChanges();
                        return RedirectToAction("ViewLoans", "Admin");
                    }
                    else
                        return View();
                }
            }
            else
                return RedirectToAction("Login", "Admin");

        }
        public ActionResult Declined(int id)
        {
            if (Session["AdminName"] != null)
            {
                using (var db = new AppDBContext())
                {
                    var result = db.Loans.SingleOrDefault(b => b.LoanID == id);
                    if (result != null)
                    {
                        result.Status = "Declined";
                        db.SaveChanges();
                        return RedirectToAction("ViewLoans", "Admin");
                    }
                    else
                        return View();
                }
            }
            else
                return RedirectToAction("Login", "Admin");
        }
    }
}
