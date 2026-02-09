using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApp.CoreDomain;
using WebApp.CoreDomain.STUDENTMNG_dbContext;
using WebApp.DALApplication.IRepository;


namespace WebApp.DALApplication
{
    public class DbContextFactory : IDbContextFactory, IDisposable
    {
        /// <summary>
        /// Create Db context with connection string
        /// </summary>
        /// <param name="settings"></param>
        public DbContextFactory(IOptions<DbContextSettings> settings)
        {
            var options = new DbContextOptionsBuilder<StudentmngContext>().UseSqlServer(settings.Value.DefaultConnection).Options;
            DbContext = new StudentmngContext(options);

        }

        /// <summary>
        /// Call Dispose to release DbContext
        /// </summary>
        ~DbContextFactory()
        {
            Dispose();
        }

        public StudentmngContext DbContext { get; private set; }
        /// <summary>
        /// Release DB context
        /// </summary>
        public void Dispose()
        {
            DbContext?.Dispose();
        }
    }
}

