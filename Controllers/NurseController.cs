using Microsoft.AspNetCore.Mvc;
using SS_NurseCore5.BL.Interfaces;
using System.Diagnostics;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using SS_NurseCore5.Models;

namespace SS_NurseCore5.Controllers
{
    public class NurseController : Controller
    {
        private readonly INurseRep Nurse;

        public NurseController(INurseRep nurse)
        {
            Nurse = nurse;
        }

        public IActionResult Index()
        {
            var data = Nurse.Get();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(NurseVM nurse)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Nurse.Add(nurse);
                    return RedirectToAction("Index", "Nurse");
                }
                return View(nurse);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return RedirectToAction("Index", "Nurse");
            }

        }
        public IActionResult Edit(int id)
        {
            var nurse = Nurse.GetNurseById(id);

            return View(nurse);
        }
        [HttpPost]
        [ActionName("Edit")]
        public IActionResult ConfirmEdit(NurseVM nurse)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Nurse.Edit(nurse);
                    return RedirectToAction("Index", "Nurse");
                }

                return View(nurse);
            }
            catch (Exception ex)
            {
                //EventLog log = new EventLog();
                //log.Source = "Admin Dashboard";
                //log.WriteEntry(ex.Message, EventLogEntryType.Error);

                return RedirectToAction("Index", "Nurse");

            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                Nurse.Delete(id);
                return RedirectToAction("Index", "Nurse");
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);

                                return RedirectToAction("Index", "Nurse");

            }
        }


        public IActionResult Details(int id)
        {
            var NurseDetails = Nurse.GetNurseById(id);
            return View(NurseDetails);
        }
    }
}
