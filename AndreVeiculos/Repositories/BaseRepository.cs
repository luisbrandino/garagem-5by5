using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace Repositories
{
    public  class BaseRepository
    {
        protected readonly string ConnectionString = "Server=127.0.0.1;Database=db_andre_veiculos;TrustServerCertificate=True;User Id=sa;Password=SqlServer2019!";

        public BaseRepository()
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        public virtual int Insert(Model model)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                List<string> columns = model.GetColumns().Where(column => !model.IsAutoIncrement(column)).ToList();
                List<string> parameters = columns.Select(column => $"@{column}").ToList();

                int insertedId = connection.ExecuteScalar<int>($"insert into {model.Table()} ({string.Join(',', columns)}) values ({string.Join(',', parameters)}); select cast(scope_identity() as int)", model.Raw());

                if (model.IsPrimaryKeyAutoIncrement())
                    model.SetAttribute(model.GetPrimaryKeyName(), insertedId);

                connection.Close();

                return insertedId;
            }
        }

        public virtual List<Model> FindAll() 
        {
            return new List<Model>();
        }

    }
}
