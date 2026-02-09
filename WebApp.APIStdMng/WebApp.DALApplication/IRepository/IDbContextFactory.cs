
using WebApp.CoreDomain;
using WebApp.CoreDomain.STUDENTMNG_dbContext;

namespace WebApp.DALApplication.IRepository
{
    public interface IDbContextFactory
    {
        StudentmngContext DbContext { get; }
    }
}
