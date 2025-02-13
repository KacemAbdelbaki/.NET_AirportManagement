using System.Data;
using System.Numerics;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> flights { get; set; } = new List<Flight> { };

        // Question 16
        public Action<Domain.Plane> FlightDetailsDel;
        public Func<string, float> DurationAverageDel;

        public FlightMethods()
        {
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;
            FlightDetailsDel = p => {
                var query = from f in flights
                            where f.Plane == p
                            select f;
            };
            DurationAverageDel = d =>
            {
                var query = from flight in flights
                            where flight.Destination == d
                            select flight.EstimatedDuration;
                return query.Average();
            };
        }

        public IList<DateTime> GetFlightDates(string destination)
        {
            //List<DateTime> dates = new List<DateTime>();
            //foreach (Flight f in flights)
            //{
            //    if (f.Destination == destination)
            //    {
            //        dates.Add(f.FlightDate);
            //    }
            //}
            //return dates;

            // commented to do Question 19
            //var query=from f in flights
            //          where f.Destination == destination
            //          select f.FlightDate;
            //return query.ToList();
            return flights
                .Where(f => f.Destination == destination)
                .Select(f => f.FlightDate)
                .ToList();
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType){
                case "Destination":
                    foreach (var flight in flights){
                        if (flight.Destination.Equals(filterValue)){
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (var flight in flights) {
                        if (flight.FlightDate == DateTime.Parse(filterType)){
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "EstimatedDuration":
                    foreach (var flight in flights)
                    {
                        if (flight.EstimatedDuration == float.Parse(filterType))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "Departure":
                    foreach (var flight in flights)
                    {
                        if (flight.Departure.Equals(filterType))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
                case "EffectiveArrival":
                    foreach (var flight in flights)
                    {
                        if (flight.EffectiveArrival == DateTime.Parse(filterType))
                        {
                            Console.WriteLine(flight);
                        }
                    }
                    break;
            }
        }

        public void ShowFlightDetails(Domain.Plane plane)
        {
            // commented to do Question 18
            //var query = from f in flights
            //            where f.Plane == plane
            //            select f;
            //foreach (var flight in query)
            //{
            //    Console.WriteLine(flight.FlightDate+flight.Destination);
            //}

            var lambdaQuery = flights.Where(f => f.Plane == plane);
            foreach (var f in lambdaQuery)
            {
                Console.WriteLine(f.FlightDate+f.Destination);
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var query = from flight in flights
            //            where DateTime.Compare(flight.FlightDate, startDate)>0
            //            && (flight.FlightDate-startDate).TotalDays<7 
            //            select flight;
            //return query.Count();

            // commented to do Question 18
            //var query = from flight in flights
            //            where (flight.FlightDate> startDate) 
            //            && flight.FlightDate < startDate.AddDays(7)
            //            select flight;
            //return query.Count();

            var lambdaQuery = flights
                .Where(f => f.FlightDate > startDate && f.FlightDate < startDate.AddDays(7));
            return lambdaQuery.Count();
        }

        public float DurationAverage(string destination)
        {
            // commented to do Question 18
            //var query = from flight in flights
            //            where flight.Destination == destination
            //            select flight.EstimatedDuration;
            //return query.Average();

            var lambdaQuery = flights
                .Where(f => f.Destination == destination)
                .Select(f => f.EstimatedDuration);
            return lambdaQuery.Average();
        }

        public List<Flight> OrderedDurationFlights()
        {
            // commented to do Question 18
            //var query = from flight in flights
            //            orderby flight.EstimatedDuration descending
            //            select flight;
            //return query.ToList();

            var lambdaQuery = flights
                .OrderByDescending(f => f.EstimatedDuration);
            return lambdaQuery.ToList();
        }

        public List<Traveller> SeniorTravellers(Flight flight)
        {
            //commented to do Question 18
            //var query = from passenger in flight.Passengers.OfType<Traveller>()
            //            orderby passenger.BirthDate ascending
            //            select passenger;
            //return query.Take(3).ToList();

            var lambdaQuery = flight.Passengers.OfType<Traveller>()
                .OrderBy(p => p.BirthDate);
            return lambdaQuery.Take(3).ToList();
        }

        public void DestinationGroupedFlights()
        {
            //commented to do Question 18
            //var query = from flight in flights
            //            group flight by flight.Destination;
            //return query.ToList();

            //var lambdaQuery = flights
            //    .GroupBy(f => f.Destination);
            //foreach (var f in lambdaQuery)
            //{
            //    Console.WriteLine(f.Key);
            //    foreach (var g in f)
            //    {
            //        Console.WriteLine(g);
            //    }
            //}

            var lambdaQuery = flights
                .GroupBy(f => f.Destination);
            foreach (var f in lambdaQuery)
            {
                Console.WriteLine(f.Key);
                foreach (var g in f)
                {
                    Console.WriteLine(g);
                }
            }
        }

        public Dictionary<string, Flight> DestinationGroupedFlights2()
        {
            var query = from flight in flights
                        group flight by flight.Destination;
            Dictionary<string, Flight> map = new Dictionary<string, Flight>();
            foreach (var g in query)
            {
                foreach (var f in g)
                {
                    map.Add(g.Key, f);
                }
            }
            return map;
        }
    }
}
