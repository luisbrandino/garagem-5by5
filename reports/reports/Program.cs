using Controllers;
using FileGenerators;
using Repositories;
using System.Configuration;

CarRepository repository = new();
Services.CarService service = new(repository, new CarServiceRepository());
CarController controller = new(service);

var carsInService = controller.FindAllInService();
var redCars = controller.FindAllRedCars();
var carsManufacturedBetween2010and2011 = controller.FindAllManufacturedBetween2010and2011();

string path = ConfigurationManager.AppSettings["XML_PATH"];

new XmlFileGenerator(path + "cars-in-service.xml").Generate(carsInService);
new XmlFileGenerator(path + "red-cars.xml").Generate(redCars);
new XmlFileGenerator(path + "cars-manufactured-between-2010-and-2011.xml").Generate(carsManufacturedBetween2010and2011);

Console.WriteLine("Todos relatórios foram gerados!");