using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.CoreDomain.STUDENTMNG_dbContext;
using Serilog;
using System.Linq;
using WebApp.DALApplication.IRepository;
//using Microsoft.Extensions.Logging;


namespace WebApp.DALApplication.Repository
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly IDbContextFactory _dbContextFactory;

        protected ILogger Logger;
        protected StudentmngContext _dbContext => _dbContextFactory?.DbContext;

        public RepositoryAsync(IDbContextFactory dbContextFactory, ILogger logger)
        {
            _dbContextFactory = dbContextFactory;
            Logger = logger;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                Logger.Error("Erreur AddAsync <==> " + ex.ToString());
                return false;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        public async Task DeleteEntityAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Logger.Error("Erreur DeleteEntityAsync <==> " + ex.ToString());
                throw;
            }
        }

        /// <summary>
        /// En utilisant UOW
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        public Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public async Task<List<T>> GetAllEntityAsync()
        {
            try
            {
                return await _dbContext.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {

                Logger.Error("Erreur GetAllEntityAsync <==> " + ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>

        public async Task<List<T>> GetEntityWhereAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _dbContext.Set<T>().Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {

                Logger.Error("Erreur GetEntityWhereAsync <==> " + ex.ToString());
                return null;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// 
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            var result = _dbContext.Set<T>().AsNoTracking();
            if (expression != null)
                result = result.Where(expression);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdAsyncNew(int id)
        {
            // Check if id is valid
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID", nameof(id));
            }

            // Retrieve the entity by ID asynchronously
            T entity = await _dbContext.Set<T>().FindAsync(id);

            // Check if the entity is null (not found)
            if (entity == null)
            {
                // Handle the case where the entity is not found, you can throw an exception or return null
                throw new ArgumentException($"Entity of type {typeof(T).Name} with ID {id} not found.");
            }

            return entity;
        }


        /// <summary>
        /// 14/11/2023
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public async Task<T> GetByStringIdAsync(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().FirstOrDefaultAsync(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        public async Task UpdateEntityAsync(T entity)
        {
            try
            {
                _dbContext.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                Logger.Error("Erreur UpdateEntityAsync <==> " + ex.ToString());
            }

        }

        /// <summary>
        /// En utilisant UOW
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        public Task UpdateAsync(T entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<bool> CheckChampEntity(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var Ret = await _dbContext.Set<T>().FirstOrDefaultAsync(predicate);
                bool exist = (Ret != null);
                return exist;
            }
            catch (Exception ex)
            {

                Logger.Error("Erreur CheckChampEntity <==> " + ex.ToString());
                return false;
            }
        }

    }
}
