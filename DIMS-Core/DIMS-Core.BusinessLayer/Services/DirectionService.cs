using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Services
{
    public class DirectionService : Service<DirectionModel, Direction, IRepository<Direction>>, IDirectionService
    {
        public DirectionService(IRepository<Direction> repository, IMapper mapper)
            : base(repository, mapper)
        {
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