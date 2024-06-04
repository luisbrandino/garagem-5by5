using Controllers;
using Models;
using Newtonsoft.Json;
using Repositories;
using System.Configuration;

string data = File.OpenText(ConfigurationManager.AppSettings["CARS_JSON_PATH"]).ReadToEnd();

List<Car> cars = JsonConvert.DeserializeObject<List<Car>>(data);

if (cars == null)
    return;

CarRepository repository = new();
Services.CarService service = new(repository);
CarController controller = new(service);

controller.InsertMany(cars);

Console.WriteLine("Registros inseridos!");