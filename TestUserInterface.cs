using System;
using System.Collections.Generic;
using System.IO;

namespace CAB201_UserInterfaceTest
{
	/// <summary>
	/// Demonstration program for UserInterface class.
	/// </summary>
	public class TestUserInterface {
		static void Main( string[] args ) {
			EmployeeMenu EmployeeMenu = new EmployeeMenu();
			EmployeeMenu.MainMenu();
		}

		/// <summary>
		/// Displays a employeemenu
		/// </summary>
		public class EmployeeMenu
		{
			// store employee information
			private static string employeeName = "";
			private static string employeeEmail = "";
			private static string employeePassword = "";

			// capsulization of the customer information
			public static string EmployeeName
			{
				get
				{
					return employeeName;
				}
			}
			public static string EmployeeEmail
            {
				get
				{
					return employeeEmail;
				}
			}
			public static string EmployeePassword
			{
				get
				{
					return employeePassword;
				}
			}
			public void MainMenu()
			{
				//Empolyee information details which are saved
				

				Register Register = new Register();
				Login Login = new Login();

				const int REGISTER = 0, LOGIN = 1, EXIT = 2;
				Console.WriteLine("Please select one of the following:");

				bool running = true;

				while (running)
				{
					int option = UserInterface.GetOption("",
						"Register as new Employee", "Login as exsisting Employee", "Exit"
					);

					switch (option)
					{
						case REGISTER:
							Register.Register_employee(out employeeName, out employeeEmail, out employeePassword);
							break;
						case LOGIN:
							Login.Emp_LogIn(ref employeeName, employeeEmail, employeePassword);
							break;
						case EXIT:
							running = false;
							break;
						default: break;
					}
				}
			}
		}

	
		/// <summary>
		/// Displays a customer service menu
		/// </summary>
		public class CustomerService
        {
			// store array, they should be global variable because they should be stored until close the program. 
			// customer information details which are saved
			private static string[] customerName = new string[10];
			private static string[] customerMail = new string[10];
			private static string[] customerAddress = new string[10];
			private static string[] customerMobile = new string[10];
			public static int customer = 0;

			// capsulization of the customer information
			public static string[] CustomerName
            {
				get
                {
					return customerName;
				}
            }
			public static string[] CustomerMail
			{
				get
				{
					return customerMail;
				}
			}
			public static string[] CustomerAddress
			{
				get
				{
					return customerAddress;
				}
			}
			public static string[] CustomerMobile
			{
				get
				{
					return customerMobile;
				}
			}
			// plane information details which are saved
			public static int planeNum = 0;
			public static string[] departure = new string[10];
			public static string[] arrival = new string[10];
			public static string[] departureTime = new string[10];
			public static string[] planetype = new string[10];
			public static float[] distance = new float[10];

			// book information details which are saved
			public static int bookCount = 1;
			public static int bookNum = 0;
			public static string[] bookPlane = new string[10];
			public static string[] bookCustomer = new string[10];

			public void ServiceMenu()
            {
				
				// class objects
				Add_client Add_client = new Add_client();
				Add_aircraft Add_aircraft = new Add_aircraft();
				Add_helicopter Add_helicopter = new Add_helicopter();
				View_service View_service = new View_service();
				View_time View_time = new View_time();
				Booking Booking = new Booking();
				Passenger Passenger = new Passenger();
				EmployeeMenu EmployeeMenu = new EmployeeMenu();

				const int Register_customer = 0, Register_aircraft = 1, Register_helicopter = 2, View_flying_service = 3, 
					View_existing_times = 4, Add_customer_service = 5, View_passengers = 6, Logout = 7;

				Console.WriteLine("Please select one of the following:");

				bool running = true;

				while (running)
				{
					int option = UserInterface.GetOption("",
						"Register a customer", "Register a new light aircraft", "Register a new helicopter", "View existing flying services", 
						"View exsisting times", "Add a customer to a flying service", "View flight passengers", "Logout"
					);

					switch (option)
					{
						case Register_customer:
							Add_client.Add_clinets(ref customerName, ref customerMail, ref customerAddress, ref customerMobile,ref customer);
							break;
						case Register_aircraft:
							Add_aircraft.Add_plane(ref departure, ref arrival, ref departureTime, ref distance, ref planetype,ref planeNum, "aircraft");
							break;
						case Register_helicopter:
							Add_helicopter.Add_helicopters(ref departure, ref arrival, ref departureTime, ref distance, ref planetype,ref planeNum, "helicopter");
							break;
						case View_flying_service:
							View_service.View_services(ref departure, ref arrival, ref departureTime, ref distance, ref planetype,ref planeNum);
							break;
						case View_existing_times:
							View_time.View_times(ref departure, ref arrival, ref departureTime, ref distance, ref planetype,ref planeNum, ref bookCount);
							break;
						case Add_customer_service:
							Booking.Bookings(ref customerName,ref customer, ref departure, ref arrival, ref planetype, ref distance, ref 
								planeNum, ref bookCount, ref bookPlane, ref bookCustomer, ref bookNum);
							break;
						case View_passengers:
							Passenger.Passengers(ref customerName,ref customer, ref departure, ref arrival, ref planeNum,
								  ref bookPlane, ref bookCustomer, bookNum);
							break;
						case Logout:
							EmployeeMenu.MainMenu();
							break;
						default: break;
					}
				}
			}
        }
		/// <summary>
		/// register function of the register class
		/// </summary>
		public class Register
		{
			public void Register_employee(out string employeeName,out string employeeEmail, out string employeePassword)
			{
				int employee = 1;
                employeeName = UserInterface.GetInput("Full name");
                employeeEmail = UserInterface.GetInput("Email");
                employeePassword = UserInterface.GetPassword("Password");
				Console.WriteLine("");
				Console.WriteLine(employeeName + " registered successfully");
				Console.WriteLine("");
				employee += 1;
			}
		}
		/// <summary>
		/// login function of the login class
		/// </summary>
		public class Login
		{
			public void Emp_LogIn(ref string employeeName, string employeeEmail, string employeePassword)
			{
				CustomerService CustomerService = new CustomerService();
				string mail = UserInterface.GetInput("Email");
				string password = UserInterface.GetPassword("Password");
				
				if (employeeEmail == mail && employeePassword == password)
                {
					Console.WriteLine("Welcome " + employeeName);
					CustomerService.ServiceMenu();
				}
                else
                {
					Console.WriteLine("");
					Console.WriteLine("Invalid email or password, please try again");
					Console.WriteLine("");
                }
			}
		}
		/// <summary>
		/// add clients function
		/// </summary>
		public class Add_client
        {
			public void Add_clinets(ref string[] customerName, ref string[] customerMail, ref string[] customerAddress, ref string[] customerMobile,ref int customer)
            {
                customerName[customer] = UserInterface.GetInput("Full name");
                customerMail[customer] = UserInterface.GetInput("Email");
                customerAddress[customer] = UserInterface.GetInput("Address");
				customerMobile[customer] = UserInterface.GetInput("Mobile");
				Console.WriteLine(customerName[customer] + " registered successfully.");
				customer += 1;
			}
        }

		// inheretance for reducing reduplication
		public class plane
		{
			public virtual void Add_plane(ref string[] departure, ref string[] arrival, ref string[] departureTime, ref float[] distance, ref string[] planetype, ref int planeNum, string whichplane)
			{
				string DepPlace = UserInterface.GetInput("Departure Place");
				departure[planeNum] = DepPlace;
				string ArrPlace = UserInterface.GetInput("Arrival Place");
				arrival[planeNum] = ArrPlace;
				departureTime[planeNum] = UserInterface.GetInput("Departure Time");
				distance[planeNum] = Convert.ToInt32(UserInterface.GetDouble("Distance"));
				planetype[planeNum] = whichplane;
				planeNum += 1;
				Console.WriteLine("Light Aircraft from " + DepPlace + " to " + ArrPlace + " added");
			}
		}


		/// <summary>
		/// add aircrafts function
		/// </summary>
		public class Add_aircraft :plane
		{
			public override void Add_plane(ref string[] departure, ref string[] arrival, ref string[] departureTime, ref float[] distance, ref string[] planetype, ref int planeNum, string whichplane)
			{
				plane child = new plane();
				child.Add_plane(ref departure, ref arrival, ref departureTime, ref distance, ref planetype, ref planeNum, whichplane);
			}
		}
		/// <summary>
		/// add helicopters function
		/// </summary>
		public class Add_helicopter :plane
		{
			public void Add_helicopters(ref string[] departure, ref string[] arrival, ref string[] departureTime, ref float[] distance, ref string[] planetype,ref int planeNum, string whichplane)
			{
				plane child = new plane();
				child.Add_plane(ref departure, ref arrival, ref departureTime, ref distance, ref planetype, ref planeNum, whichplane);
			}
		}
		/// <summary>
		/// view the aircrafts information such as departure, arrival, and distance
		/// </summary>
		public class View_service :plane
		{
			public void View_services(ref string[] departure, ref string[] arrival, ref string[] departureTime, ref float[] distance, ref string[] planetype,ref int planeNum)
			{
				for (int i = 0; i < planeNum; i++)
                {
					if (planetype[i] == "aircraft")
                    {
						Console.WriteLine("Light Aircraft " + departure[i] + " " + arrival[i] + " " + distance[i]);
                    }
                    else if (planetype[i] == "helicopter")
                    {
						Console.WriteLine("Helicopter " + departure[i] + " " + arrival[i] + " " + distance[i]);
					}
                }
			}
		}
		/// <summary>
		/// view the time of the registered flights
		/// </summary>
		public class View_time
		{
			public void View_times(ref string[] departure, ref string[] arrival, ref string[] departureTime, ref float[] distance, ref string[] planetype,ref int planeNum, ref int bookCount)
			{
				int AircraftVelocity = 800;
				int AircrafExtra = 30;
				int HelicopterVelocity = 120;
				int HelicopterExtra_0 = 10;
				int HelicopterExtra_1 = 15;
				int HelicopterExtra_2 = 20;
				for (int i = 0; i < planeNum; i++)
                {
					if (planetype[i] == "aircraft")
					{
						float Air_Flightduration;
						Air_Flightduration = (60 * distance[i] / AircraftVelocity) + AircrafExtra;
						Console.WriteLine("Light Aircraft " + departure[i] + " " + arrival[i] + " " + departureTime[i] + " " + Air_Flightduration + " minutes");
					}
					else if (planetype[i] == "helicopter")
					{
						float Heli_Flightduration;
						if (bookCount == 1)
                        {
							Heli_Flightduration = (60 * distance[i] / HelicopterVelocity) + HelicopterExtra_0;
							Console.WriteLine("Helicopter " + departure[i] + " " + arrival[i] + " " + departureTime[i] + " " + Heli_Flightduration + " minutes");
						}
						if (bookCount == 2)
                        {
							Heli_Flightduration = (60 * distance[i] / HelicopterVelocity) + HelicopterExtra_1;
							Console.WriteLine("Helicopter " + departure[i] + " " + arrival[i] + " " + departureTime[i] + " " + Heli_Flightduration + " minutes");
						}
						if (bookCount >= 3)
                        {
							Heli_Flightduration = (60 * distance[i] / HelicopterVelocity) + HelicopterExtra_2;
							Console.WriteLine("Helicopter " + departure[i] + " " + arrival[i] + " " + departureTime[i] + " " + Heli_Flightduration + " minutes");
						}
					}
				}
				
			}
		}
		/// <summary>
		/// book the flights from customer asks
		/// </summary>
		public class Booking
		{
			public void Bookings(ref string[] customerName,ref int customer, ref string[] departure, 
				ref string[] arrival, ref string[] planetype, ref float[] distance, ref int planeNum, ref int bookCount, 
				ref string[] bookPlane, ref string[] bookCustomer, ref int bookNum)
			{
				int AircraftVelocity = 800;
				int HelicopterVelocity = 120;
				int AircraftCostPerHour = 250;
				int HelicopterCostPerHour = 600;

				for (int i = 0; i < customer; i++)
                {
					Console.WriteLine(i + " " + customerName[i]);
                }
				int customerNumber = Convert.ToInt32(UserInterface.GetDouble("Get the customer number"));
				for (int i = 0; i < planeNum; i++)
                {
					Console.WriteLine(i + " " + departure[i] + " " + arrival[i]);
                }
				int planeNumber = UserInterface.GetInteger("Get the fligt number");

                if (planetype[planeNumber] == "aircraft" && bookCount > 5) // aircraft can not take 6 person
				{
					Console.WriteLine("Flying machine is full");
                }
				else if(planetype[planeNumber] == "helicopter" && bookCount > 2) // helicopter can not take 3 person
                {
					Console.WriteLine("Flying machine is full");
				}
                else
                {
					Console.WriteLine("Customer " + customerName[customerNumber] + " added");
					bookNum = bookNum + 1;
					bookPlane[bookNum] = Convert.ToString(planeNumber);
					bookCustomer[bookNum] = customerName[customerNumber];
					bookCount += + 1;

					float cost;
					if (planetype[planeNumber] == "aircraft")
                    {
						cost = (distance[planeNumber] / AircraftVelocity) * AircraftCostPerHour;
					}
					else
                    {
						cost = (distance[planeNumber] / HelicopterVelocity) * HelicopterCostPerHour;
					}
					Console.WriteLine("Cost is " + cost);
				}
			}
		}
		/// <summary>
		/// view passenger of each flights
		/// </summary>
		public class Passenger
		{
			public void Passengers(ref string[] customerName,ref int customer,
								  ref string[] departure, ref string[] arrival, ref int planeNum,
								  ref string[] bookPlane, ref string[] bookCustomer, int bookNum)
			{
				for (int i = 0; i < planeNum; i++)
				{
					Console.WriteLine(i + " " + departure[i] + " " + arrival[i]);
				}
				string planeNumber = UserInterface.GetInput("Get the fligt number");
				int customerNumber = 0;
				//Console.WriteLine(bookNum );

				for (int i = 0; i <= bookNum; i++)
				{
					if (planeNumber == bookPlane[i])
					{
						Console.WriteLine(bookCustomer[i]);
						customerNumber = customerNumber + 1;
					}
				}
				if (customerNumber == 0)
				{
					Console.WriteLine("No customers");
				}
			}
		}
	}
}
