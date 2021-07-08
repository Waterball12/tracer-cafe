using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TracerCafe.Domain.Models;
using TracerCafe.Models;

namespace TracerCafe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerRepository _customerRepository;

        public HomeController(ILogger<HomeController> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        /// <summary>Homepage of the website, fetch all the available <see cref="Customer"/></summary>
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync(cancellationToken);

            return View(customers);
        }

        /// <summary>Displays the Create page</summary>
        [HttpGet]
        public IActionResult Create() => View();
        
        /// <summary>Displays the Edit page and allows to edit a <see cref="Customer"/></summary>
        [HttpGet]
        public async Task<ActionResult> Edit(Customer customer)
        {
            var result = await _customerRepository.FindByIdAsync(customer.Id);

            return View(result);
        }
        
        /// <summary>Create a new <see cref="Customer"/></summary>
        [HttpPost]
        public async Task<ActionResult> Create(Customer customer, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.AddAsync(customer, cancellationToken);

            return RedirectToAction("Index");
        }
        
        /// <summary>Delete an existing <see cref="Customer"/></summary>
        [HttpPost]
        public async Task<ActionResult> Delete(Customer customer, CancellationToken cancellationToken)
        {
            var result = await _customerRepository.DeleteAsync(customer, cancellationToken);
            
            return RedirectToAction("Index");
        }
        
        /// <summary>Edit an existing <see cref="Customer"/></summary>
        [HttpPost]
        public async Task<ActionResult> Edit(Customer customer, CancellationToken cancellationToken)
        {
            var updated = await _customerRepository.UpdateAsync(customer, cancellationToken);
            
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
