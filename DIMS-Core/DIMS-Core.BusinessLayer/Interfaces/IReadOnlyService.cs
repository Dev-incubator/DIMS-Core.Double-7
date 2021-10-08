using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIMS_Core.BusinessLayer.Interfaces
{
    public interface IReadOnlyService<TModel> : IDisposable
        where TModel : class
    {
        Task<List<TModel>> GetAll();
    }
}