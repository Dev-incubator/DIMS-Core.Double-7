using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.BusinessLayer.Models;
using DIMS_Core.DataAccessLayer.Interfaces;
using DIMS_Core.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.BusinessLayer.Services
{
    public class UserProfileService : Service, IUserProfileService
    {
        public UserProfileService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public Task<UserProfileModel[]> GetAll()
        {
            return UnitOfWork.UserProfileRepository
                             .GetAll()
                             .ProjectTo<UserProfileModel>(Mapper.ConfigurationProvider)
                             .ToArrayAsync();
        }

        public async Task<UserProfileModel> GetById(int id)
        {
            var userProfileEntity = await UnitOfWork.UserProfileRepository.GetById(id);

            return Mapper.Map<UserProfileModel>(userProfileEntity);
        }

        public async Task<UserProfileModel> Update(UserProfileModel userProfile)
        {
            var userProfileEntity = await UnitOfWork.UserProfileRepository.GetById(userProfile.UserId);

            var updatedEntity = UnitOfWork.UserProfileRepository.Update(Mapper.Map(userProfile, userProfileEntity));

            await UnitOfWork.Save();

            return Mapper.Map<UserProfileModel>(updatedEntity);
        }

        public async Task<UserProfileModel> Create(UserProfileModel userProfileModel)
        {
            var userProfileEntity = Mapper.Map<UserProfile>(userProfileModel);

            var createdEntity = await UnitOfWork.UserProfileRepository.Create(userProfileEntity);
            await UnitOfWork.Save();

            return Mapper.Map<UserProfileModel>(createdEntity);
        }

        public async Task Delete(int id)
        {
            await UnitOfWork.UserProfileRepository.Delete(id);
            await UnitOfWork.Save();
        }

        /// <summary>
        ///     This method checks models equality by operator == overloading
        /// </summary>
        /// <param name="userModel1"></param>
        /// <param name="userModel2"></param>
        /// <returns></returns>
        public bool Equal(UserProfileModel userModel1, UserProfileModel userModel2)
        {
            return userModel1 == userModel2;
        }

        /// <summary>
        ///     This method checks models inequality by operator != overloading
        /// </summary>
        /// <param name="userModel1"></param>
        /// <param name="userModel2"></param>
        /// <returns></returns>
        public bool NotEqual(UserProfileModel userModel1, UserProfileModel userModel2)
        {
            return userModel1 != userModel2;
        }
    }
}