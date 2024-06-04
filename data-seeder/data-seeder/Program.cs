using data_seeder;
using Models;
using FileGenerators;
using System.Configuration;

CarFactory factory = new();

List<Car> cars = new();

int totalCars = 30;

for (int i = 0; i < totalCars; i++)
    cars.Add(factory.Make());

string? path = ConfigurationManager.AppSettings["CARS_JSON_PATH"];

if (path == null)
    Environment.Exit(0);

JsonFileGenerator generator = new(path);

generator.Generate(cars);