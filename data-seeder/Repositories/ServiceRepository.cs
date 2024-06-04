using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace Repositories
{
    public class ServiceRepository : BaseRepository, IRepository
    {
        private readonly string InsertQuery = "insert into tb_service (description) values (@description);";
        public int Insert(Model model)
        {
            int id;

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                id = connection.ExecuteScalar<int>(InsertQuery, model);

                connection.Close();
            }

            return id;
        }

        public void InsertMany(List<Model> models)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                connection.ExecuteScalar<int>(InsertQuery, models);

                connection.Close();
            }
        }

        private readonly string FindNotBeingUsedByCarQuery = "select s.id, s.[description] from tb_service as s where s.id not in (select cs.service_id from tb_car_service as cs where cs.car_license_plate = @license_plate);";
        public List<Service> FindServicesNotBeingUsedByCar(Car car)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cars = connection.Query<Service>(FindNotBeingUsedByCarQuery, new { license_plate = car.LicensePlate }).ToList();

                connection.Close();

                return cars;
            }
        }
    }
}
