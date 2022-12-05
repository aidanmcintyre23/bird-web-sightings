using System;
using System.Collections.Generic;

namespace BirdWebsightings.DataAccess
{
    public interface IDataAccess
    {
        void InsertBirdSighting(string location, string description, DateTime date, int numberOfBirds);

        BirdSighting GetBirdSighting(int id);

        void DeleteBirdSighting(int id);

        void UpdateBirdSighting(int id, string location, string description, DateTime date, int numberOfBirds);

        IEnumerable<BirdSighting> GetBirdSightings();
    }
}