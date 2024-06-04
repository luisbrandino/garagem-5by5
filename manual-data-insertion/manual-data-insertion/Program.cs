using Controllers;
using manual_data_insertion;
using Models;
using Repositories;

Menu menu = new(
    "Criar carro",
    "Criar serviço",
    "Criar relacionamento entre carro e serviço",
    "Sair"
);

CarRepository carRepository = new();
Services.CarService carService = new(carRepository, new CarServiceRepository());
CarController carController = new(carService);

ServiceRepository serviceRepository = new();
Services.ServiceService serviceService = new(serviceRepository);
ServiceController serviceController = new(serviceService);

void createCar()
{
    Console.Clear();

    Car car = new Car();

    Console.Write("Informe a placa do carro (7 caracteres): ");
    car.LicensePlate = new (Console.ReadLine().Take(7).ToArray());

    Console.Write("Informe o nome do carro (100 caracteres): ");
    car.Name = new(Console.ReadLine().Take(100).ToArray());

    Console.Write("Informe qual o ano do modelo (4 caracteres): ");
    car.ModelYear = new(Console.ReadLine().Take(4).ToArray());

    Console.Write("Informe o ano de fabricação (4 caracteres): ");
    car.ManufactureYear = new(Console.ReadLine().Take(4).ToArray());

    Console.Write("Informe a cor do carro (30 caracteres): ");
    car.Color = new(Console.ReadLine().Take(30).ToArray());

    carController.Insert(car);

    Console.Clear();
    Console.WriteLine("Carro inserido!");
    Console.ReadKey();
}

void createService()
{
    Console.Clear();

    Service service = new Service();

    Console.Write("Informe a descrição do serviço (80 caracteres): ");
    service.Description = new(Console.ReadLine().Take(80).ToArray());

    serviceController.Insert(service);

    Console.Clear();
    Console.WriteLine("Serviço inserido!");
    Console.ReadKey();
}

void createRelationship()
{
    Console.Clear();

    List<Car> cars = carController.FindAll();

    if (cars.Count <= 0)
    {
        Console.WriteLine("Não há carros cadastrados");
        Console.ReadKey();
        return;
    }

    Menu carSelection = new();

    foreach (Car car in cars)
        carSelection.AddOption($"Placa: {car.LicensePlate} Nome: {car.Name} Ano do modelo: {car.ModelYear} Ano de fabricação: {car.ManufactureYear} Cor: {car.Color}");

    int option = carSelection.Ask();

    Car selectedCar = cars[option - 1];

    List<Service> services = serviceController.FindServicesNotBeingUsedByCar(selectedCar);

    if (services.Count <= 0)
    {
        Console.WriteLine("Carro já possui todos serviços cadastrados ou não há nenhum serviço cadastrado");
        Console.ReadKey();
        return;
    }

    Menu serviceSelection = new();

    foreach (Service service in services)
        serviceSelection.AddOption($"Descrição: {service.Description}");

    option = serviceSelection.Ask();

    Service selectedService = services[option - 1];

    carController.SetService(selectedCar, selectedService);

    Console.Clear();
    Console.WriteLine("Relação inserida!");
    Console.ReadKey();
}

while (true)
{
    Console.Clear();
    switch (menu.Ask())
    {
        case 1:
            createCar();
            break;
        case 2:
            createService();
            break;
        case 3:
            createRelationship();
            break;
        default:
            return;
    }
}