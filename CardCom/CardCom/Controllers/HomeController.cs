using CardCom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using DataLibrary.Logic;
using DataLibrary.Models;

namespace CardCom.Controllers
{
    public class HomeController : Controller
    {

        //View entries
        public ActionResult ViewPersons()
        {
            var data = PersonProccesor.LoadPersons();
            List<Person> persons = new List<Person>();

            foreach(var row in data)
            {
                persons.Add(new Person
                {
                    PersonId = row.PersonId,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    EmailAddress = row.EmailAddress,
                    ConfirmEmailAddress = row.EmailAddress,
                    DateOfBirth = row.DateOfBirth,
                    PhoneNumber = row.PhoneNumber

                });
            }
            return View(persons);
        }

        //Update selected entry
        public ActionResult Edit(string id)
        {
            var person =  PersonProccesor.LoadPerson(id);
            Person edited = new Person
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                EmailAddress = person.EmailAddress,
                ConfirmEmailAddress = person.EmailAddress,
                DateOfBirth = person.DateOfBirth,
                PhoneNumber = person.PhoneNumber
            };

            return View(edited);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonM model)
        {

            if (ModelState.IsValid)
            {
                int records = PersonProccesor.UpdatePerson(model.PersonId,
                                                            model.FirstName,
                                                            model.LastName,
                                                            model.EmailAddress,
                                                            model.DateOfBirth,
                                                            model.Gender,
                                                            model.PhoneNumber);
                return RedirectToAction("ViewPersons");
            }
            return View();

            
        }
       
        public ActionResult Delete(String id)
        {
            PersonProccesor.DeletePerson(id);

            return RedirectToAction("ViewPersons");
        }


        public ActionResult SignUp()
        {
            ViewBag.Message = "Sign Up";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Person model)
        {
            bool hasPerson = !(PersonProccesor.Hasperson(model.PersonId));

            if (ModelState.IsValid && hasPerson)
            {
              int records =  PersonProccesor.CreatePerson(model.PersonId,
                                                          model.FirstName,
                                                          model.LastName,
                                                          model.EmailAddress,
                                                          model.DateOfBirth,
                                                          model.Gender,
                                                          model.PhoneNumber);
                return RedirectToAction("ViewPersons");
            }
            ModelState.AddModelError("PersonId", "ID Exists");
            return View();
        }
    }
}