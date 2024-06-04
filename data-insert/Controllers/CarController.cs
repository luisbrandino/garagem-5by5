using Models;

namespace Controllers
{
    public class CarController
    {
        private Services.CarService _service;

        public CarController(Services.CarService service)
        {
            _service = service;
        }

        public int Insert(Car car)
        {
            return _service.Insert(car);
        }

        public void InsertMany(List<Car> cars)
        {
            _service.InsertMany(cars);
        }

        public void SetService(Car car, Service service)
        {
            _service.SetService(car, service);
        }

        public List<Car> FindAll()
        {
            return _service.FindAll();
        }

        public List<Car> FindAllInService()
        {
            return _service.FindAllInService();
        }

        public List<Car> FindAllRedCars()
        {
            return _service.FindAllRedCars();
        }

        public List<Car> FindAllManufacturedBetween2010and2011()
        {
            return _service.FindAllManufacturedBetween2010and2011();
        }
    }
}
