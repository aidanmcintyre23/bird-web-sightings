using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BirdWebsightings.DataAccess
{
    [Route("data-access/[controller]")]
    public class DataAccessController : Controller
    {
        IDataAccess dataAccess;

        public DataAccessController(IDataAccess data)
        {
            dataAccess = data;
        }

        [HttpGet]
        public IEnumerable<BirdSighting> GetAll()
            => dataAccess.GetBirdSightings();

        [HttpGet("{id}")]
        public BirdSighting Get(int id)
            => dataAccess.GetBirdSighting(id);

        [HttpPost]
        public void Post([FromBody]BirdSighting value)
            => dataAccess.InsertBirdSighting(value.Location, value.Description, value.Date, value.NumberOfBirds);

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] BirdSighting value)
            => dataAccess.UpdateBirdSighting(id, value.Location, value.Description, value.Date, value.NumberOfBirds);

        [HttpDelete("{id}")]
        public void Delete(int id)
            => dataAccess.DeleteBirdSighting(id);
    }
}