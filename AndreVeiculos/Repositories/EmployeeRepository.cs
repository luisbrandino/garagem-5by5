using Models;

namespace Repositories
{
    public class EmployeeRepository : BaseRepository
    {

        public override int Insert(Model model)
        {
            Employee employee = (Employee)model;

            if (employee == null)
                throw new Exception($"Tipo '{model.GetType()}' não aceito por EmployeeRepository");

            if (employee.Role.Id == 0)
                base.Insert(employee.Role);

            return base.Insert(model);
        }

    }
}
