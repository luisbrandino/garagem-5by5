using System.Configuration;

namespace Repositories
{
    public abstract class BaseRepository
    {
        protected readonly string? ConnectionString = ConfigurationManager.ConnectionStrings["CONNECTION_STRING"].ConnectionString;

        protected BaseRepository()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            if (ConnectionString == null)
                throw new Exception("Connection string não foi definida");
        }

    }
}
