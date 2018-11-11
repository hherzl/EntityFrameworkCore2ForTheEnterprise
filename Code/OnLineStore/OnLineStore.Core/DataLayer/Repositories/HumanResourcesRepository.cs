using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineStore.Core.DataLayer.Contracts;
using OnLineStore.Core.EntityLayer.HumanResources;

namespace OnLineStore.Core.DataLayer.Repositories
{
    public class HumanResourcesRepository : Repository, IHumanResourcesRepository
    {
        public HumanResourcesRepository(IUserInfo userInfo, OnLineStoreDbContext dbContext)
            : base(userInfo, dbContext)
        {
        }

        public IQueryable<Employee> GetEmployees(int pageSize = 10, int pageNumber = 1)
            => DbContext.Set<Employee>().Paging(pageSize, pageNumber);

        public async Task<Employee> GetEmployeeAsync(Employee entity)
            => await DbContext.Set<Employee>().FirstOrDefaultAsync(item => item.EmployeeID == entity.EmployeeID);
    }
}
