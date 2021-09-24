﻿using DIMS_Core.DataAccessLayer.Repositories;
using DIMS_Core.Tests.Repositories.Fixtures.Base;

namespace DIMS_Core.Tests.Repositories.Fixtures
{
    public class VTaskRepositoryFixture : ViewRepositoryFixture<VTaskRepository>
    {
        public override VTaskRepository Repository => new (Context);
    }
}