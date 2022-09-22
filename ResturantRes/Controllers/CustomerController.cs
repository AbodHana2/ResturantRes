using Microsoft.AspNetCore.Mvc;
using ResturantRes.Models;
using ResturantReservation.Data;

namespace ResturantRes.Controllers
{
    public class CustomerController : Controller
    {
        private readonly AppContextDb _db;

        public CustomerController(AppContextDb db)
        {
            _db = db;
        }

        //GET
        public IActionResult Index()
        {
            IEnumerable<Customer> objList = _db.customers;
            return View(objList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer _cus)
        {
            if(_db.customers.Any(c => c.ReservationDate == _cus.ReservationDate))
            {
                ModelState.AddModelError("CustomError", "This Date Is Already Exist");
            }
            if (ModelState.IsValid)
            {
                _db.customers.Add(_cus);
                _db.SaveChanges();
                TempData["Success"] = "Reservation Created Successfully";
                return RedirectToAction("Index");
            }
            return View(_cus);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var customer = _db.customers.FirstOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer _cus)
        {
            if (_db.customers.Any(c => c.ReservationDate == _cus.ReservationDate))
            {
                ModelState.AddModelError("CustomError", "This Date Is Already Exist");
            }
            if (ModelState.IsValid)
            {
                _db.customers.Update(_cus);
                _db.SaveChanges();
                TempData["Success"] = "Reservation Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(_cus);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var customer = _db.customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var customer = _db.customers.Find(id);
            if(customer == null)
            {
                return NotFound();
            }
           _db.customers.Remove(customer);
           _db.SaveChanges();
           TempData["Success"] = "Reservation Deleted Successfully";
           return RedirectToAction("Index");
        }
    }
}
