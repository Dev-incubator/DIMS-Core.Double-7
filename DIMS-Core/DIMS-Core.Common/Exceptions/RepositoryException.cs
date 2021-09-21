using System;

namespace DIMS_Core.Common.Exceptions
{
    public static class RepositoryException
    {
        public static void IsIdValid(int id, Range range)
        {
            if(id < range.Start.Value && id > range.End.Value)
            {
                throw new InvalidArgumentException(nameof(id));
            }
        }

        public static void IsEntityExists<TEntity>(TEntity entity, string entityName)
        {
            if (entity is null)
            {
                throw new ObjectNotFoundException(entityName);
            }
        }
    }
}
