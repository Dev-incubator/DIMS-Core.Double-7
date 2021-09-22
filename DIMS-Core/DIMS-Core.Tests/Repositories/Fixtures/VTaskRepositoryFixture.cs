using System;
using DIMS_Core.DataAccessLayer.Models;
using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class VTaskRepositoryFixture : ViewRepositoryFixture<VTaskRepository>
    {
        protected override VTaskRepository CreateRepository() => new (Context);
    }
}