using Models;
using Repositories;
using Services;

namespace Controllers
{
    public class ServiceController
    {
        private ServiceService _service;

        public ServiceController(ServiceService service)
        {
            _service = service;
        }

        public int Insert(Service service)
        {
            return _service.Insert(service);
        }

        public void InsertMany(List<Service> services)
        {
            _service.InsertMany(services);
        }

        public List<Service> FindServicesNotBeingUsedByCar(Car car)
        {
            return _service.FindServicesNotBeingUsedByCar(car);
        }
    }
}
