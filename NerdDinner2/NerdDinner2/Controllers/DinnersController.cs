using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NerdDinner2.Models;

namespace NerdDinner2.Controllers
{
    public class DinnersController : Controller
    {
        DinnerRepository dinnerRepository = new DinnerRepository();
        //
        // GET: /Dinners/

        public ActionResult Index(int? page)
        {
            // inital test write
            //Response.Write("<h1>Coming Soon: Dinners</h1>");

            //var dinners = dinnerRepository.FindUpcomingDinners().ToList();

            const int pageSize = 10;

            var upcomingDinners = dinnerRepository.FindUpcomingDinners();

            var paginatedDinners = new PaginatedList<Dinner>(upcomingDinners, page ?? 0, pageSize);

            return View(paginatedDinners);
        }

        // get /Dinners/Details/id
        public ActionResult Details(int id)
        {
            // initial test write
            //Response.Write("<h1>Details DinnerID: " + id + "</h1>");

            Dinner dinner = dinnerRepository.GetDinner(id);

            if (dinner == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(dinner);
            }
        }

        // get /Dinners/Edit/id
        public ActionResult Edit(int id)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            ViewData["Countries"] = new SelectList(PhoneValidator.Countries, dinner.Country);

            //return View(dinner);

            return View(new DinnerFormViewModel(dinner));
        }

        // post
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            try
            {
                UpdateModel(dinner);

                dinnerRepository.Save();

                return RedirectToAction("Details", new { id = dinner.DinnerID });
            }
            catch
            {
                ModelState.AddRuleViolations(dinner.GetRuleViolations());

                return View(new DinnerFormViewModel(dinner));
            }
        }

        // get /Dinners/Create
        public ActionResult Create()
        {
            Dinner dinner = new Dinner()
                                {
                                    EventDate = DateTime.Now.AddDays(7)
                                };
            return View(new DinnerFormViewModel(dinner));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Dinner dinner)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    dinner.HostedBy = "SomeUser";
                    
                    dinnerRepository.Add(dinner);

                    dinnerRepository.Save();

                    return RedirectToAction("Details", new {id = dinner.DinnerID});
                }
                catch
                {
                    ModelState.AddRuleViolations(dinner.GetRuleViolations());
                }
            }

            return View(new DinnerFormViewModel(dinner));
        }

        public ActionResult Delete(int id)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            if (dinner == null)
            {
                return View("NotFound");
            }
            else
            {
                return View(dinner);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int id, string confirmButton)
        {
            Dinner dinner = dinnerRepository.GetDinner(id);

            if (dinner == null)
            {
                return View("NotFound");
            }
            else
            {
                dinnerRepository.Delete(dinner);
                dinnerRepository.Save();

                return View("Deleted");
            }
        }
    }
}
