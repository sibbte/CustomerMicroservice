using CustomerMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerMicroservice.Managers
{
    public class CustomerManager
    {
        private readonly CatContext _context;

        public CustomerManager(CatContext context)
        {
            _context = context;
        }

        public Customer Find(Guid id)
        {
            return _context.Customers.Find(id);
        }

        public void Create(Customer customer)
        {
            if (_context.Customers.Any(x => x.FirstName == customer.FirstName && x.LastName == customer.LastName && x.Email == customer.Email))
            {
                throw new DataException($"There cant be two customers with the same first name, last name and email.\nThe first name of:- '{customer.FirstName.ToString()}',\nLast name of:- '{customer.LastName.ToString()}',\nEmail of:- '{customer.Email.ToString()}'.\nCant be added");

            }
            else if (_context.Customers.Any(x => x.FirstName == customer.FirstName && x.LastName == customer.LastName))
            {
                throw new DataException($"There cant be two customers with the same first name, last name and email.\nThe first name of:- '{customer.FirstName.ToString()}',\nLast name of:- '{customer.LastName.ToString()}'.");
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetAllByName()
        {
            return _context.Customers.OrderBy(x => x.LastName).ToList();
        }

        public IEnumerable<Customer> GetByFirstName(string name)
        {
            IList<Customer> result = new List<Customer>();
            var customer = GetAllByName().OrderBy(x => x.FirstName).ToList();
            for (int i = 0; i < customer.Count(); i++)
            {
                if (customer[i].FirstName.ToString() == name)
                {
                    result.Add(customer[i]);
                }
            }
            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                throw new DataException($"No Customer with the first name, '{name}' was found");
            }

        }

        public IEnumerable<Customer> GetByLastName(string name)
        {
            IList<Customer> result = new List<Customer>();
            var customer = GetAllByName().OrderBy(x => x.FirstName).ToList();
            for (int i = 0; i < customer.Count(); i++)
            {
                if (customer[i].LastName == name)
                {
                    result.Add(customer[i]);
                }
            }
            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                throw new DataException($"No Customer with the Last name, '{name}' was found");

            }

        }


        public IEnumerable<Customer> GetByEmail(string email)
        {
            IList<Customer> result = new List<Customer>();
            var customer = GetAllByName().OrderBy(x => x.Email).ToList();
            for (int i = 0; i < customer.Count(); i++)
            {
                if (customer[i].Email == email)
                {
                    result.Add(customer[i]);
                }
            }
            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                throw new DataException($"No Customer with the Email address, '{email}' was found");
            }
        }
        public IEnumerable<Customer> GetByTeleNum(string TeleNum)
        {
            IList<Customer> result = new List<Customer>();
            var customer = GetAllByName().OrderBy(x => x.TeleNumber).ToList();
            for (int i = 0; i < customer.Count(); i++)
            {
                if (customer[i].TeleNumber == TeleNum)
                {
                    result.Add(customer[i]);
                }
            }
            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                throw new DataException($"No Customer with the telephone number, '{TeleNum}' was found");
            }
        }
        public IEnumerable<Customer> GetByMobNum(string MobNum)
        {
            IList<Customer> result = new List<Customer>();
            var customer = GetAllByName().OrderBy(x => x.MobNumber).ToList();
            for (int i = 0; i < customer.Count(); i++)
            {
                if (customer[i].MobNumber == MobNum)
                {
                    result.Add(customer[i]);
                }
            }
            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                throw new DataException($"No Customer with the mobile number, '{MobNum}' was found");
            }
        }

        public IEnumerable<Customer> GetByPostCode(string PostCode)
        {
            IList<Customer> result = new List<Customer>();
            var customer = GetAllByName().OrderBy(x => x.Postcode).ToList();
            for (int i = 0; i < customer.Count(); i++)
            {
                if (customer[i].Postcode == PostCode)
                {
                    result.Add(customer[i]);
                }
            }
            if (result != null)
            {
                return result.ToList();
            }
            else
            {
                throw new DataException($"No Customer with the postcode, '{PostCode}' was found");
            }
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            if (id == null)
            {
                throw new DataException("Customer Id provided doesnt exsist");
            }
            else
            {
                _context.Customers.Remove(_context.Customers.Find(id));
                _context.SaveChanges();

            }

        }

        public bool Exists(Guid id)
        {
            return _context.Customers.Any(x => x.ID == id);
        }
    }

}