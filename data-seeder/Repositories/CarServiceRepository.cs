using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace Repositories
{
    public class CarServiceRepository : BaseRepository, IRepository
    {
        private readonly string InsertQuery = "insert into tb_car_service (car_license_plate, service_id) values (@car_license_plate, @service_id)";
        public int Insert(Model model)
        {
            CarService carService = (CarService)model;

            if (carService == null)
                throw new Exception("Model do tipo inválido para repository 'CarServiceRepository'");

            int id;

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                id = connection.ExecuteScalar<int>(InsertQuery, new
                {
                    car_license_plate = carService.CarLicensePlate,
                    service_id = carService.ServiceId,
                });

                connection.Close();
            }

            return id;
        }

        public void InsertMany(List<Model> models)
        {
            object carsServices = models.Select(model =>
            {
                CarService carService = (CarService)model;
                return new
                {
                    car_license_plate = carService.CarLicensePlate,
                    service_id = carService.ServiceId,
                };
            }).ToList();

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                connection.Execute(InsertQuery, carsServices);

                connection.Close();
            }
        }
    }
}
