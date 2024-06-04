using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace Repositories
{
    public class CarRepository : BaseRepository, IRepository
    {
        private readonly string InsertQuery = "insert into tb_car (license_plate, name, model_year, manufacture_year, color) values (@license_plate, @name, @model_year, @manufacture_year, @color);";
        public int Insert(Model model)
        {
            Car car = (Car)model;

            if (car == null)
                throw new Exception("Model do tipo inválido para repository 'CarRepository'");

            int id;

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                id = connection.ExecuteScalar<int>(InsertQuery, new
                {
                    license_plate = car.LicensePlate,
                    name = car.Name,
                    model_year = car.ModelYear,
                    manufacture_year = car.ManufactureYear,
                    color = car.Color
                });

                connection.Close();
            }

            return id;
        }

        public void InsertMany(List<Model> models)
        {
            object cars = models.Select(model =>
            {
                Car car = (Car)model;
                return new
                {
                    license_plate = car.LicensePlate,
                    name = car.Name,
                    model_year = car.ModelYear,
                    manufacture_year = car.ManufactureYear,
                    color = car.Color
                };
            }).ToList();


            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                connection.Execute(InsertQuery, cars);

                connection.Close();
            }
        }

        private readonly string FindQuery = "select license_plate, name, model_year, manufacture_year, color from tb_car";
        public List<Car> FindAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cars = connection.Query<Car>(FindQuery).ToList();

                connection.Close();

                return cars;
            }
        }

        private readonly string FindInServiceQuery = "select c.license_plate, c.name, c.model_year, c.manufacture_year, c.color from tb_car as c join tb_car_service as cs on cs.car_license_plate = c.license_plate join tb_service as s on s.id = cs.service_id where cs.status = 1";
        public List<Car> FindAllInService()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cars = connection.Query<Car>(FindInServiceQuery).ToList();

                connection.Close();

                return cars;
            }
        }

        private readonly string FindRedCarsQuery = "select license_plate, name, model_year, manufacture_year, color from tb_car where color = 'Vermelho'";
        public List<Car> FindAllRedCars()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cars = connection.Query<Car>(FindRedCarsQuery).ToList();

                connection.Close();

                return cars;
            }
        }

        private readonly string FindManufacturedBetween2010and2011 = "select license_plate, name, model_year, manufacture_year, color from tb_car where manufacture_year >= 2010 and manufacture_year <= 2011";
        public List<Car> FindAllManufacturedBetween2010and2011()
        {

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var cars = connection.Query<Car>(FindManufacturedBetween2010and2011).ToList();

                connection.Close();

                return cars;
            }
        }
    }
}
