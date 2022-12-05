using System;
using BirdWebsightings.DataAccess;
using BirdWebsightings.Models;
using Microsoft.AspNetCore.Mvc;

namespace BirdWebsightings.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
            => View(IndexViewModel.Load());

        [Route("/report-sighting")]
        public IActionResult ReportSighting()
            => View(ReportSightingViewModel.Load());

        [HttpPost]
        [Route("/submit-report")]
        public IActionResult SubmitReport(string location, string description, DateTime date, int numberOfBirds)
        {
            new BirdSightingDataAccess().InsertBirdSighting(location, description, date, numberOfBirds);

            return View("Index", IndexViewModel.Load());
        }
    }
}