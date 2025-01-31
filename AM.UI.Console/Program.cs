using AM.ApplicationCore.Domain;

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
Passenger passenger = new Passenger { FirstName = "kacem", LastName = "zormati", EmailAddress = "a@b.c" };
Console.WriteLine(passenger.ToString());
Console.WriteLine(passenger.CheckProfile("kacem", "Abdelbaki") + "\n");
Console.WriteLine(passenger.CheckProfile("kacem", "not") + "\n");
Console.WriteLine(passenger.CheckProfile("kacem", "Abdelbaki", "a@b.c") + "\n");
Console.WriteLine(" CHeck with mail : \n " + passenger.CheckProfileComplete("kacem", "Abdelbaki", "a@b.c") + "\n");
Console.WriteLine(" CHeck without mail : \n " + passenger.CheckProfileComplete("kacem", "Abdelbaki") + "\n");
Staff staff = new Staff { FirstName = "Staff", LastName = "Abdelbaki", Function = "staff" };
Traveller traveller = new Traveller { FirstName = "Traveller", LastName = "Abdelbaki", Nationality = "tunisian" };
Console.WriteLine(staff.ToString());
staff.PassengerType();
Console.WriteLine(traveller.ToString());
traveller.PassengerType();