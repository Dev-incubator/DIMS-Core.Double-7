using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.BusinessLayer.Services
{
    public class DirectionService : Service, IDirectionService
    {
        public DirectionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<DirectionModel>> GetAll()
        {
            var directions = UnitOfWork.DirectionRepository.GetAll();

            return await Mapper.ProjectTo<DirectionModel>(directions)
                               .ToListAsync();
        }

        public async Task<DirectionModel> GetById(int id)
        {
            var directionEntity = await UnitOfWork.DirectionRepository.GetById(id);

            return Mapper.Map<DirectionModel>(directionEntity);
        }

        public async Task<DirectionModel> Update(DirectionModel direction)
        {
            var directionEntity = await UnitOfWork.DirectionRepository.GetById(direction.DirectionId);

            var updatedEntity = UnitOfWork.DirectionRepository.Update(directionEntity);
            await UnitOfWork.Save();

            return Mapper.Map<DirectionModel>(updatedEntity);
        }

        public async Task<DirectionModel> Create(DirectionModel directionModel)
        {
            var directionEntity = Mapper.Map<Direction>(directionModel);

            var createdEntity = await UnitOfWork.DirectionRepository.Create(directionEntity);
            await UnitOfWork.Save();

            return Mapper.Map<DirectionModel>(createdEntity);
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.DirectionRepository.Delete(id);
            await UnitOfWork.Save();
        }

        /// <summary>
        ///     This method check models equality by operator == overloading
        /// </summary>
        /// <param name="directionModel1"></param>
        /// <param name="directionModel2"></param>
        /// <returns></returns>
        public bool Equal(DirectionModel directionModel1, DirectionModel directionModel2)
        {
            return directionModel1 == directionModel2;
        }

        /// <summary>
        ///     This method check models inequality by operator != overloading
        /// </summary>
        /// <param name="directionModel1"></param>
        /// <param name="directionModel2"></param>
        /// <returns></returns>
        public bool NotEqual(DirectionModel directionModel1, DirectionModel directionModel2)
        {
            return directionModel1 != directionModel2;
        }
    }
}