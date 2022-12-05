using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Dapper;
using Npgsql;

namespace BirdWebsightings.DataAccess
{
    public class BirdSightingDataAccess : IDataAccess
    {
        private IDbConnection connection = null;

        public BirdSightingDataAccess()
        {
            string connectionString = "Server=localhost;Port=5432;User Id=postgres;Password=password;Database=bird_websightings";
            connection = new NpgsqlConnection(connectionString);   
        }

        public BirdSighting GetBirdSighting(int id)
        {
            BirdSighting result = null;

            try
            {
                connection.Open();
                result = connection.Query<BirdSighting>("SELECT * FROM bird_websightings WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public void DeleteBirdSighting(int id)
        {
            try
            {
                connection.Open();
                connection.Execute("DELETE FROM bird_websightings WHERE Id = @Id", new { Id = id });
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void InsertBirdSighting(string location, string description, DateTime date, int numberOfBirds)
        {
            try
            {
                connection.Open();
                connection.Execute("INSERT INTO bird_websightings(Location, Description, Date, NumberOfBirds) VALUES(@Location, @Description, @Date, @NumberOfBirds)",
                    new { Location = location, Description = description, Date = date, NumberOfBirds = numberOfBirds });
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateBirdSighting(int id, string location, string description, DateTime date, int numberOfBirds)
        {
            try
            {
                connection.Open();
                connection.Execute("UPDATE bird_websightings SET Location = @Location, Description = @Description, Date = @Date, NumberOfBirds = @NumberOfBirds WHERE Id = @Id",
                    new { Location = location, Description = description, Date = date, NumberOfBirds = numberOfBirds, Id = id });
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public IEnumerable<BirdSighting> GetBirdSightings()
        {
            List<BirdSighting> results = null;

            try
            {
                connection.Open();
                results = connection.Query<BirdSighting>("SELECT * FROM bird_websightings").ToList();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return results;
        }
    }
}