﻿using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Plane plane1 = new Plane();
plane1.Capacity = 100;
plane1.ManufactureDate = DateTime.Now;
plane1.PlaneType = PlaneType.Boeing;
plane1.PlaneId = 1;
Console.WriteLine("Constructeur par défaut : " + plane1.ToString());
Plane plane2 = new Plane(PlaneType.Airbus, 50, DateTime.Now);
Console.WriteLine("Constructeur paramétré : " + plane2.ToString());
Plane plane3 = new Plane { PlaneType = PlaneType.Airbus, ManufactureDate = DateTime.Now, Capacity = 40, PlaneId = 3 };
Console.WriteLine("Initialisateur d'objet : " + plane3.ToString());
Plane plane4 = new Plane { };
Console.WriteLine("Initialisateur d'objet vide : " + plane4.ToString());
// using initialisation from now no more constructeur 
Passenger passenger = new Passenger { FirstName = "hend", LastName = "zormati", EmailAddress = "a@b.c" };
Console.WriteLine(passenger.ToString());
Console.WriteLine(passenger.CheckProfile("hend", "zormati") + "\n");
Console.WriteLine(passenger.CheckProfile("hend", "not") + "\n");
Console.WriteLine(passenger.CheckProfile("hend", "zormati", "a@b.c") + "\n");
Console.WriteLine(" CHeck with mail : \n " + passenger.CheckProfileComplete("hend", "zormati", "a@b.c") + "\n");
Console.WriteLine(" CHeck without mail : \n " + passenger.CheckProfileComplete("hend", "zormati") + "\n");
Staff staff = new Staff { FirstName = "Staff", LastName = "zormati", Function = "staff" };
Traveller traveller = new Traveller { FirstName = "Traveller", LastName = "zormati", Nationality = "tunisian" };
Console.WriteLine(staff.ToString());
staff.PassengerType();
Console.WriteLine(traveller.ToString());
traveller.PassengerType();

// td 2 ;
FlightMethods fm = new FlightMethods { flights = TestData.listFlights };
string destination = "Paris";
Console.WriteLine(" List Dates de la destination " + destination + "  : \n ");
List<DateTime> list = new List<DateTime> { };
list = (List<DateTime>)fm.GetFlightDates(destination);
// using foreach loop
foreach (DateTime d in list)
{
    Console.WriteLine(" Flight Date : " + d);
}

// Question 10
Console.WriteLine("\nQuestion 10 :");
fm.ShowFlightDetails(TestData.Airbusplane);
fm.ShowFlightDetails(TestData.BoingPlane);

// Question 11
Console.WriteLine("\nQuestion 11 :");
Console.WriteLine(fm.ProgrammedFlightNumber(new DateTime(2022, 01, 01, 10, 10, 10)));

// Question 12
Console.WriteLine("\nQuestion 12 :");
Console.WriteLine(fm.DurationAverage(TestData.flight4.Destination));

// Question 13
Console.WriteLine("\nQuestion 13 :");
foreach (var f in fm.OrderedDurationFlights())
{
    Console.WriteLine(f);
}

// Question 14
Console.WriteLine("\nQuestion 14 :");
foreach(var f in fm.SeniorTravellers(fm.flights[0]))
{
    Console.WriteLine(f);
}

// Question 15
Console.WriteLine("\nQuestion 15 :");
fm.DestinationGroupedFlights();

// Question 16
Console.WriteLine("\nQuestion 16 :");
Console.WriteLine("Flight details without delegate :\n");
fm.ShowFlightDetails(TestData.BoingPlane);
Console.WriteLine("Flight details with delegate :\n");
fm.FlightDetailsDel(TestData.BoingPlane);

