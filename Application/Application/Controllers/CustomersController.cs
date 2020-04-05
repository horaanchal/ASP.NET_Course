﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;
using Application.ViewModels;

namespace Application.Controllers
{
    public class CustomersController : Controller
    {
        private MyDBContext _context;
        public CustomersController()
        {
            _context = new MyDBContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("New", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id ==0)
            _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
      
            return View(customers);

        }
        public ActionResult Details(int id)
        {
            //var customer = _context.Customers.SingleOrDefault(c=>c.Id==id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("New", viewModel);
        }
     
    }
}