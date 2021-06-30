using ProcessManagement.DAL.Infrastructure;
using ProcessManagement.Entities.Infrastructure;
using System.Threading.Tasks;

namespace ProcessManagement.BLL.Infrastructure
{
    internal abstract class EntityValidator<TEntity> where TEntity : BaseEntity
    {
        protected readonly ProcessManagementDbContext DbContext;

        public EntityValidator(ProcessManagementDbContext dbContext) => DbContext = dbContext;

        public abstract Task ValidateAsync(TEntity entity);
    }
}
