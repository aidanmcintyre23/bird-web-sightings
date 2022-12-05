using System.Collections.Generic;
using System.Linq;
using BirdWebsightings.DataAccess;

namespace BirdWebsightings.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public int NumberOfBirds { get; set; }

        public static class Queries
        {
            public static IEnumerable<Result> All()
            {
                var results = new DataAccessController(new BirdSightingDataAccess()).GetAll();
                return results.Select(x => Map(x));
            }

            public static Result Map(BirdSighting birdSighting)
                => new Result
                {
                    Id = birdSighting.Id,
                    Location = birdSighting.Location,
                    Description = birdSighting.Description,
                    Date = birdSighting.Date.ToShortDateString(),
                    NumberOfBirds = birdSighting.NumberOfBirds
                };

        }
    }
}