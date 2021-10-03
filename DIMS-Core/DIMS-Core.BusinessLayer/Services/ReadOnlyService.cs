using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIMS_Core.BusinessLayer.Services
{
    public abstract class ReadOnlyService<TModel, TEntity, TRepository> : IReadOnlyService<TModel>
        where TModel : class
        where TEntity : class
        where TRepository : IReadOnlyRepository<TEntity>
    {
        protected readonly IMapper _mapper;
        protected readonly TRepository _repository;

        protected ReadOnlyService(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<TModel>> GetAll()
        {
            var entities = _repository.GetAll();

            var mappedModels = _mapper.ProjectTo<TModel>(entities);

            return await mappedModels.ToListAsync();
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
