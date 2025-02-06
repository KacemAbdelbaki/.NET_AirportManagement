using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> flights = new List<Flight> { };

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

            var query=from f in flights
                      where f.Destination == destination
                      select f.FlightDate;
            return query.ToList();
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

        public void ShowFlightDetails(Plane plane)
        {
            var query = from f in flights
                        where f.Plane == plane
                        select f;
            foreach (var flight in query)
            {
                Console.WriteLine(flight.FlightDate+flight.Destination);
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var query = from flight in flights
            //            where DateTime.Compare(flight.FlightDate, startDate)>0
            //            && (flight.FlightDate-startDate).TotalDays<7 
            //            select flight;
            //return query.Count();

            var query = from flight in flights
                        where (flight.FlightDate> startDate) 
                        && flight.FlightDate < startDate.AddDays(7)
                        select flight;
            return query.Count();
        }

        public float DurationAverage(string destination)
        {
            var query = from flight in flights
                        where flight.Destination == destination
                        select flight.EstimatedDuration;
            return query.Average();
        }

        public List<Flight> OrderedDurationFlights()
        {
            var query = from flight in flights
                        orderby flight.EstimatedDuration descending
                        select flight;
            return query.ToList();
        }
    }
}
