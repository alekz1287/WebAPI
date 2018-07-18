using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HillmanGroup.API.Entities
{
    public static class CityInfoExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }

            var cities = new List<City>()
            {
                new City()
                {
                    Name = "New York City",
                    Description = "The big one.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Central Park",
                            Description = "Most visited park"
                        },
                        new PointOfInterest()
                        {
                            Name = "Empire State Building",
                            Description = "A skyscraper"
                        }
                    }
                },
                new City()
                {
                    Name = "Antwerp",
                    Description = "Unfinished cathedral."
                },
                new City()
                {
                    Name = "Paris",
                    Description = "Eiffel Tower"
                }
            };

            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
