
using System;

namespace BirdWebsightings.DataAccess
{
    public class BirdSighting
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfBirds { get; set; }
    }
}