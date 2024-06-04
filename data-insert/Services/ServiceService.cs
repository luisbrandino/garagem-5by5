using Models;
using Repositories;

namespace Services
{
    public class ServiceService
    {
        private ServiceRepository _repository;

        public ServiceService(ServiceRepository repository)
        {
            _repository = repository;
        }

        public int Insert(Service service)
        {
            return _repository.Insert(service);
        }

        public void InsertMany(List<Service> services)
        {
            _repository.InsertMany(services.Cast<Model>().ToList());
        }

        public List<Service> FindServicesNotBeingUsedByCar(Car car)
        {
            return _repository.FindServicesNotBeingUsedByCar(car);
        }


    }
}
