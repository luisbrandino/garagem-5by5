using Models;
using Repositories;

namespace Services
{
    public class CarService
    {
        private CarRepository _repository;
        private CarServiceRepository _carServiceRepository;

        public CarService(CarRepository repository, CarServiceRepository carServiceRepository)
        {
            _repository = repository;
            _carServiceRepository = carServiceRepository;
        }

        public int Insert(Car car)
        {
            return _repository.Insert(car);
        }

        public void InsertMany(List<Car> cars)
        {
            _repository.InsertMany(cars.Cast<Model>().ToList());
        }

        public void SetService(Car car, Service service)
        {
            _carServiceRepository.Insert(new Models.CarService
            {
                CarLicensePlate = car.LicensePlate,
                ServiceId = service.Id
            });
        }

        public List<Car> FindAll()
        {
            return _repository.FindAll();
        }

        public List<Car> FindAllInService()
        {
            return _repository.FindAllInService();
        }

        public List<Car> FindAllRedCars()
        {
            return _repository.FindAllRedCars();
        }

        public List<Car> FindAllManufacturedBetween2010and2011()
        {
            return _repository.FindAllManufacturedBetween2010and2011();
        }
    }
}
