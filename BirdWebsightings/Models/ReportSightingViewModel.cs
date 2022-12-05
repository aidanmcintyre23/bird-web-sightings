using System;

namespace BirdWebsightings.Models
{
    public class ReportSightingViewModel
    {
        public string Header { get; set; }
        public string Location { get; set; }
        public DateTime DateOfSighting { get; set; }
        public string Description { get; set; }
        public int NumberOfBirds { get; set; }

        public static ReportSightingViewModel Load()
           => new ReportSightingViewModel
           {
               Header = "Bird Websightings"
           };          
    }
}