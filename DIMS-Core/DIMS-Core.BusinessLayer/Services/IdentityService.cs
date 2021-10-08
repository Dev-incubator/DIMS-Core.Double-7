using System;
using AutoMapper;
using DIMS_Core.BusinessLayer.Interfaces;
using DIMS_Core.Identity.Interfaces;
using DIMS_Core.Identity.Services;

namespace DIMS_Core.BusinessLayer.Services
{
    public abstract class IdentityService : IIdentityService
    {
        protected readonly IMapper _mapper;
        protected readonly IIdentityUnitOfWork _unitOfWork;

        protected IdentityService(IIdentityUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}