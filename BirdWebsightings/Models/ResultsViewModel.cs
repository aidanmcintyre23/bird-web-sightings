
using System.Collections.Generic;

namespace BirdWebsightings.Models
{
    public class ResultsViewModel
    {
        public IEnumerable<Result> Results { get; set; }

        public static ResultsViewModel Load()
            => new ResultsViewModel
            {
                Results = Result.Queries.All()
            };
    }
}