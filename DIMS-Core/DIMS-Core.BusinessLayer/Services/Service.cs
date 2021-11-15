using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace DIMS_Core.BusinessLayer.Services
{
    public abstract class Service<TModel, TEntity, TRepository> : IService<TModel>
        where TModel : class
        where TEntity : class
        where TRepository : IRepository<TEntity>
    {
        protected readonly IMapper _mapper;
        protected readonly TRepository _repository;

        protected Service(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<List<TModel>> GetAll()
        {
            var entities = _repository.GetAll();

            return await entities.ProjectTo<TModel>(_mapper.ConfigurationProvider)
                                 .ToListAsync();
        }

        public async Task<TModel> GetById(int id)
        {
            var entity = await _repository.GetById(id);

            return _mapper.Map<TModel>(entity);
        }
        public virtual async Task<TModel> Create(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);

            var createdEntity = await _repository.Create(entity);
            await _repository.Save();

            return _mapper.Map<TModel>(createdEntity);
        }

        public virtual async Task<TModel> Update(TModel model)
        {
            var mappedEntity = _mapper.Map<TEntity>(model);
            var updatedEntity = _repository.Update(mappedEntity);

            await _repository.Save();

            return _mapper.Map<TModel>(updatedEntity);
        }
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
            await _repository.Save();
        }
        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}