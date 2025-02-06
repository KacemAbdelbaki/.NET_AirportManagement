

using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    internal interface IFlightMethods
    {
        public IList<DateTime> GetFlightDates(string destination);
        public void GetFlights(string filterType, string filterValue);
        public void ShowFlightDetails(Plane plane);
        public int ProgrammedFlightNumber(DateTime startDate);
        public float DurationAverage(string destination);
        public List<Flight> OrderedDurationFlights();
    }
}
