using CustomerMicroservice.Managers;
using CustomerMicroservice.Models;
using CustomerMicroservice.Validators;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly CustomerManager customerManager;
        private readonly CatContext _context;
        private readonly CustomerValidator validator = new CustomerValidator();

        public CustomerController(CatContext context)
        {
            _context = context;
            customerManager = new CustomerManager(_context);

        }


        //GET : Api/Customer/GetAll
        [HttpGet]
        [Route("Api/Customer/GetAll")]
        public IEnumerable<Customer> GetCustomerList()
        {
            System.Console.WriteLine("Api/Customer/GetAll");
            return customerManager.GetAllByName().ToList();
        }

        //GET: Api/Customer/GetCustomerByFirstName
        [HttpGet]
        [Route("Api/Customer/GetCustomerByFirstName")]
        public IEnumerable<Customer> GetByCustomerFirstName(string name)
        {
            if (name.Trim() != null)
            {
                return customerManager.GetByFirstName(name.Trim()).ToList();
            }
            else
            {
                throw new DataException($"Cant Search For '{name}'.");
            }
        }

        //GET: Api/Customer/GetCustomerByLastName
        [HttpGet]
        [Route("Api/Customer/GetCustomerByLastName")]
        public IEnumerable<Customer> GetByCustomerLastName(string name)
        {
            if (name.Trim() != null)
            {
                return customerManager.GetByLastName(name.Trim()).ToList();
            }
            else
            {
                throw new DataException($"Cant Search For '{name}'.");
            }

        }

        //GET: Api/Customer/GetByEmailAddress
        [HttpGet]
        [Route("Api/Customer/GetByCustomerEmailAddress")]
        public IEnumerable<Customer> GetByCustomerEmailAddress(string email)
        {
            if (email.Trim() != null)
            {
                return customerManager.GetByEmail(email.Trim()).ToList();
            }
            else
            {
                throw new DataException($"Cant Search For '{email}'.");
            }
        }

        // POST: Customer/Create
        [HttpPost]
        [Route("Api/Customer/Create")]
        public ActionResult Create(string fName, string lName, string teleNum, string mobNum, string address1, string address2, string town, string postcode, string user, string email)
        {
            Customer owner = new Customer()
            {

                FirstName = fName.Trim(),
                LastName = lName.Trim(),
                TeleNumber = teleNum.Trim(),
                MobNumber = mobNum.Trim(),
                Address1 = address1.Trim(),
                Address2 = address2.Trim(),
                Town = town.Trim(),
                Postcode = postcode.Trim(),
                UserId = user.Trim(),
                Email = email.Trim(),
                Cats = 0

            };
            ValidationResult result = validator.Validate(owner);
            if (!result.IsValid)
            {
                validator.ValidateAndThrow(owner);

            }
            else if (ModelState.IsValid)
            {
                customerManager.Create(owner);
                //customerManager.AddCatToCustomer(cats.ToList(), owner.ID);
                return Ok(owner);
            }

            throw new DataException("error");
        }
        // POST: Customer/Edit/5
        [HttpPatch]
        [Route("Api/Customer/Edit")]
        public ActionResult Edit(Guid search, string fName, string lName, string teleNum, string mobNum, string address1, string address2, string town, string postcode, string user, string email)
        {
            Customer owner = new Customer()
            {

                FirstName = fName.Trim(),
                LastName = lName.Trim(),
                TeleNumber = teleNum.Trim(),
                MobNumber = mobNum.Trim(),
                Address1 = address1.Trim(),
                Address2 = address2.Trim(),
                Town = town.Trim(),
                Postcode = postcode.Trim(),
                UserId = user,
                Email = email.Trim()

            };
            ValidationResult result = validator.Validate(owner);
            if (customerManager.Find(search) == null)
            {
                throw new DataException("No Customer with that ID was found");
            }
            else if (!result.IsValid)
            {
                validator.ValidateAndThrow(owner);
            }
            else if (ModelState.IsValid)
            {
                customerManager.Update(owner);
            }
            return Ok(owner);
        }

        // POST: Customer/Delete/5
        [HttpDelete]
        [Route("Api/Customer/Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {

            customerManager.Delete(id);
            return Ok();
        }

    }
}
