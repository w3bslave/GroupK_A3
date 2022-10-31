using GroupK_A3.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupK_A3.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Reservation reservation)
        {
            if(reservation.CheckinDateTime >= reservation.CheckoutDateTime || reservation.CheckinDateTime < DateTime.Now)
            {
                ModelState.AddModelError("CheckinDate","Please enter valid CheckIn Date");
            }
            else if(reservation.TotalPerson < 1)
            {
                ModelState.AddModelError("TotalPerson","There should be atleast 1 Person");
            }
            if(ModelState.IsValid)
            {
                return RedirectToAction("Submit", reservation);
            }

            return View(reservation);
        }

        public ActionResult Submit(Reservation reservation)
        {
            List<DateTime> weekends = new List<DateTime>();

            for (DateTime runDate = reservation.CheckinDateTime; runDate <= reservation.CheckoutDateTime; runDate = runDate.AddDays(1))
            {
                if (runDate.DayOfWeek.ToString().ToLower() == "friday" || runDate.DayOfWeek.ToString().ToLower() == "saturday")
                    weekends.Add(runDate);
            }

            ViewBag.roomCost = 30;


            ViewBag.Message = "Registration Successful.";

            ViewBag.WeekendDays = weekends.Count;
            ViewBag.WeekDays = (reservation.CheckoutDateTime - reservation.CheckinDateTime).TotalDays - weekends.Count;
            ViewBag.WeekDaysCost = ViewBag.roomCost * ViewBag.WeekDays;

            ViewBag.WeekendDaysCost = (ViewBag.roomCost + 15) * ViewBag.WeekendDays;

            ViewBag.BeforeTax = (ViewBag.WeekDaysCost + ViewBag.WeekendDaysCost);
            ViewBag.Tax = (ViewBag.BeforeTax * 20) / 100;
            ViewBag.Total = ViewBag.Tax + ViewBag.BeforeTax;
            return View(reservation);
        }
    }
}