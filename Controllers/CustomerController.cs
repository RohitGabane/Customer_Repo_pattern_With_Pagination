using Customer_Repo_Pattern.Models;
using Customer_Repo_Pattern.Service;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Repo_Pattern.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        //Get: Customers
        public IActionResult Index(int pg=1)
        {
            var customers = _customerRepository.GetAll();

            const int pageSize = 5;
            if(pg<1)
                pg= 1;

            int recsCount=customers.Count();
            var pager=new Pager(recsCount,pg,pageSize);
            int recSkip=(pg-1)*pageSize;
            var data = customers.Skip(recSkip).Take(pager.PageSize).ToList(); 
            this.ViewBag.Pager = pager;
            return View(data);

           // return View(customers);
        }

        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Check if the email or phone number already exists
                if (_customerRepository.IsEmailOrPhoneNumberExists(customer.Email, customer.PhoneNumber))
                {
                    ModelState.AddModelError("Email", "Customer with the same email already exists.");
                    ModelState.AddModelError("PhoneNumber", "Customer with the same phone number already exists.");

                    return View(customer);
                }

                _customerRepository.Add(customer);
                return RedirectToAction("Index");
            }

            return View(customer);

        }

        //Get:
        public IActionResult Edit(int id)
        {
            var customer = _customerRepository.GetById(id);
            return View(customer);
        }


        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                // Check if the email or phone number already exists (excluding the current customer)
                if (_customerRepository.IsEmailOrPhoneNumberExists(customer.Email, customer.PhoneNumber, customer.CustomerId))
                {
                    ModelState.AddModelError("Email", "Customer with the same email already exists.");
                    ModelState.AddModelError("PhoneNumber", "Customer with the same phone number already exists.");

                    return View(customer);
                }

                _customerRepository.Update(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }



        //public IActionResult CreateOrEdit(int? id)
        //{
        //    if (id == null)
        //    {
        //        // Create 
        //        return View();
        //    }

        //    // Edit 
        //    var customer = _customerRepository.GetById(id.Value);
        //    return View(customer);
        //}

        //[HttpPost]
        //public IActionResult CreateOrEdit(Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (customer.CustomerId == 0)
        //        {
        //            // Create
        //            _customerRepository.Add(customer);
        //        }
        //        else
        //        {
        //            // Edit
        //            _customerRepository.Update(customer);
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(customer);

        //}

        public IActionResult Delete(int id)
        {
            _customerRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
