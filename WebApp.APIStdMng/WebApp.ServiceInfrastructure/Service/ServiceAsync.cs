using AutoMapper;
using System.Linq.Expressions;
using WebApp.DALApplication.IRepository;
using WebApp.ServiceInfrastructure.IService;

namespace WebApp.ServiceInfrastructure.Service
{
    public class ServiceAsync<TEntity, TDto> : IServiceAsync<TEntity, TDto> 
        where TDto : class where TEntity : class
    {
        private readonly IRepositoryAsync<TEntity> _repository;
        private readonly IMapper _mapper;

        public ServiceAsync(IRepositoryAsync<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(TDto tDto)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(tDto);
                var ret=await _repository.AddAsync(entity);
                
                return ret;
            }
            catch (Exception)
            {
                
                return false;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// 
        public async Task AddEntityAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
        }


        public async Task DeleteEntityAsync(int id)
        {
            await _repository.DeleteEntityAsync(await _repository.GetByIdAsync(id));
        }

        //21/11/2023
        public async Task DeleteEntityStringAsync(string matricule)
        {
            await _repository.DeleteEntityAsync(await _repository.GetByStringIdAsync(matricule));
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(await _repository.GetByIdAsync(id));
        }

        public IEnumerable<TDto> GetAll(Expression<Func<TDto, bool>> expression = null)
        {
            var predicate = _mapper.Map<Expression<Func<TEntity, bool>>>(expression);
            return _repository.GetAll(predicate).Select(_mapper.Map<TDto>).ToList();
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        //14/11/2023
        public async Task<TDto> GetByStringIdAsync(string id)
        {
            var entity = await _repository.GetByStringIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> GetFirstAsync(Expression<Func<TDto, bool>> expression)
        {
            var predicate = _mapper.Map<Expression<Func<TEntity, bool>>>(expression);
            var entity = await _repository.GetFirstAsync(predicate);
            return _mapper.Map<TDto>(entity);
        }

        public async Task UpdateAsync(TDto entityTDto)
        {
            var entity = _mapper.Map<TEntity>(entityTDto);
            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateEntityAsync(TDto entityTDto)
        {
            var entity = _mapper.Map<TEntity>(entityTDto);
            await _repository.UpdateEntityAsync(entity);
        }

        ////02/01/2024
        //public async Task<TDto> GetByDoubleKeyAsync(int x, int y)
        //{
        //    var entity = await _repository.GetByDoubleKey(x, y);
        //    return _mapper.Map<TDto>(entity);
        //}
    }
}