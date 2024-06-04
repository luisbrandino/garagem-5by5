using Models;

namespace Repositories
{
    public interface IRepository
    {
        public int Insert(Model entity);

        public void InsertMany(List<Model> entities);
    }
}
