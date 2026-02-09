using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApp.ServiceInfrastructure.IService
{
    public interface IServiceAsync<TEntity, TDto>
    {
        Task<bool> AddAsync(TDto tDto);
        /// <summary>
        ///  UOW UNIT OF WORK
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(int id);
        //21/11/2023
        Task DeleteEntityStringAsync(string matricule);


        Task UpdateAsync(TDto entityTDto);

        IEnumerable<TDto> GetAll(Expression<Func<TDto, bool>> expression = null);

        Task<TDto> GetByIdAsync(int id);

        //14/11/2023
        Task<TDto> GetByStringIdAsync(string id);

        Task<TDto> GetFirstAsync(Expression<Func<TDto, bool>> expression);

        /// <summary>
        /// without UOW
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteEntityAsync(int id);
        Task UpdateEntityAsync(TDto entityTDto);

        ////02/01/2024
        //Task<TDto> GetByDoubleKeyAsync(int x, int y);

    }
}